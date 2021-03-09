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
            var secondStation = bulider.BuildStation("Alingsås", true);
            bulider.BuildRail(firstStation, secondStation);
            var railway = bulider.Build();

            var vasttåg = Factory.BuildTrain(5, "Västtåg", 120, false);
            


            var plan = new TrainPlanner(vasttåg)
                
                .StartTrainAt("kl 10:00")
                .StopTrainAt("kl 13:00")
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
