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
        private static List<IRailwayPart> LocatePartConnections(IRailwayPart part)
        {
            var partConnections = new List<IRailwayPart>();

            var up = Railway.GetPartFromPosXY((part.CoordinateX, part.CoordinateY+1));
            var upRight = Railway.GetPartFromPosXY((part.CoordinateX, part.CoordinateY + 1));
            var right = Railway.GetPartFromPosXY((part.CoordinateX, part.CoordinateY + 1));
            var downRight = Railway.GetPartFromPosXY((part.CoordinateX, part.CoordinateY + 1));
            var down = Railway.GetPartFromPosXY((part.CoordinateX, part.CoordinateY + 1));
            var downLeft = Railway.GetPartFromPosXY((part.CoordinateX, part.CoordinateY + 1));
            var left = Railway.GetPartFromPosXY((part.CoordinateX, part.CoordinateY + 1));
            var leftUp = Railway.GetPartFromPosXY((part.CoordinateX, part.CoordinateY + 1));

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
        public class PartLocator
        {

        }
    }
}
