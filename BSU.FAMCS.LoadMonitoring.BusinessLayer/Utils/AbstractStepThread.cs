using System;
using System.Globalization;
using System.Threading;

namespace BSU.FAMCS.LoadMonitoring.BusinessLayer.Utils
{
    public abstract class AbstractStepThread
    {
        protected Thread Thread;
        public int SleepTime { get; private set; }
        private bool _doContinueThread;

        protected AbstractStepThread()
        {
            Thread = new Thread(Work);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(1049);
            SleepTime = 1000;
        }
        protected AbstractStepThread(int sleepTimeIn)
        {
            SleepTime = sleepTimeIn;
            Thread = new Thread(Work);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(1049);
        }
        
        private void Work()
        {
            while (_doContinueThread)
            {
                DoStep();
                Thread.Sleep(SleepTime);
            }
        }

        protected void StartThread()
        {
            _doContinueThread = true;
            Thread.Start();
        }

        public virtual void SetTimeToSleep(int timeToSet)
        {
            SleepTime = timeToSet;
        }

        protected void StopThread()
        {
            _doContinueThread = false;
            Thread.Join();
        }
        /// <summary>
        /// This method should be overriden by child classes
        /// </summary>
        protected virtual void DoStep()
        {
            Console.WriteLine("Thread's step was not found");
        }
    }
}
