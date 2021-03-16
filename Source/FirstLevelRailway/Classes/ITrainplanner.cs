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
        public List<(string, string)> stationTimeList = new List<(string, string)>() { };
        public int TimeTableID { get; set; }
        public string DepatureStationID;
        public string DepartureTime { get; set; }
        public string ArrivalStationID { get; set; }
        public string ArrivalTime { get; set; }

        public TrainPlanner(int timeTableID)
        {
            TimeTableID = timeTableID;
        }

        public List<(string, string)> createStationTimeList()
        {
            List<(string, string)> stationTimeList = new List<(string, string)>() { };
            var stationORM = new TimeTableORM();
            stationORM.Load(1);
            for (int i = 0; i < stationORM.TimeTables.Count; i++)
            {
                stationTimeList.Add((stationORM.TimeTables[i].DepatureStationID, stationORM.TimeTables[i].DepartureTime)); //departure
                stationTimeList.Add((stationORM.TimeTables[i].ArrivalStationID, stationORM.TimeTables[i].ArrivalTime)); //arrival
            }
            return stationTimeList;
        }

        public ITrainplanner StartTrainAt(string departureStation, string startTime)
        {
            DepatureStationID = departureStation;
            DepartureTime = startTime;
            return this;
        }
        public ITrainplanner ArriveTrainAt(string arriveAtStation, string time)
        {
            ArrivalStationID = arriveAtStation;
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
