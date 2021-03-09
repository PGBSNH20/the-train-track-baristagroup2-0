using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public class Stop
    {
        public Station Station { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
    }

    public class TimeTable
    {
        public int TrainId { get; set; }
        public List<Stop> Stops { get; set; }

        //public int StationId { get; set; }
        //public string DepartureTime { get; set; }
        //public string ArrivalTime { get; set; }

        public TimeTable StartTrainAt(string startTime)
        {
            Console.WriteLine(startTime);
            return this;
        }
        public TimeTable StopTrainAt(string stopTime)
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

