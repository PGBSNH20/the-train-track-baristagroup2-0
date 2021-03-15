using System;
using System.Threading;

namespace TrainConsole
{
    public class Controller
    {
        private Train train { get; set; }
        private ConsoleKey StartStopKey { get; }
        public Controller(Train train, ConsoleKey startStopKey)
        {
            this.train = train;
            StartStopKey = startStopKey;
        }
        public void ControlTrain()
        {
            var key = Console.ReadKey(true);
            while(true)
            {
                key = Console.ReadKey(true);
                Thread.Sleep(100);
                if (key.Key == StartStopKey)
                {
                    train.IsStopped = !train.IsStopped;
                }
                    
            }
        }
    }
}