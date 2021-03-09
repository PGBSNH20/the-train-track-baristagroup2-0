using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public static class TimeTableLoader
    {
        public static void Load(string timeTableFilePath)
        {
            //var timeTable = new List<TimeTable>();
            string[] lines = File.ReadAllLines(timeTableFilePath);

            var timeTables = new List<TimeTable>();
            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                var trainId = int.Parse(parts[0]);

                if (timeTables.TrueForAll(x => x.TrainId != trainId))
                {
                    var newTable = new TimeTable() { TrainId = trainId };
                    timeTables.Add(newTable);
                }
            }

            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                var trainId = int.Parse(parts[0]);
                var timeTable = timeTables.Find(x => x.TrainId == trainId);

                timeTable.Stops.Add(new Stop()
                {
                    Station = (Station)Railway.GetPartFromId(int.Parse(parts[1])),
                    DepartureTime = parts[2],
                    ArrivalTime = parts[3]
                }); ;
            }
            Railway.timeTables.AddRange(timeTables);
        }
    }
}
