using Assignment.Commands;
using Assignment.Loaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace Assignment.ViewModels
{
    public class LoadersViewModel : ViewModelBase
    {
        private static readonly Random Random = new Random();
        private static readonly object RandomLock = new object();

        public LoadersViewModel(bool startWorkers = true)
        {
            Threads = new List<ThreadWorker>
            {
                new ThreadWorker(CreateDuration()),
                new ThreadWorker(CreateDuration()),
                new ThreadWorker(CreateDuration())
            };

            CancelFirstCommand = new RelayCommand(_ => Threads[0].Cancel());
            CancelSecondCommand = new RelayCommand(_ => Threads[1].Cancel());
            CancelThirdCommand = new RelayCommand(_ => Threads[2].Cancel());

            foreach (var worker in Threads)
            {
                worker.PropertyChanged += WorkerPropertyChanged;
                if (startWorkers)
                {
                    StartWorker(worker);
                }
            }
        }

        public IList<ThreadWorker> Threads { get; }
        public ICommand CancelFirstCommand { get; }
        public ICommand CancelSecondCommand { get; }
        public ICommand CancelThirdCommand { get; }

        public double TotalProgress
        {
            get
            {
                var activeThreads = Threads.Where(thread => thread.IsActive).ToList();
                return activeThreads.Count == 0 ? 0 : activeThreads.Average(thread => thread.Progress);
            }
        }

        private static int CreateDuration()
        {
            lock (RandomLock)
            {
                return Random.Next(10, 51);
            }
        }

        private void StartWorker(ThreadWorker worker)
        {
            var thread = new Thread(() => UpdateWorkerProgress(worker)) { IsBackground = true };
            thread.Start();
        }

        private void UpdateWorkerProgress(ThreadWorker worker)
        {
            while (worker.IsActive && worker.Elapsed < worker.Duration)
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                if (!worker.IsActive)
                {
                    return;
                }

                Application.Current.Dispatcher.Invoke(() => worker.Elapsed++);
            }
        }

        private void WorkerPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ThreadWorker.Progress) || e.PropertyName == nameof(ThreadWorker.IsActive))
            {
                OnPropertyChanged(nameof(TotalProgress));
            }
        }
    }
}