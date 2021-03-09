using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public class Factory
    {
        public static IRail BuildRail(int id, IEndPoint endPointA, IEndPoint endPointB)
        {
            return new Rail() { Id = id, EndPointA = endPointA, EndPointB = endPointB };
        }
        public static ITrain BuildTrain(int id, string name, int maxSpeed, bool operated, IRailwayPart currentPosition)
        {
            return new Train() { Id = id, Name = name, MaxSpeed = maxSpeed, Operated = operated, CurrentPosition = currentPosition};
        }

        public static IStation BuildStation(int id, string stationName, bool endStation )
        {
            return new Station() { Id = id, StationName = stationName, EndStation = endStation};
        }
    }
}
