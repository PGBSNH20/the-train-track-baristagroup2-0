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
        TrainPlanner ToPlan();
    }

    /*
     *Tåget Behöver: 
     * 
     * List<(string, string)>()
     * 
     * 1, 00:00
     * rail
     * 2, 10:00
     * rail
     * 3, 10:05
     * rail
     * 4, 11:00
     * 
     */

    public class TrainPlanner : ITrainplanner
    {
        public int TimeTableID { get; set; }
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

        public TrainPlanner ToPlan()
        {
            //TODO write to file
            
            Console.WriteLine("You time table have been saved");
            return this;
        }
    }
}
