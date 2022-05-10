namespace StopWatch
{
    partial class Program
    {

        static void Main(string[] args)
        {
            // Excercise
            //var stopper = new StopWatch();
            // Extended ;)
            var stopper = new StopWatchThreaded();

            Console.WriteLine("Welcome to the stop watch");
            Console.WriteLine("Commands:");
            Console.WriteLine("> S: \tstart");
            Console.WriteLine("> Q: \tstop");
            Console.WriteLine("> ESC: \texit");


            ConsoleKey stdin;
            do
            {
                // Get key from stdin
                stdin = Console.ReadKey(true).Key;

                // Select between Stopper functions
                switch (stdin)
                {
                    case ConsoleKey.S:
                        stopper.Start();
                        break;
                    case ConsoleKey.Q:
                        stopper.Stop();
                        break;
                    default:
                        break;
                }
                // Escape condition
            } while ( stdin != ConsoleKey.Escape);
        }


    }
}