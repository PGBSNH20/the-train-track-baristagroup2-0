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

            var partData = TrainTrackReader.Read(File.ReadAllLines(simpleTrackPath));
            var railParts = RailwayPartGenerator.Generate(partData);
            RailwayAssembler.Assemble(railParts);
            ConsoleWriter.WriteRailway();



            Console.ReadLine();
        }
    }
}
