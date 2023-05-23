namespace ImplementDotNetInterfaces
{
    public struct Interval
    {
        private DateTime start;
        private DateTime end;

        public Interval(DateTime start, DateTime end)
        {
            if(!IsValidInterval(start, end))
            {
                throw new ArgumentOutOfRangeException();
            }
            this.start = start;
            this.end = end;
        }

        public DateTime Start
        {
            get
            {
                return start;
            }
            set
            {
                if (!IsValidInterval(value, end))
                {
                    throw new ArgumentOutOfRangeException();
                }
                start = value;
            }
        }

        public DateTime End
        {
            get
            {
                return end;
            }
            set
            {
                if (!IsValidInterval(start, value))
                {
                    throw new ArgumentOutOfRangeException();
                }
                end = value;
            }
        }

        static bool IsValidInterval(DateTime start, DateTime end)
        {
            return start <= end;
        }
    }
}