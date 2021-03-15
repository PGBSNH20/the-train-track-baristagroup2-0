using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainConsole
{
    public static class RouteTracker
    {
        public static List<IRailwayPart> Track(IRailwayPart start, IRailwayPart end)
        {

            var currentRoute = new List<IRailwayPart>();
            var yConnections = new List<IRailwayPart>();
            var currentPart = start;
            int tryIndex = 0;


            while(true)
            {
                currentRoute.Add(currentPart);
                var connections = currentPart.Connections;
                var options = connections.Except(currentRoute).ToList();

                if (options.Count == 0)
                {

                    tryIndex++;
                    if (tryIndex >1)
                    {
                        return currentRoute;
                    }
                    currentPart = start;
                    currentRoute.Clear();
                    continue;
                }
                if (options.Contains(end))
                {
                    currentRoute.Add(end);
                    return currentRoute;
                }
                if (options.Count == 2)
                {
                    currentPart = options[tryIndex];
                    continue;
                }
                currentPart = options[0];

            }

        }
    }
}
