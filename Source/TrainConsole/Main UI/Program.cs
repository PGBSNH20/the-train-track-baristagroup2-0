using System;
using System.IO;
using System.Threading;

namespace TrainConsole
{
    class Program
    {
        public static string advancedTrackPath = @"TextFiles\traintrack.txt";
        public static string simpleTrackPath = @"TextFiles\simpleTrack.txt";
        static void Main(string[] args)
        {
            Console.CursorVisible = true;
            //var partData = TrainTrackReader.Read(File.ReadAllLines(advancedTrackPath));
            //var railParts = RailwayPartsORM.Map(partData);
            //RailwayAssembler.Assemble(railParts);
            //ScreenMemoryLayer.AppendRailwayDrawables();
            var clock = new TwentyFourHourClock();
            var timeDisplay = new TimeDisplayer(0, 0);
            var timeKeeper = new TimeKeeper(clock, timeDisplay, 200);

            //var clock2 = new TwentyFourHourClock();
            //var timeDisplay2 = new TimeDisplayer(0, 1);
            //var timeKeeper2 = new TimeKeeper(clock2, timeDisplay2, 400);

            Thread thread = new Thread(new ThreadStart(() => timeKeeper.StartTime(RefreshScreen)));
            //Thread thread2 = new Thread(new ThreadStart(() => timeKeeper2.StartTime(null)));
            thread.Start();
            //thread2.Start();
            //while (true)
            //{
            //    RefreshScreen();
            //}
            //timeDisplay.ToMemoryLayer();
            //RefreshScreen();


            Console.ReadLine();
        }
        public static void RefreshScreen()
        {
            foreach (var drawable in RailwayMemoryLayer.Drawables)
                ConsoleWriter.Write(drawable);
        }
    }
}
