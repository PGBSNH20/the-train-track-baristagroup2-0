using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Transactions;

namespace FirstLevelRailway
{

    class Program
    {
        public static List<IMemoryLayer> Layers = new List<IMemoryLayer>();
        public static IClock Clock { get; set; }
        static void Main(string[] args)
        {
            var read = TrackReader.Read(File.ReadAllLines(@"TextFiles/Simple-track.txt"));
            var parts = RailwayPartsORM.Map(read);
            RailwayAssembler.Assemble(parts);

            var trainhej = new Train();
            var timeTable1 = new TrainPlanner(5)
                .StartTrainAt("1", "11:00")
                .ArriveTrainAt("2", "11:15")
                .ToPlan();

             var timeTable2 = new TrainPlanner(5)
                 .StartTrainAt("2", "12:00")
                .ArriveTrainAt("3", "12:15")
                .ToPlan();

            var testOfList = new TrainPlanner(1);
            testOfList.createStationTimeList();


            Console.CursorVisible = false;
            var clock = new TwentyFourHourClock();
            Clock = clock;
            Thread clockThread = CreateClockThread(100, clock);
            clockThread.Start();

            while (true)
            {
                Thread.Sleep(200);
                RefreshScreen();
            }


            //var charMover = new CharMover('x', (1, 1));

            //clock.CharMover = charMover;

            //clock.StartClock(maxTicks: 200000);

            //Console.ReadLine();
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
        public static Thread CreateClockThread(int ns_per_tick, IClock clock)
        {
            var clockLayer = new ClockMemoryLayer();
            Layers.Add(clockLayer);
            var timeDisplay = new TimeDisplayer(10, 0, clockLayer);
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

                //    }
                //    Console.WriteLine("done");
                //}
            }
        }
    }
}
