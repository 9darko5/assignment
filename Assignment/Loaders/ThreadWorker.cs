namespace Assignment.Loaders
{
    public class ThreadWorker
    {
        public ThreadWorker(int duration)
        {
            Duration = duration;
            IsActive = true;
        }

        public int Duration { get; set; }

        public int Elapsed { get; set; }

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

        public bool IsActive { get; private set; }

        public void Cancel()
        {
            IsActive = false;
        }
    }
}
