using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Assignment.Loaders
{
    public class ThreadWorker : INotifyPropertyChanged
    {
        private int _duration;
        private int _elapsed;
        private bool _isActive;

        public ThreadWorker(int duration)
        {
            Duration = duration;
            IsActive = true;
        }

        public int Duration
        {
            get => _duration;
            set
            {
                _duration = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Progress));
            }
        }

        public int Elapsed
        {
            get => _elapsed;
            set
            {
                _elapsed = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Progress));
            }
        }

        public double Progress
        {
            get
            {
                if (Duration <= 0)
                {
                    return 0;
                }

                var progress = (double)Elapsed / Duration * 100;
                return progress < 0 ? 0 : progress > 100 ? 100 : progress;
            }
        }

        public bool IsActive
        {
            get => _isActive;
            private set
            {
                _isActive = value;
                OnPropertyChanged();
            }
        }

        public void Cancel()
        {
            IsActive = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}