namespace StopWatch
{
    public class StopWatch
    {
        // Private properties
        private bool _isRunning;
        private DateTime _startDate;
        
        public void Start()
        {
            if (_isRunning != true)
            {
                // Starts the stop watch, and indicates the started state
                _startDate = DateTime.Now;
                _isRunning = true;
                Console.WriteLine("Stop watch is started: {0}", _startDate);
            }
            else
            {
                // Throw an error, in case of double start StopWatch
                throw new InvalidOperationException("Stopper is allready running");
            }            
        }

        public void Stop()
        {
            DateTime now = DateTime.Now;
            TimeSpan dif;

            if(_isRunning == true)
            {
                // Disable StopWatch running state and calculate the elapsed time from start
                dif = _startDate - now;
                Console.WriteLine("Stop watch stopped at: {0} \nElapsed time: {1}",now, dif);
                _isRunning = false;
            }
            else
            {
                // Throw a message, that the Watch is already stopped
                Console.WriteLine("Stop watch allready stopped");
            }
        }
    }
}