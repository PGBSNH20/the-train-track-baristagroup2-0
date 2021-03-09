using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public interface ITrainPlan
    {
        public ITrain train { get; set; }
        public TimeTable timeTable { get; set; }

        //public List<(int StationId, string DepatureTime, string ArrivalTime)> StationTimes { get; set; }
        public void Save(string filePath);
        public void Load(string filePath);
    }
    public class TrainPlan : ITrainPlan
    {
        public ITrain train { get; set; }
        public TimeTable timeTable { get; set; }

        //public List<(int StationId, string DepatureTime, string ArrivalTime)> StationTimes { get; set; }
        public void Save(string filePath) { }
        public void Load(string filePath) { }
    }
    public class TrainPlanner 
    {
        private TrainPlan trainPlan = new TrainPlan();

        public TrainPlanner(ITrain train)
        {
            this.trainPlan.train = train;
        }
        public TrainPlanner FollowSchedule(TimeTable timeTable)
        {
            return this;
        }
        public TrainPlanner StartTrainAt(string startTime)
        {
            return this;
        }
        public TrainPlanner StopTrainAt(string stopTime)
        {
            return this;
        }
        public TrainPlan ToPlan()
        {
            return this.trainPlan;
        }
    }
}
