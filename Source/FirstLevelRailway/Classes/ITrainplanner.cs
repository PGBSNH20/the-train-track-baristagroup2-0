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
        public int TimeTableID { get; }
        public string DepartureAtStation;
        public string StartTime { get; set; }
        public string ArriveAtStation { get; set; }
        public string ArrivalTime { get; set; }

        public TrainPlanner(int timeTableID)
        {
            TimeTableID = timeTableID;
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
            //tåg som ska följa given tabell
            throw new NotImplementedException();
        }

        public ITrainplanner ToPlan()
        {
            
            Console.WriteLine("You time table have been saved");
            return this;
        }
    }
}
