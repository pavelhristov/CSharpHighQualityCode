namespace High.Quality.Code.BadExample
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Threading.Tasks;

    public class Bunnies
    {
        public static void Main(string[] args)
        {
            IEnumerable<Bunny> bunnies = new List<Bunny>
            {
                new Bunny { Age = 1, Name = "Leonid", FurType = FurType.NotFluffy },
                new Bunny { Age = 2, Name = "Rasputin", FurType = FurType.ALittleFluffy },
                new Bunny { Age = 3, Name = "Tiberii", FurType = FurType.ALittleFluffy },
                new Bunny { Age = 1, Name = "Neron", FurType = FurType.ALittleFluffy },
                new Bunny { Age = 3, Name = "Klavdii", FurType = FurType.Fluffy },
                new Bunny { Age = 3, Name = "Vespasian", FurType = FurType.Fluffy },
                new Bunny { Age = 4, Name = "Domician", FurType = FurType.FluffyToTheLimit },
                new Bunny { Age = 2, Name = "Tit", FurType = FurType.FluffyToTheLimit }
            };

            IWriter consoleWriter = new ConsoleWriter();
            foreach (var bunny in bunnies)
            {
                bunny.Introduce(consoleWriter);
            }

            string bunniesFilePath = @"..\..\bunnies.txt";
            FileStream fileStream = File.Create(bunniesFilePath);
            fileStream.Close();

            using (StreamWriter streamWriter = new StreamWriter(bunniesFilePath))
            {
                foreach (var bunny in bunnies)
                {
                    streamWriter.WriteLine(bunny.ToString());
                }
            }
        }
    }

    public enum FurType
    {
        NotFluffy,
        ALittleFluffy,
        Fluffy,
        FluffyToTheLimit
    }

    public interface IWriter
    {
        void Write(string message);
        void WriteLine(string message);
    }

    public class ConsoleWriter : IWriter
    {
        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }

    public static class StringExtensions
    {
        public static string SplitToSeparateWordsByUppercaseLetter(this string sequence)
        {
            int probableStringMargin = 10;
            int probableStringSize = sequence.Length + probableStringMargin;
            StringBuilder builder = new StringBuilder(probableStringSize);
            char singleWhitespace = ' ';

            foreach (var letter in sequence)
            {
                if (char.IsUpper(letter))
                {
                    builder.Append(singleWhitespace);
                }

                builder.Append(letter);
            }

            return builder.ToString().Trim();
        }
    }
}
