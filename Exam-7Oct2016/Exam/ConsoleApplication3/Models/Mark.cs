namespace ConsoleApplication3.Models
{
    using System;
    using ConsoleApplication3.Utils.Enums;

    public class Mark
    {
        private float value;
        private SubjectType subject;

        public Mark(SubjectType subject, float value)
        {
            this.Subject = subject;
            this.Value = value;
        }

        public float Value
        {
            get
            {
                return this.value;
            }

            private set
            {
                // Yoda expression should be more suitable here but StyleCop is crying!
                if (value < 2 || value > 6)
                {
                    throw new ArgumentOutOfRangeException("Mark must be between 2 and 6!");
                }

                this.value = value;
            }
        }

        public SubjectType Subject
        {
            get
            {
                return this.subject;
            }

            private set
            {
                this.subject = value;
            }
        }
    }
}
