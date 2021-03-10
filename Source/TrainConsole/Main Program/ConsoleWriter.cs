using System;
using System.Collections.Generic;
using System.IO;

namespace TrainConsole
{
   public static class ConsoleWriter
    {
        public static void Write(List<(char chr, int X, int Y)> charCoords)
        {
            foreach(var chrCoord in charCoords)
            {
                Console.SetCursorPosition(chrCoord.X, chrCoord.Y);
                Console.Write(chrCoord.chr);
            }
        }
    }
}
