namespace ConsoleApplication3.Models.Commands
{
    using System.Collections.Generic;
    using ConsoleApplication3.Core;
    using Contracts;

    internal class RemoveTeacherCommand : ICommand
    {
        public string Execute(IList<string> paras)
        {
            Engine.Teachers.Remove(int.Parse(paras[0]));
            return $"Teacher with ID {int.Parse(paras[0])} was sucessfully removed.";
        }
    }
}
