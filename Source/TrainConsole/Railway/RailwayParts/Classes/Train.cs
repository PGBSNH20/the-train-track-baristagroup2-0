using System.Collections.Generic;
using System.Threading;

namespace TrainConsole
{
    public class Train
    {
        public int Speed_TickPerPart { get; set; }
        public TrainDisplayer trainDisplayer { get; set; }
        public IClock Clock { get; set; }
        public List<IRailwayPart> Route { get; set; }
        public int RouteIndex { get => RouteIndex; set 
            {
                trainDisplayer.Display(Route, value);
                RouteIndex = value;
            } }
        public Train(IClock clock, List<IRailwayPart> route, int speed_TickPerPart, int routeIndex = 0)
        {
            Speed_TickPerPart = speed_TickPerPart;
            Clock = clock;
            Route = route;
            RouteIndex = routeIndex;
        }
        public void StartThread()
        {
            int startTime = Clock.Ticks;
            while (true)
            {
                int index = (Clock.Ticks - startTime) / Speed_TickPerPart;
                if (RouteIndex < index)
                {
                    RouteIndex = index;
                }
                Thread.Sleep(100);
            }
        }
    }
}

