
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TrainConsole
{
    public static class TrainTrackReader
    {
        public static List<(char chr, int X, int Y)> CharCoordinates { get; set; }
        public static List<(char chr, int X, int Y)> Read(string[] inputLines)
        {
            var charCoord = new List<(char chr, int X, int Y)>();

            int x = 0;
            int y = 0;
            foreach (var line in inputLines)
            {
                foreach  (char chr in line)
                {
                    if (chr != ' ')
                        charCoord.Add((chr, (int)x, (int)y));
                    x++;
                }
                y++;
                x = 0;
            }
            return CharCoordinates = charCoord;
        }
    }
}
