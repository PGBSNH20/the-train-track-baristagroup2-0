
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TrainConsole
{
    public static class TrainTrackReader
    {
    public static string FilePath = @"TextFiles\traintrack.txt";

        public static List<(char chr, int X, int Y)> CharCoordinates { get; set; }
        public static List<(char chr, int X, int Y)> Read()
        {
            var lines = File.ReadAllLines(FilePath);
            var charCoord = new List<(char chr, int X, int Y)>();

            int x = 0;
            int y = 0;
            foreach (var line in lines)
            {
                foreach  (char chr in line)
                {
                    //if (railwayChars.Contains(chr))
                    //    charCoord.Add((chr, x, y));
                    if (chr != ' ')
                        charCoord.Add((chr, x, y));
                    x++;
                }
                y++;
                x = 0;
            }
            return CharCoordinates = charCoord;
        }
    }
}
