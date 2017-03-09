namespace ConsoleApplication3.Models.Commands
{
    using System.Collections.Generic;
    using ConsoleApplication3.Core;
    using Contracts;

    internal class StudentListMarksCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            return Engine.Students[int.Parse(parameters[0])].ListMarks();
        }
    }
}
