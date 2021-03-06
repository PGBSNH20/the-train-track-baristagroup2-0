using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstLevelRailway
{
    public static class RailwayPartsORM
    {
        public static char[] SwitchChars = new char[] { '<', '>' };
        public static char CrossingChar = '=';
        public static char[] RailChars = new char[] { '-', '/', '\\', '[', ']' };
        public static char[] StationChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public static List<IRailwayPart> Map(List<(char chr, int X, int Y)> CharCoordinates)
        {
            var railwayParts = new List<IRailwayPart>();
            var railwayChars = SwitchChars.ToList();
            railwayChars.AddRange(RailChars);
            railwayChars.Add(CrossingChar);
            railwayChars.AddRange(StationChars);

            foreach (var charCoord in CharCoordinates)
            {
                if (RailChars.Contains(charCoord.chr))
                {
                    var newRail = new Rail();
                    AddCharCoordParams(newRail, charCoord);
                    railwayParts.Add(newRail);
                }
                if (StationChars.Contains(charCoord.chr))
                {
                    var newStation = new Station();
                    AddCharCoordParams(newStation, charCoord);
                    railwayParts.Add(newStation);
                }
                if (CrossingChar == charCoord.chr)
                {
                    var newCrossing = new Crossing();
                    AddCharCoordParams(newCrossing, charCoord);
                    railwayParts.Add(newCrossing);
                }
                if (SwitchChars.Contains(charCoord.chr))
                {
                    var newSwitch = new RailSwitch();
                    AddCharCoordParams(newSwitch, charCoord);
                    railwayParts.Add(newSwitch);
                }
            }
            return railwayParts;
        }
        private static void AddCharCoordParams(IRailwayPart railwayPart, (char chr, int X, int Y) charCoord)
        {
            railwayPart.Char = charCoord.chr;
            railwayPart.CoordinateX = charCoord.X;
            railwayPart.CoordinateY = charCoord.Y;
        }
    }
}
