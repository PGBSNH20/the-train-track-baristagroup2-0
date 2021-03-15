using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace FirstLevelRailway
{
    public class Train
    {
        private Thread trainThread;
        private int trainSpeed;
        private int distanceToGoal;

        public Train(int trainSpeed)
        {
            this.trainSpeed = trainSpeed;
            //this.distanceToGoal = distanceToGoal;
        }

        interface ITrain
        {
            void Start();
            void Stop();

        }
        
        //public static List<Train> GenerateFrom(List<(string Train, string Call)> trainCalls)
        //{
        //    var trains = new List<Train>();

        //    foreach (var trainCall in trainCalls)
        //    {
        //        if (!trains.Exists(x => x.Name == trainCall.Train))
        //        {
        //            var newTrain = new Train() { Name = trainCall.Train };
        //            trains.Add(newTrain);
        //        }
        //        var trainToEdit = trains.Find(x => x.Name == trainCall.Train);
        //        trainToEdit.Route.Add(trainCall.Call);
        //    }
        //    return trains;
        //}
        //public int Position { get; set; } = 0;
        //public List<string> Route { get; set; } = new List<string>();
        //public string Name { get; set; }
        //public void Move()
        //{
        //    Console.WriteLine($"{ Name }: {Route[Position]}");
        //    Position++;
        //}


    }
}