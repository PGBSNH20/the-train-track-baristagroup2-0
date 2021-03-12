using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public static class RailwayAssembler
    {
        public static void Assemble(List<IRailwayPart> railwayParts)
        {
            foreach (var part in railwayParts)
            {
                if(part != null)
                    part.Connections.AddRange(LocatePartConnections(part));
            }
        }
        public static List<IRailwayPart> LocatePartConnections(IRailwayPart part)
        {
            var partConnections = new List<IRailwayPart>();



            var up = RailwayLocator.LocateWithPosXY((part.CoordinateX, part.CoordinateY+1));
            var upRight = RailwayLocator.LocateWithPosXY((part.CoordinateX, part.CoordinateY + 1));
            var right = RailwayLocator.LocateWithPosXY((part.CoordinateX, part.CoordinateY + 1));
            var downRight = RailwayLocator.LocateWithPosXY((part.CoordinateX, part.CoordinateY + 1));
            var down = RailwayLocator.LocateWithPosXY((part.CoordinateX, part.CoordinateY + 1));
            var downLeft = RailwayLocator.LocateWithPosXY((part.CoordinateX, part.CoordinateY + 1));
            var left = RailwayLocator.LocateWithPosXY((part.CoordinateX, part.CoordinateY + 1));
            var leftUp = RailwayLocator.LocateWithPosXY((part.CoordinateX, part.CoordinateY + 1));

            var tempItems = new List<IRailwayItem>() 
            { 
                up, upRight, right, downRight, down, downLeft, left, leftUp
            };

            foreach(var item in tempItems)
            {
                if (item != null)
                    partConnections.Add((IRailwayPart)item);
            }

            return partConnections;
        }
    }
}
