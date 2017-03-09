namespace ConsoleApplication3.Models.Commands
{
    using System.Collections.Generic;
    using ConsoleApplication3.Core;
    using Contracts;

    internal class TeacherAddMarkCommand : ICommand
    {
        public string Execute(IList<string> prms)
        {
            var teacherid = int.Parse(prms[0]);
            var studentid = int.Parse(prms[1]);
            var student = Engine.Students[teacherid];
            var teacher = Engine.Teachers[studentid];
            teacher.AddMark(student, float.Parse(prms[2]));

            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {float.Parse(prms[2])} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}
