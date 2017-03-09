namespace ConsoleApplication3.Contracts
{
    using ConsoleApplication3.Utils.Enums;

    public interface IFactory
    {
        IStudent CreateSudent(string firstName, string lastName, GradeType grade);

        ITeacher CreateTeacher(string firstName, string lastName, SubjectType subject);
    }
}
