﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public static class RailwayPartGenerator
    {
        public static List<IRailwayPart> Generate(List<(char chr, int X, int Y)> CharCoordinates)
        {
            var railwayParts = new List<IRailwayPart>();

            foreach (var charCoord in CharCoordinates)
            {
                if (TrainTrackReader.RailChars.Contains(charCoord.chr))
                {
                    var newRail = Factory.AddRail();
                    AddCharCoordParams(newRail, charCoord);
                    railwayParts.Add(newRail);
                }
                if (TrainTrackReader.StationChars.Contains(charCoord.chr))
                {
                    var newStation = Factory.AddStation();
                    AddCharCoordParams(newStation, charCoord);
                    railwayParts.Add(newStation);
                }
                if (TrainTrackReader.CrossingChar == charCoord.chr)
                {
                    var newCrossing = Factory.AddCrossing();
                    AddCharCoordParams(newCrossing, charCoord);
                    railwayParts.Add(newCrossing);
                }
                if (TrainTrackReader.SwitchChars.Contains(charCoord.chr))
                {
                    var newSwitch = Factory.AddSwitch();
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
