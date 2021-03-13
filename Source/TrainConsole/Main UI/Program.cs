using System;
using System.IO;

namespace TrainConsole
{
    class Program
    {
        public static string advancedTrackPath = @"TextFiles\traintrack.txt";
        public static string simpleTrackPath = @"TextFiles\simpleTrack.txt";
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            var partData = TrainTrackReader.Read(File.ReadAllLines(advancedTrackPath));
            var railParts = RailwayPartsORM.Map(partData);
            RailwayAssembler.Assemble(railParts);
            ScreenMemoryLayer.AppendRailwayDrawables();
            RefreshScreen();


            Console.ReadLine();
        }
        public static void RefreshScreen()
        {
            foreach (var drawable in ScreenMemoryLayer.Drawables)
                ConsoleWriter.Write(drawable);
        }
    }
}
