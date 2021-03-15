using System;
using System.Threading;
using System.Transactions;

namespace FirstLevelRailway
{

    class Program
    {
        static void Main(string[] args)
        {
            
            //Thread thread1 = new Thread(new ThreadStart(moveThreads));
            //thread1.Start();

            Console.CursorVisible = false;
            TrackReader.ReadToRailChars();
            var railChars = TrackReader.railChars;

            //foreach (var rc in railChars)
            //{
            //    rc.Alter();
            //}

            
            //var charMover = new CharMover('x', (1, 1));

            //clock.CharMover = charMover;

            //clock.StartClock(maxTicks: 200000);

            Console.ReadLine();


            //var trainData = TrainCallLoader.Load();
            //var trains = Train.GenerateFrom(trainData);
            //var trainThreads = new List<Thread>();
            //foreach (var train in trains)
            //{
            //    trainThreads.Add( new Thread(new ThreadStart(() => TrainThread(train))));
            //}
            //foreach (var thread in trainThreads)
            //{
            //    thread.Start();
            //}
        }
        //static void TrainThread(Train train)
        //{
        //    foreach (var m in train.Route)
        //    {
        //        train.Move();
        //        Thread.Sleep(500);
        //    }
        //}
        //static void moveThreads()
        //{
        //    int x = 0;
        //    while (x < 20)
        //    {
        //        x++;
        //        Console.WriteLine(x);
                
        //    }
        //    Console.WriteLine("done");
        //}
    }
}
