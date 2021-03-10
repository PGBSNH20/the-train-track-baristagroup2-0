using System.Collections.Generic;
using System.Threading;
using System.Transactions;

namespace FirstLevelRailway
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var trainData = TrainCallLoader.Load();
            var trains = Train.GenerateFrom(trainData);
            var trainThreads = new List<Thread>();
            foreach (var train in trains)
            {
                trainThreads.Add( new Thread(new ThreadStart(() => TrainThread(train))));
            }
            foreach (var thread in trainThreads)
            {
                thread.Start();
            }
        }
        static void TrainThread(Train train)
        {
            foreach (var m in train.Route)
            {
                train.Move();
                Thread.Sleep(500);
            }
        }
    }
}
