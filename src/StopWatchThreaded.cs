using System.Threading;
namespace StopWatch
{
    public class StopWatchThreaded
    {
        // static field for thread access
        static private bool _isRunning;
        static private DateTime _startDate;
        private Thread thread1 = new Thread(_updateConsoleWithStopper);
        
        // Interfaces may can extend STOPWatch in the future ;)

        private static void _updateConsoleWithStopper()
        {
            TimeSpan dif;

            // Thread is running with 100ms update rate.
            // Looks great and lets the main thread to poll the
            // Protection for isRunning state. Obsolate btw.
            // because abort wil ldestroy the thread.
            // 
            while (_isRunning)
            {
                dif = _startDate - DateTime.Now;
                Console.Write("Timer: {0}\r", dif);
                Thread.Sleep(100);
            }
        }
        public void Start()
        {
            if (_isRunning != true)
            {
                _startDate = DateTime.Now;
                _isRunning = true;
                Console.WriteLine("StopWatch is started: {0}", _startDate);

                // Create the thread and start
                // Important to trecreate it after abort is done
                // maybe a legacy solution, but was fun to check it out
                thread1 = new Thread(_updateConsoleWithStopper);
                thread1.Start();

            }
            else
            {
                // I dont wanted to exlude the opportunity to restart the stopwatch
                // with error throwing. Instead of just notify the user.
                //throw new InvalidOperationException("Stopper is allready running");
                Console.Write("\n\t\t\t\t\tSector Time\r");
            }            
        }

        public void Stop()
        {
            DateTime now = DateTime.Now;
            TimeSpan dif;

            if(_isRunning == true)
            {
                dif = _startDate - now;
                Console.WriteLine("Stop watch stopped at: {0} \nElapsed time: {1}",now, dif);
                _isRunning = false;
                
                // 0 day hack, to let the program run, but not crash
                // after Abortiont throws a default exception.
                // Unhandled till I am not an expert of thread handling.
                try
                {
                    thread1.Abort();    //TODO: Causing SYSLIB0006 warning: Obsolete code. Rework in the future
                }
                catch   //removed for warning elimination
                {
                    // Do nothing
                }
            }
            else
            {
                Console.WriteLine("StopWatch allready stopped");
            }
        }
    }
}