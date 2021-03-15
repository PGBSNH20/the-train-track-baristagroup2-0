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
        public void StopAtStation()
        {
            Thread.Sleep(500);
            StartThread();
        }
        public void StartThread()
        {
            int startTime = Clock.Ticks;
            trainDisplayer.Display(Route, RouteIndex);

            while (RouteIndex < Route.Count - 1)
            {
                if (IsStopped == true)
                {
                    while (IsStopped)
                    {
                        Thread.Sleep(200);
                    }
                    StartThread();
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
                        StopAtStation();
                    }
                }
                Thread.Sleep(200);
            }
        }
    }
}

