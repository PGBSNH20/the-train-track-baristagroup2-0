using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace FirstLevelRailway
{
    public class Train
    {
        public string Name { get; set; }
        public List<(IRailwayPart Part, int Ticks)> Route { get; set; }
        public int Index { get; private set; } = 0;
        public void ConvertTimes(List<(string StationID, string Time)> timesAndPlaces) 
        { 
            var route = new List<(IRailwayPart Part, int Ticks)>(); 
            foreach(var tp in timesAndPlaces)
            {
                var part = Railway.RailwayParts.Find(x => x.Char.ToString() == tp.StationID);
                var tick = (TwentyFourHourClock.TimeToTicks(tp.Time));
                route.Add((part, tick));
            }
            Route = route;
        }
        public void RunTrain(bool endlessLoop = true, int sleep = 400)
        {            
            while (true)
            {
                if (Program.Clock.Ticks >= Route[^1].Ticks)
                { 
                    Index = Route.Count - 1;
                    ConsoleWriter.ReplaceWithColor(Route[Index].Part, ConsoleColor.Green);
                    return;
                }
                
                if (Program.Clock.Ticks > Route[Index + 1].Ticks)
                {
                    Index++;
                    ConsoleWriter.ReplaceWithColor(Route[Index].Part, ConsoleColor.Green);
                }
                if(Index == 0)
                {
                    ConsoleWriter.ReplaceWithColor(Route[Index].Part, ConsoleColor.Green);
                }

                if (endlessLoop == false) return;
                else
                {
                    Thread.Sleep(sleep);
                }
            }
        }
    }
}