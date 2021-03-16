using System;
using System.Collections.Generic;
using System.Text;

namespace FirstLevelRailway
{

    public interface ITrainplanner
    {
        ITrainplanner StartTrainAt(string departureStation, string startTime);
        ITrainplanner ArriveTrainAt(string arriveAtStation, string arrivalTime);
        TrainPlanner ToPlan();
    }
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
                stationTimeList.Add((stationORM.TimeTables[i].DepatureStationID, stationORM.TimeTables[i].DepartureTime));
                stationTimeList.Add((stationORM.TimeTables[i].ArrivalStationID, stationORM.TimeTables[i].ArrivalTime));
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
        public TrainPlanner ToPlan()
        {
            //Console.WriteLine("You time table have been saved");
            return this;
        }
    }
}
