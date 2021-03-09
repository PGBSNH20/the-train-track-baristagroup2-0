using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
   public class file
    {

        static string timeTableFilePath = @"TextFiles\timetable.txt";
        static string trainsFilePath = @"TextFiles\trains.txt";
        static string stationsFilePath = @"TextFiles\stations.txt";
        //public static string passengerFilePath = @"TextFiles\passengers.txt";

        public List<TimeTable> filePathTimeTable(string filePath)
        {
             var timeTable = new List<TimeTable>();
             string[] lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                string[] parts = line.Split(',');

                var trainTimeTable = new TimeTable
                {
                    TrainId = int.Parse(parts[0]),
                    StationId = int.Parse(parts[1]),
                    DepartureTime = parts[2],
                    ArrivalTime = parts [3]
                };
                timeTable.Add(trainTimeTable);
            }
            return timeTable;
        }
     
    }
}
