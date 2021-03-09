using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole 
{
    
    public class TimeTable : IPlannerSchedule
    {
        public int TrainId { get; set; }
        public int StationId { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }

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

        public TimeTable ToPlan()
        {
            return new TimeTable();
        }
    }
}

