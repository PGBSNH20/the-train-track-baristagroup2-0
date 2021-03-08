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

        public TrainPlanner FollowSchedule()
        {
            
        }
    }
    public interface IPlannerSchedule 
    {
        public TrainPlanner FollowSchedule();
    }
}
