using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstLevelRailway
{
    public static class RouteDivider
    {
        public static void AddTimedRails(Train train)
        {
            var stations = train.Route.Select(x => x.Part).ToList();
            var newRouteList = new List<(IRailwayPart part, int ticks)>();

            for (int i = 0; i < stations.Count-1; i++)
            {
                newRouteList.Add(train.Route[0]);
                var newList = GetRailsRightOf((Station)stations[i]);

                double divide = newList.Count + 1.0;
                int ticksStation1 = train.Route[i].Ticks;
                int tickStation2 = train.Route[i+1].Ticks;

                double railIncrement = (tickStation2 - ticksStation1) / divide;

                double add = 0;
                foreach (var rail in newList)
                {
                    add += railIncrement;
                    newRouteList.Add((rail, (int)Math.Floor(add)));
                }
            }
            train.Route = newRouteList;
        }
        private static List<IRailwayPart> GetRailsRightOf(Station stationA)
        {

            bool isRunning = true;
            var rails = new List<IRailwayPart>();
            int x = 1;
            int amountRail = 0;

            while (isRunning)
            {
                int nextX = stationA.CoordinateX + x;
                var partToRight = Railway.RailwayParts.Find(x => x.CoordinateX == nextX);
                if (partToRight.GetType() == typeof(Station))
                {
                    isRunning = false;
                }
                else
                {
                    amountRail++;
                    x++;
                    rails.Add(partToRight);
                }
            }
            return rails;
        }
    }
}