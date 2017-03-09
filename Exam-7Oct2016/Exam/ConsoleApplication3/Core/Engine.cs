namespace ConsoleApplication3.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using ConsoleApplication3.Contracts;
    using Models;

    public class Engine
    {
        private static Dictionary<int, ITeacher> teachers;
        private static Dictionary<int, IStudent> students;
        private IReader reader;
        private IWriter writer;

        static Engine()
        {
            teachers = new Dictionary<int, ITeacher>();
            students = new Dictionary<int, IStudent>();
        }

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        internal static Dictionary<int, ITeacher> Teachers
        {
            get
            {
                return teachers;
            }

            private set
            {
                teachers = value;
            }
        }

        internal static Dictionary<int, IStudent> Students
        {
            get
            {
                return students;
            }

            private set
            {
                students = value;
            }
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var command = this.reader.ReadLine();
                    if (command == "End")
                    {
                        break;
                    }

                    var commandParams = command.Split(' ').ToList();

                    var assembly = this.GetType().GetTypeInfo().Assembly;

                    var tpyeinfo = assembly.DefinedTypes
                       .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                       .Where(type => type.Name.ToLower().Contains(commandParams[0].ToLower()))
                       .FirstOrDefault();
                    if (tpyeinfo == null)
                    {
                        throw new ArgumentException("The passed command is not found!");
                    }

                    var order = Activator.CreateInstance(tpyeinfo) as ICommand;
                    commandParams.RemoveAt(0);
                    this.Print(order.Execute(commandParams));

                    // Just noticed I can't play with ICommand and lines below does not use it :/
                    // switch (commandParams[0].ToLower())
                    // {
                    //     case "createstudent": this.Print(Commands.CreateStudent(commandParams[1], commandParams[2], (GradeType)int.Parse(commandParams[3]))); break;
                    //     case "removestudent": this.Print(Commands.RemoveStudent(int.Parse(commandParams[1]))); break;
                    //     case "createteacher": this.Print(Commands.CreateTeacher(commandParams[1], commandParams[2], (SubjectType)int.Parse(commandParams[3]))); break;
                    //     case "studentlistmarks": this.Print(Commands.StudentListMarks(int.Parse(commandParams[1]))); break;
                    //     case "teacheraddmark": this.Print(Commands.TeacherAddMarks(int.Parse(commandParams[1]), int.Parse(commandParams[2]),float.Parse(commandParams[3]))); break;
                    //     default:
                    //         throw new ArgumentException("The passed command is not found!");
                    //         break;
                    // }
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
            }
        }

        private void Print(string message)
        {
            this.writer.WriteLine(message);
        }
    }
}
