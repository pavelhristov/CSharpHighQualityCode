namespace ConsoleApplication3.Models
{
    using System;
    using ConsoleApplication3.Contracts;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
