using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public class TrainPlanner : IPlannerSchedule
    {
        public TrainPlanner(Train train)
        {
            this.train = train;
        }
        public Train train { get; set; }

        public IPlannerSchedule FollowSchedule(TimeTable schedule)
        {
            return this;
        }
        public IPlannerSchedule StartTrainAt(string startTime)
        {
            Console.WriteLine(startTime);
            return this;
        }
        public IPlannerSchedule StopTrainAt(string stopTime)
        {
            Console.WriteLine(stopTime);
            return this;
        }
        public TrainPlan ToPlan()
        {
            return new TrainPlan();
        }

    }
    public interface IPlannerSchedule 
    {
        public IPlannerSchedule StartTrainAt(string startTime);
        public IPlannerSchedule StopTrainAt(string stopTime);
        public TrainPlan ToPlan();
    }
}
