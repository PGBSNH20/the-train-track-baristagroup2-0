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
     * List<int,string>()
     * 
     * 1 : 00:00
     * 1 : 08:00
     * 2 : 10:00
     * 2 : 10:05
     * 3 : 11:00
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

        public void createStationTimeList()
        {
            var hejsan = new TimeTableORM(@"../../../firstleveltimetable.txt");
            hejsan.Load(1);
            for (int i = 0; i < hejsan.TimeTables.Count; i++)
            {
                stationTimeList.Add((hejsan.TimeTables[i].DepatureStationID, hejsan.TimeTables[i].DepartureTime)); //departure
                stationTimeList.Add((hejsan.TimeTables[i].ArrivalStationID, hejsan.TimeTables[i].ArrivalTime)); //arrival
            }
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
