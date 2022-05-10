namespace StopWatch
{
    public class StopWatch
    {
        private bool _isRunning;
        private DateTime _startDate;
        
        public void Start()
        {
            if (_isRunning != true)
            {
                _startDate = DateTime.Now;
                _isRunning = true;
                Console.WriteLine("Stop watch is started: {0}", _startDate);
            }
            else
            {
                //added a new comment
                throw new InvalidOperationException("Stopper is allready running");
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
            }
            else
            {
                Console.WriteLine("Stop watch allready stopped");
            }
        }
    }
}