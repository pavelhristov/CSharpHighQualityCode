namespace ConsoleApplication3.Contracts
{
    using System.Collections.Generic;
    using ConsoleApplication3.Models;
    using ConsoleApplication3.Utils.Enums;

    public interface IStudent
    {
        IList<Mark> Marks { get; }

        string FirstName { get; }

        string LastName { get; }

        GradeType Grade { get; }

        string ListMarks();
    }
}
