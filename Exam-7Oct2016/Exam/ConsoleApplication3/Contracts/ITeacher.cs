namespace ConsoleApplication3.Contracts
{
    using ConsoleApplication3.Utils.Enums;

    public interface ITeacher
    {
        string FirstName { get; }

        string LastName { get; }

        SubjectType Subject { get; }

        void AddMark(IStudent student, float value);
    }
}
