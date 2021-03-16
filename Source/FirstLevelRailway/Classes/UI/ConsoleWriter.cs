using System;
using System.Collections.Generic;

namespace FirstLevelRailway
{
    public static class ConsoleWriter
    {
        public static void Write(char chr, (int X, int Y) coord)
        {
            Console.SetCursorPosition(coord.X, coord.Y);
            Console.Write(chr);
        }
        public static void Write(List<(char chr, int X, int Y)> charCoords)
        {
            foreach (var coord in charCoords)
            {
                Console.SetCursorPosition(coord.X, coord.Y);
                Console.Write(coord.chr);
            }
        }
        public static void WriteParts(List<IRailwayPart> parts)
        {
            foreach (var part in parts)
            {
                Console.SetCursorPosition(part.CoordinateX, part.CoordinateY);
                Console.Write(part.Char);
            }
            Console.SetCursorPosition(0, 10);

        }
        public static void Write(IDrawable drawable)
        {
            if (drawable.IsDrawn == true) return;

            Console.ForegroundColor = drawable.Color;
            Console.SetCursorPosition(drawable.CoordinateX, drawable.CoordinateY);
            Console.Write(drawable.Chars);
            drawable.IsDrawn = true;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
