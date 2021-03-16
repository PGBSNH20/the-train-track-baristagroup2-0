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
        public void ConvertStationTimes(List<(string StationID, string Time)> timesAndPlaces) 
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
            string clearLine = "\r" + new string(' ', Console.WindowWidth) + "\r";
            
            while (true)
            {
                if (Program.Clock.Ticks >= Route[^1].Ticks)
                {
                    Index = Route.Count - 1;
                    ConsoleWriter.ReplaceWithColor(Route[Index].Part, ConsoleColor.Green);
                    Console.SetCursorPosition(0, 10);
                    Console.Write(clearLine);
                    Console.Write($"Train has arrived at end station.");
                    return;
                }
                
                if (Program.Clock.Ticks > Route[Index + 1].Ticks)
                {
                    Index++;
                    ConsoleWriter.ReplaceWithColor(Route[Index].Part, ConsoleColor.Green);
                    Console.SetCursorPosition(0, 10);
                    if(Index < Route.Count - 2)
                    {
                        Console.Write(clearLine);
                        Console.Write($"Train has reached station {this.Route[Index].Part.Char.ToString()}. Next stop, station {(int)Char.GetNumericValue(this.Route[Index].Part.Char) + 1}!");
                    }
                    
                }
                if(Index == 0)
                {
                    ConsoleWriter.ReplaceWithColor(Route[Index].Part, ConsoleColor.Green);
                    Thread.Sleep(300);
                    Console.SetCursorPosition(0, 10);
                    Console.Write(clearLine);
                    Console.Write($"Train departing from station {this.Route[Index].Part.Char.ToString()}");
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