namespace ConsoleApplication3.Models.Commands
{
    using System.Collections.Generic;
    using ConsoleApplication3.Core;
    using Contracts;
    using Utils.Enums;

    internal class CreateStudentCommand : ICommand
    {
        private static int id = 0;

        public string Execute(IList<string> para)
        {
            Engine.Students.Add(id, new Student(para[0], para[1], (GradeType)int.Parse(para[2])));
            return $"A new student with name {para[0]} {para[1]}, grade {(GradeType)int.Parse(para[2])} and ID {id++} was created.";
        }
    }
}
