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

        public static string timeTableFilePath = @"TextFiles\timetable.txt";
        public static string trainsFilePath = @"TextFiles\trains.txt";
        public static string stationsFilePath = @"TextFiles\stations.txt";
        //public static string passengerFilePath = @"TextFiles\passengers.txt";

        public List<TimeTable> filePathTimeTable(string timeTableFilePath)
        {
             var timeTable = new List<TimeTable>();
             string[] lines = File.ReadAllLines(timeTableFilePath);

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
        public List<Train> filePathTrains(string trainsFilePath)
        {
            var trainList = new List<Train>();
            string[] lines = File.ReadAllLines(trainsFilePath);

            foreach (var line in lines)
            {
                string[] parts = line.Split(',');

                var trainsInList = new Train
                {
                    Id = int.Parse(parts[0]),
                    Name = parts[1],
                    MaxSpeed = int.Parse(parts[2]),
                    Operated = bool.Parse(parts[3])
                };
                trainList.Add(trainsInList);
            }
            return trainList;
        }
        public List<Station> filePathStations(string stationsFilePath)
        {
            var stationList = new List<Station>();
            string[] lines = File.ReadAllLines(stationsFilePath);

            foreach (var line in lines)
            {
                string[] parts = line.Split(',');

                var stationsInList = new Station
                {
                    Id = int.Parse(lines[0]),
                    StationName = lines[1],
                    EndStation = bool.Parse(lines[2])
                };
                stationList.Add(stationsInList);
            }
            return stationList;
        }

    }
}
