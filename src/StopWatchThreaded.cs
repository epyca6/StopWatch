using System.Threading;
namespace StopWatch
{
    public class StopWatchThreaded
    {
        // static field for thread access
        static private bool _isRunning = false;
        static private DateTime _startDate = DateTime.Now;
        //private Thread thread1 = new Thread(_updateConsoleWithStopper);
        private Task _task1 = Task.Run(() => _updateConsoleWithStopper());
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

                // Removed Thread Start
                // Makes no sense in this terminology
                _task1 = Task.Run(() => _updateConsoleWithStopper());
            }
            else
            {
                // I dont wanted to exlude the opportunity to restart the stopwatch
                // with error throwing. Instead of just notify the user.
                //throw new InvalidOperationException("Stopper is allready running");
                Console.Write("\t\t\t\t\tSector Time\n\r");
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
                // Task abortion removed from here. 
                // Makes no sense in this term.
            }
            else
            {
                // Informs user that stop watch is standing still
                Console.Write("StopWatch allready stopped\r");
            }
        }
    }
}