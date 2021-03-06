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
                string[] parts = line.Split('|');

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
