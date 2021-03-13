using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TrainConsole
{
    public static class ConsoleWriter
    {
        public static void Write(IDrawable drawable)
        {
            if (drawable.IsDrawn == true) return;

            Console.ForegroundColor = drawable.Color;
            Console.SetCursorPosition(drawable.CoordinateX, drawable.CoordinateY);
            Console.Write(drawable.Chars);
            drawable.IsDrawn = true;
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void Write(char chr, (int X, int Y) coord)
        {
            Console.SetCursorPosition(coord.X, coord.Y);
            Console.Write(chr);
        }
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
