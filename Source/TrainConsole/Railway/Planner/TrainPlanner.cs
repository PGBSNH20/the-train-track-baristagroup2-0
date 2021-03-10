using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{


    public class TrainPlanner 
    {
        private ITrain Train { get; set; }
        private List<Stop> Stops { get; set; }
        public TrainPlanner(ITrain train)
        {
            this.Train = train;
        }
        public TrainPlanner FollowSchedule(TimeTable timeTable)
        {
            //TODO: use timetable reader
            return this;
        }
        public TrainPlanner AddStop(string arrivalTime, string departureTime, IStation station)
        {
            var stop = new Stop()
            {
                ArrivalTime = arrivalTime,
                DepartureTime = departureTime,
                Station = station
            };
            Stops.Add(stop);
            return this;
        }
        public ITrain SendToTrain()
        {
            Train.Stops = this.Stops;
            return this.Train;
        }
    }
}
