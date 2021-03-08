using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public class TrainPlanner 
    {
        public TimeTable timeTable { get; private set; }


        public TrainPlanner(Train train)
        {
            this.train = train;
        }
        public Train train { get; set; }

        public IPlannerSchedule FollowSchedule(TimeTable timeTable)
        {
            
            return timeTable;
        }
     

    }
    public interface IPlannerSchedule 
    {
        public IPlannerSchedule StartTrainAt(string startTime);
        public IPlannerSchedule StopTrainAt(string stopTime);
        public TimeTable ToPlan();
    }
}
