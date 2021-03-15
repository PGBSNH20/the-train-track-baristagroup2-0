using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLevelRailway
{
    public class Crossing : IRailwayPart
    {
        public int Id { get; set; }
        public char Char { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public List<IRailwayPart> Connections { get; set; } = new List<IRailwayPart>();

    }
}
