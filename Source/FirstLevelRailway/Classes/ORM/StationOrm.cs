using System.Collections.Generic;
using System.IO;

namespace FirstLevelRailway
{
    public class StationORM
    { 
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
