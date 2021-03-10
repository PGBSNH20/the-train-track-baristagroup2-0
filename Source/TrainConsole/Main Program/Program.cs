using System;
using System.IO;

namespace TrainConsole
{
    class Program
    {
     
        static void Main(string[] args)
        {
        
            Console.WriteLine("Train track!");

            var AlingsasC = Factory.AddStation(null, "Alingsas Centralstation");
            var GoteborgC = Factory.AddStation(null, "Goteborg Centralstation");

            new RailwayEngineer()
                .Connect(AlingsasC)
                .Connect(GoteborgC)
                .Build();

            



            Console.ReadLine();

            // Step 1:
            // Parse the traintrack (Data/traintrack.txt) using ORM (see suggested code)
            // Parse the trains (Data/trains.txt)

            // Step 2:
            // Make the trains run in treads
        }
    }
}
