namespace ConsoleApplication3
{
    using Core;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            /* Please ignore Factory and Commands classes.
            *  Noticed that they have no place here too late.
            *  Left them there just to show what I thought was better implementation.
            */
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();

            var engine = new Engine(reader, writer);
            engine.Start();
        }
    }
}
