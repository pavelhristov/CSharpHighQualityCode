namespace ConsoleApplication3.Models.Commands
{
    using System.Collections.Generic;
    using ConsoleApplication3.Core;
    using Contracts;
    using Utils.Enums;

    internal class CreateTeacherCommand : ICommand
    {
        private static int id = 0;

        public string Execute(IList<string> para)
        {
            Engine.Teachers.Add(id, new Teacher(para[0], para[1], (SubjectType)int.Parse(para[2])));
            return $"A new teacher with name {para[0]} {para[1]}, subject {(SubjectType)int.Parse(para[2])} and ID {id++} was created.";
        }
    }
}
