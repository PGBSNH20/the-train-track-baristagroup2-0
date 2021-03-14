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

            var clockLayer1 = new ClockMemoryLayer();
            var clockLayer2 = new ClockMemoryLayer();
            var clockLayer3 = new ClockMemoryLayer();
            var railwayLayer = new RailwayMemoryLayer();

            Layers.Add(clockLayer1);
            Layers.Add(clockLayer2);
            Layers.Add(clockLayer3);
            Layers.Add(railwayLayer);

            var clock = new TwentyFourHourClock();
            var timeDisplay = new TimeDisplayer(0, 0, clockLayer1);
            var timeKeeper = new TimeKeeper(clock, timeDisplay, 200);

            var clock2 = new TwentyFourHourClock();
            var timeDisplay2 = new TimeDisplayer(0, 1, clockLayer2);
            var timeKeeper2 = new TimeKeeper(clock2, timeDisplay2, 400);

            var clock3 = new TwentyFourHourClock();
            var timeDisplay3 = new TimeDisplayer(0, 2, clockLayer3);
            var timeKeeper3 = new TimeKeeper(clock3, timeDisplay3, 800);

            var read = TrainTrackReader.Read(File.ReadAllLines(simpleTrackPath));
            var parts = RailwayPartsORM.Map(read);
            RailwayAssembler.Assemble(parts);
            railwayLayer.AppendRailwayDrawables();

            Thread thread = new Thread(new ThreadStart(() => timeKeeper.StartTime(null)));
            Thread thread2 = new Thread(new ThreadStart(() => timeKeeper2.StartTime(null)));
            Thread thread3 = new Thread(new ThreadStart(() => timeKeeper3.StartTime(null)));

            thread.Start();
            thread2.Start();
            thread3.Start();

            while (true)
            {
                Thread.Sleep(100);
                RefreshScreen();
            }

            Console.ReadLine();
        }
        public static void RefreshScreen()
        {
            foreach (var layer in Layers)
                foreach (var drawable in layer.Drawables)
                    ConsoleWriter.Write(drawable);
        }
    }
}
