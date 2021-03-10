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
            //Thread.CurrentThread.
            //Train redDragon = new Train();
            //Train blackDragon = new Train();

            //Thread redDragonThread = new Thread(new ThreadStart(() => TrainThread("Red dragon")));
            //Thread blackDragonThread = new Thread(new ThreadStart(() => TrainThread("Black dragon")));
            
            
            //redDragonThread.Start();
            //blackDragonThread.Start();
            //trainTwo.Start();
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
    /*
     * Tåg
     * Startpunkt
     * Slutpunkt
     * 
     * object
     *      tåg
     *      station
     *      räls/spår
     *      Rutt
     *      
     *      station
     *      räls
     *      station
     *      
     *      Avgår från Alingsås
     *      Nästa anhalt Göteborg
     *      Stannar i Göteborg
     */




}
