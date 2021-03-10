using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public class Factory
    {
        public static ITrain AddTrain(int? id, string name, int maxSpeed, bool operated, IRailwayPart currentPosition)
        {
            var train = new Train() {Name = name, MaxSpeed = maxSpeed, Operated = operated, CurrentLocation = currentPosition};
            Railway.SetIdAddId(id, train);
            Railway.RailwayItems.Add(train);

            return train;
        }
        public static IStation AddStation(int? id, string stationName)
        {
            var station = new Station() { StationName = stationName};
            Railway.SetIdAddId(id, station);
            Railway.RailwayItems.Add(station);

            return station;
        }
        public static IRail AddRail(int? id, IRailwayPart A, IRailwayPart B)
        {
            var rail = new Rail { Connections = new List<IRailwayPart>() { A, B } };
            Railway.SetIdAddId(id, rail);
            return rail;
        }
    }
}
