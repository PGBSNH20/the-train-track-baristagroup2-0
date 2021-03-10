using System;
using System.IO;

namespace TrainConsole
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("Train track!");
            var partData = TrainTrackReader.Read();
            var railParts = RailwayPartGenerator.Generate(partData);
            RailwayAssembler.Assemble(railParts);

            ConsoleWriter.Write(partData);
            Console.ReadLine();

            // Step 1:
            // Parse the traintrack (Data/traintrack.txt) using ORM (see suggested code)
            // Parse the trains (Data/trains.txt)

            // Step 2:
            // Make the trains run in treads
        }
    }
}
