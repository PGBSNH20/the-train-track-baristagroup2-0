using System;
using System.Collections.Generic;
using System.Threading;

namespace TrainConsole
{
    public class Train
    {
        public int Speed_km_per_hour { get; set; } //Every part is 10km
        public TrainDisplayer trainDisplayer { get; set; }
        public IClock Clock { get; set; }
        public List<IRailwayPart> Route { get; set; }
        public int RouteIndex { get; set; } = 0;

        public bool IsStopped = true;
        public Train(IClock clock, List<IRailwayPart> route, int speed_km_per_hour, TrainDisplayer trainDisplayer)
        {
            Speed_km_per_hour = speed_km_per_hour;
            Clock = clock;
            Route = route;
            this.trainDisplayer = trainDisplayer;
        }
        public void StartThread(int timeDriven = 0)
        {
            int startTime = Clock.Ticks - timeDriven;
            trainDisplayer.Display(Route, RouteIndex);
            while (RouteIndex < Route.Count - 1)
            {
                if (IsStopped == true)
                {
                    timeDriven = Clock.Ticks - startTime;
                    while (IsStopped)
                        Thread.Sleep(200);
                    StartThread(timeDriven);
                }
                int driveTime = (Clock.Ticks - startTime);
                double partsPerMin = (Speed_km_per_hour / 60.0) / Railway.PartLength_km;
                double partsDriven = driveTime * partsPerMin;
                int index = (int)Math.Floor(partsDriven);
                if (index >= Route.Count)
                    return;
                if (RouteIndex < index)
                {
                    RouteIndex = index;
                    trainDisplayer.Display(Route, index);
                    if (Route[index].GetType() == typeof(Station))
                    {
                        timeDriven = Clock.Ticks - startTime;
                        Thread.Sleep(500);
                    }
                }
                Thread.Sleep(200);
            }
        }
    }
}

