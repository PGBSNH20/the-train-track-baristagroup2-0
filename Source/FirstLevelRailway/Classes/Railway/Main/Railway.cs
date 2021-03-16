using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLevelRailway
{
    public static class Railway
    {
        public const double PartLength_km = 10.0;
        public static string Name { get; set; } = "Trans-Siberian Railway";
        public static List<IRailwayPart> RailwayParts { get; set; } = new List<IRailwayPart>();
        public static void AppendParts(List<IRailwayPart> railwayParts)
        {
            foreach (var part in railwayParts)
            {
                RailwayParts.Add(part);
            }
        }

    }
}