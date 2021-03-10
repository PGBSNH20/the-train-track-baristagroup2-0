using System;
using System.Collections.Generic;
using System.Text;

namespace FirstLevelRailway
{
    public interface ITrainplanner
    {
        ITrainplanner FollowSchedule(TrainPlanner timeTable);
        ITrainplanner StartTrainAt(string departureStation, string startTime);
        ITrainplanner ArriveTrainAt(string arriveAtStation, string arrivalTime);
        ITrainplanner GeneratePlan();
    }

    public class TrainPlanner : ITrainplanner
    {
        public string DepartureAt;
        public string StartTime { get; set; }
        public string ArriveAtStation { get; set; }
        public string ArrivalTime { get; set; }

        public ITrainplanner StartTrainAt(string departureStation, string startTime)
        {
            new TrainPlanner() { DepartureAt = departureStation, StartTime = startTime };
            return this;
        }
        public ITrainplanner ArriveTrainAt(string arriveAtStation, string time)
        {
            new TrainPlanner() { ArriveAtStation = arriveAtStation, ArrivalTime = time };
            return this;
        }

        public ITrainplanner FollowSchedule(TrainPlanner timeTable)
        {
            throw new NotImplementedException();
        }

        public ITrainplanner GeneratePlan()
        {
            Console.WriteLine("You time table have been saved");

            // trainplan.save();
            return this;
        }
    }
}
