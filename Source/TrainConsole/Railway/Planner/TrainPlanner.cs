using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{


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
        public TrainPlanner AddStop(string departureTime, IStation station)
        {
            trainPlan.stationStop.Add(station, departureTime);
            return this;
        }
        public TrainPlan ToPlan()
        {
            return this.trainPlan;
        }
    }
}
