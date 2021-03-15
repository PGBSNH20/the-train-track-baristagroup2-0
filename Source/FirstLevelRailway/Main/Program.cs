using System;
using System.Collections.Generic;
using System.Threading;
using System.Transactions;

namespace FirstLevelRailway
{

    class Program
    {
        public static List<IMemoryLayer> Layers = new List<IMemoryLayer>();

        static void Main(string[] args)
        {
            var trainhej = new Train(120);
            var timeTable1 = new TrainPlanner(1)
                .StartTrainAt("Gothenburg", "11:00")
                .ArriveTrainAt("Partille", "11:15");
            
            Console.CursorVisible = false;
            Thread clockThread = CreateClockThread(100);
            clockThread.Start();

            while (true)
            {
                Thread.Sleep(200);
                RefreshScreen();
            }

            Console.ReadLine();
        }

        public static void RefreshScreen()
        {
            foreach (var layer in Layers)
            {
                for (int i = 0; i < layer.Drawables.Count; i++)
                {
                    if (layer.Drawables[i] != null)
                        ConsoleWriter.Write(layer.Drawables[i]);
                }
            }
        }
        public static Thread CreateClockThread(int ns_per_tick)
        {
            var clockLayer = new ClockMemoryLayer();
            Layers.Add(clockLayer);
            var clock = new TwentyFourHourClock();
            var timeDisplay = new TimeDisplayer(0, 0, clockLayer);
            var timeKeeper = new TimeKeeper(clock, timeDisplay, ns_per_tick);
            return new Thread(new ThreadStart(() => timeKeeper.StartTime(null)));
        }
        //static void TrainThread(Train train)
        //{
        //    foreach (var m in train.Route)
        //    {
        //        train.Move();
        //        Thread.Sleep(500);
        //    }
        //}
        static void moveThreads()
        {
            int x = 0;
            while (x < 20)
            {
                x++;
                Console.WriteLine(x);

            }
            Console.WriteLine("done");
        }
    }
}
