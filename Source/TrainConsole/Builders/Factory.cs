using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public class Factory
    {
        public static ITrain AddTrain(int? id = null, string name = null)
        {
            var train = new Train();
            if (name != null)
                train.Name = name;

            Railway.SetIdAddId(id, train);
            Railway.RailwayItems.Add(train);

            return train;
        }
        public static IStation AddStation(int? id = null, string name = null)
        {
            var station = new Station();
            if (name != null)
                station.Name = name;
            Railway.SetIdAddId(id, station);
            Railway.RailwayItems.Add(station);

            return station;
        }
        public static IRail AddRail(int? id = null, List<IRailwayPart> connections = null)
        {
            var rail = new Rail { Connections = new List<IRailwayPart>() };
            if (connections != null)
                rail.Connections.AddRange(connections);
            Railway.SetIdAddId(id, rail);
            return rail;
        }
        public static IRailSwitch AddSwitch(int? id = null, List<IRailwayPart> connections = null)
        {
            var railSwitch = new RailSwitch { Connections = new List<IRailwayPart>() };
            if (connections != null)
                railSwitch.Connections.AddRange(connections);
            Railway.SetIdAddId(id, railSwitch);
            return railSwitch;
        }
        public static ICrossing AddCrossing(int? id = null, List<IRailwayPart> connections = null)
        {
            var crossing = new Crossing { Connections = new List<IRailwayPart>() };
            if (connections != null)
                crossing.Connections.AddRange(connections);
            Railway.SetIdAddId(id, crossing);
            return crossing;
        }
    }
}
