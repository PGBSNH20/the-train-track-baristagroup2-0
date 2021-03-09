using System;
using System.IO;

namespace TrainConsole
{
    class Program
    {
     
        static void Main(string[] args)
        {
        
            Console.WriteLine("Train track!");

            var bulider = new RailwayBuilder();
            var firstStation = bulider.BuildStation("Gothenburg", true);
            var endStation = bulider.BuildStation("Alingsås", true);
            bulider.BuildRail(firstStation, endStation);

            var vasttåg = Factory.BuildTrain(5, "Västtåg", 120, false, currentPosition: firstStation);

            var plan = new TrainPlanner(vasttåg)
                .AddStop("11:00", firstStation)
                .AddStop("11:30", endStation)
                .ToPlan();



            Console.ReadLine();

            // Step 1:
            // Parse the traintrack (Data/traintrack.txt) using ORM (see suggested code)
            // Parse the trains (Data/trains.txt)

            // Step 2:
            // Make the trains run in treads
        }
    }
}
