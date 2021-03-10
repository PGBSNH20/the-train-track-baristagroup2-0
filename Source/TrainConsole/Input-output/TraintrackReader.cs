using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public static class TrainTrackReader
    {
    public static string FilePath = @"C:\Users\axels\Google Drive\Code\VS Code\Code-Dataatkomster-dotnet\the-train-track-baristagroup2-0\Source\TrainConsole\TextFiles\traintrack.txt";

        public static char[] SwitchChars = new char[] { '<', '>' };
        public static char CrossingChar = '=';
        public static char[] RailChars = new char[] { '-', '/', '\\' };
        public static char[] StationChars = Enumerable.Range(0, 9).Select(x => (char)x).ToArray();
        public static List<(char chr, int X, int Y)> CharCoordinates { get; set; }
        public static List<(char chr, int X, int Y)> Read()
        {
            var lines = File.ReadAllLines(FilePath);
            var charCoord = new List<(char chr, int X, int Y)>();
            var railwayChars = SwitchChars.ToList();
            railwayChars.AddRange(RailChars);
            railwayChars.Add(CrossingChar);
            railwayChars.AddRange(StationChars);

            int x = 0;
            int y = 0;
            foreach (var line in lines)
            {
                foreach  (char chr in line)
                {
                    if (railwayChars.Contains(chr))
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
