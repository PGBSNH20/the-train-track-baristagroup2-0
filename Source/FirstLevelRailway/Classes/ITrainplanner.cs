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
        ITrainplanner ToPlan();
    }

    public class TrainPlanner : ITrainplanner
    {
        public Train Train { get; }
        public string DepartureAtStation;
        public string StartTime { get; set; }
        public string ArriveAtStation { get; set; }
        public string ArrivalTime { get; set; }

        public TrainPlanner(Train train)
        {
            Train = train;
        }

        public ITrainplanner StartTrainAt(string departureStation, string startTime)
        {
            DepartureAtStation = departureStation;
            StartTime = startTime;
            return this;
        }
        public ITrainplanner ArriveTrainAt(string arriveAtStation, string time)
        {
            ArriveAtStation = arriveAtStation;
            ArrivalTime = time; 
            return this;
        }

        public ITrainplanner FollowSchedule(TrainPlanner timeTable)
        {
            throw new NotImplementedException();
        }

        public ITrainplanner ToPlan()
        {
            //TODO write to file
            Console.WriteLine("You time table have been saved");
            return this;
        }
    }
}
