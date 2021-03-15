using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace TrainConsole
{
    class Program
    {
        public static string advancedTrackPath = @"TextFiles\traintrack.txt";
        public static string simpleTrackPath = @"TextFiles\simpleTrack.txt";
        public static List<IMemoryLayer> Layers = new List<IMemoryLayer>();
      
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            var clockLayer = new ClockMemoryLayer();
            var railwayLayer = new RailwayMemoryLayer();

            Layers.Add(clockLayer);
            Layers.Add(railwayLayer);

            var clock = new TwentyFourHourClock();
            var timeDisplay = new TimeDisplayer(0, 0, clockLayer);
            var timeKeeper = new TimeKeeper(clock, timeDisplay, 100);

            var read = TrainTrackReader.Read(File.ReadAllLines(advancedTrackPath));
            var parts = RailwayPartsORM.Map(read);

            RailwayAssembler.Assemble(parts);
            railwayLayer.AppendRailwayDrawables();
            
            var station1 = Railway.GetRailwayParts().Find(x => x.Char == '1');
            var station2 = Railway.GetRailwayParts().Find(x => x.Char == '3');

            var trainDisplayer = new TrainDisplayer(railwayLayer);
            var train = new Train(clock, RouteTracker.Track(station1, station2), 300, trainDisplayer);
            Thread trainThread = new Thread(new ThreadStart(() => train.StartThread()));
            
            var Carlos = new Controller(train, ConsoleKey.D1);

            RefreshScreen();

            Thread clockThread = new Thread(new ThreadStart(() => timeKeeper.StartTime(null)));
            Thread controllerThread = new Thread(new ThreadStart(() => Carlos.ControlTrain()));
            clockThread.Start();
            trainThread.Start();
            controllerThread.Start();


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
                    if(layer.Drawables[i] != null)
                    ConsoleWriter.Write(layer.Drawables[i]);
                }
            }
        }

    }
}
