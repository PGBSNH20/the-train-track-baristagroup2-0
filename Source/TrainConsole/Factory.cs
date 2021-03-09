using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public class Factory

    {
        public static ITrain BuildTrain(int id, string name, int maxSpeed, bool operated)
        {
            return new Train() { Id = id, Name = name, MaxSpeed = maxSpeed, Operated = operated };
        }

        public static IStation BuildStation(int id, string stationName, bool endStation )
        {
            return new Station() { Id = id, StationName = stationName, EndStation = endStation};
        }
    }

    public interface IStation
    {
        public int Id { get; set; }
        public string StationName { get; set; }
        public bool EndStation { get; set; }
    }

    public interface ITrain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxSpeed { get; set; }
        public bool Operated { get; set; }
    }
}
