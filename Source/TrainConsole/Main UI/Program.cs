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
            var timeKeeper = new TimeKeeper(clock, timeDisplay, 200);

            var read = TrainTrackReader.Read(File.ReadAllLines(simpleTrackPath));
            var parts = RailwayPartsORM.Map(read);

            RailwayAssembler.Assemble(parts);
            railwayLayer.AppendRailwayDrawables();

            Thread clockThread = new Thread(new ThreadStart(() => timeKeeper.StartTime(null)));

            clockThread.Start();

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
