namespace ConsoleApplication3.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Utils;
    using Utils.Enums;

    public class Student : IStudent
    {
        private string firstName;
        private GradeType grade;
        private IList<Mark> marks;
        private string lastName;

        public Student(string firstName, string lastName, GradeType grade)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
            this.Marks = new List<Mark>();
        }

        public IList<Mark> Marks
        {
            get
            {
                return this.marks;
            }

            private set
            {
                this.marks = value;
            }
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                if (Validator.ValidateName(value))
                {
                    this.firstName = value;
                }
                else
                {
                    throw new ArgumentException("First name is not in correct format!");
                }
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                if (Validator.ValidateName(value))
                {
                    this.lastName = value;
                }
                else
                {
                    throw new ArgumentException("Last name is not in correct format!");
                }
            }
        }

        public GradeType Grade
        {
            get
            {
                return this.grade;
            }

            private set
            {
                // Yoda expression should be more suitable here but StyleCop is crying!
                if ((int)value < 1 || (int)value > 12)
                {
                    throw new ArgumentOutOfRangeException("Grade must be between 1 and 12!");
                }

                this.grade = value;
            }
        }

        public string ListMarks()
        {
            string result = string.Empty;

            if (this.Marks.Count > 0)
            {
                var marksList = this.marks.Select(mark => $"{mark.Subject} => {mark.Value}").ToList();
                result = string.Join("\n", marksList);
                result += "\n";
            }
            else
            {
                result = "This student has no marks.";
            }

            return result;
        }
    }
}
