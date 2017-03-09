namespace ConsoleApplication3.Core
{
    using ConsoleApplication3.Utils.Enums;

    internal static class Commands
    {
        private static int studentId;
        private static int teacherId;
        private static Factory factory;

        static Commands()
        {
            factory = new Factory();
            studentId = 0;
            teacherId = 0;
        }

        internal static string CreateStudent(string firstName, string lastName, GradeType grade)
        {
            Engine.Students.Add(studentId, factory.CreateSudent(firstName, lastName, grade));
            return $"A new student with name {firstName} {lastName}, grade {grade} and ID {studentId++} was created.";
        }

        internal static string CreateTeacher(string firstName, string lastName, SubjectType subject)
        {
            Engine.Teachers.Add(teacherId, factory.CreateTeacher(firstName, lastName, subject));
            return $"A new teacher with name {firstName} {lastName}, subject {subject} and ID {teacherId++} was created.";
        }

        internal static string TeacherAddMarks(int teacherid, int studentid, float mark)
        {
            var student = Engine.Students[teacherid];
            var teacher = Engine.Teachers[studentid];
            teacher.AddMark(student, mark);

            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {mark} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }

        internal static string RemoveStudent(int studentid)
        {
            Engine.Students.Remove(studentid);
            return $"Student with ID {studentid} was sucessfully removed.";
        }

        internal static string StudentListMarks(int studentid)
        {
            return Engine.Students[studentid].ListMarks();
        }
    }
}
