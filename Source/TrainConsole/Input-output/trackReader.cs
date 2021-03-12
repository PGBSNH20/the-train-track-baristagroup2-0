using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public class trackReader
    {
        
        public static List<(char chr, int X, int Y)> CharCoordinates { get; set; }
        public static List<(char chr, int X, int Y)> Read(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var charCoord = new List<(char chr, int X, int Y)>();

            int x = 0;
            int y = 0;
            foreach (var line in lines)
            {
                foreach (char chr in line)
                {
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
