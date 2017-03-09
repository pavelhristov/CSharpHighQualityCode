namespace ConsoleApplication3.Core
{
    using ConsoleApplication3.Contracts;
    using ConsoleApplication3.Models;
    using ConsoleApplication3.Utils.Enums;

    public class Factory : IFactory
    {
        public Factory()
        {
        }

        public IStudent CreateSudent(string firstName, string lastName, GradeType grade)
        {
            return new Student(firstName, lastName, grade);
        }

        public ITeacher CreateTeacher(string firstName, string lastName, SubjectType subject)
        {
            return new Teacher(firstName, lastName, subject);
        }
    }
}
