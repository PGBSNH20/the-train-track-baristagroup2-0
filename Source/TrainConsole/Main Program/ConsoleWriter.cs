﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TrainConsole
{
   public static class ConsoleWriter
    {
        public static void Write(params (char chr, int X, int Y)[] charCoords)
        {
            foreach(var chrCoord in charCoords)
            {
                Console.SetCursorPosition(chrCoord.X, chrCoord.Y);
                Console.Write(chrCoord.chr);
            }
        }
        public static void WriteRailway()
        {
            var railwayItems = Railway.RailwayItems;
            foreach(var item in railwayItems)
            {
                Write(GetCharCoordFromItem(item));
            }
        }
        private static (char chr, int X, int Y) GetCharCoordFromItem(IRailwayItem item)
            => (item.Char, item.CoordinateX, item.CoordinateY);
    }
}
