using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public static class TraintrackReader
    {
    public static string FilePath = @"C:\Users\axels\Google Drive\Code\VS Code\Code-Dataatkomster-dotnet\the-train-track-baristagroup2-0\Source\TrainConsole\TextFiles\traintrack.txt";

        public static char[] switchChars = new char[] { '<', '>' };
        public static char crossingChar = '=';
        public static char[] railChars = new char[] { '-', '/', '\\' };
        public static char stationChar = '[';
        public static List<(char chr, int X, int Y)> CharCoordinates { get; set; }
        public static List<(char chr, int X, int Y)> Read()
        {
            var lines = File.ReadAllLines(FilePath);
            var charCoord = new List<(char chr, int X, int Y)>();
            var railwayChars = switchChars.ToList();
            railwayChars.AddRange(railChars);
            railwayChars.Add(crossingChar);

            int x = 0;
            int y = 0;
            foreach (var line in lines)
            {
                foreach  (char chr in line)
                {
                    if (railwayChars.Contains(chr))
                        charCoord.Add((chr, x, y));
                    if (chr == stationChar)
                    {
                        charCoord.Add(('|', x, y));
                        charCoord.Add(('|', x + 1, y));
                        charCoord.Add(('|', x + 2, y));
                    }
                    x++;
                }
                y++;
                x = 0;
            }
            return CharCoordinates = charCoord;
        }
    }
}
