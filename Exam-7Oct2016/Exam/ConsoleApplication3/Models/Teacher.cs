namespace ConsoleApplication3.Models
{
    using System;
    using Contracts;
    using Utils;
    using Utils.Enums;

    public class Teacher : ITeacher
    {
        private string firstName;
        private string lastName;
        private SubjectType subject;

        public Teacher(string firstName, string lastName, SubjectType subject)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Subject = subject;
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

        public void AddMark(IStudent student, float value)
        {
            if (student.Marks.Count >= 20)
            {
                throw new IndexOutOfRangeException("Students can not have more than 20 marks!");
            }

            var mark = new Mark(this.subject, value);
            student.Marks.Add(mark);
        }
    }
}
