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
    }
}
