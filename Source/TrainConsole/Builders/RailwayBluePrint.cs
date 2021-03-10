using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public class RailwayBlueprint
    {
        public List<IRail> Rails { get; set; }
        public List<IStation> Stations { get; set; }
        public List<ICrossing> Crossings { get; set; }
        public List<ISwitch> Switches { get; set; }

        public void AddParts(List<(char chr, int X, int Y)> CharCoordinates)
        {
            var railChars = TraintrackReader.railChars;
            foreach (var charCoord in CharCoordinates)
            {
                if (railChars.Contains(charCoord.chr))
                {
                    int thisX = charCoord.X;
                    int thisY = charCoord.Y;

                    var right = CharCoordinates.Find(x => x.X == thisX + 1 && x.Y == thisY);
                    var rightup = CharCoordinates.Find(x => x.X == thisX + 1 && x.Y == thisY + 1);
                    var up = CharCoordinates.Find(x => x.X == thisX && x.Y == thisY + 1);

                    if (true)
                    {

                    }
                }
            }
        }
    }
}
