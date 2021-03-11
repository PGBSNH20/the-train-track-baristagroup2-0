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
                part.Connections.AddRange(LocatePartConnections(part));
        }
        private static List<IRailwayPart> LocatePartConnections(IRailwayPart part)
        {
            var partConnections = new List<IRailwayPart>();

            var up = Railway.GatPartFromPosXY((part.CoordinateX, part.CoordinateY+1));
            var upRight = Railway.GatPartFromPosXY((part.CoordinateX, part.CoordinateY + 1));
            var right = Railway.GatPartFromPosXY((part.CoordinateX, part.CoordinateY + 1));
            var downRight = Railway.GatPartFromPosXY((part.CoordinateX, part.CoordinateY + 1));
            var down = Railway.GatPartFromPosXY((part.CoordinateX, part.CoordinateY + 1));
            var downLeft = Railway.GatPartFromPosXY((part.CoordinateX, part.CoordinateY + 1));
            var left = Railway.GatPartFromPosXY((part.CoordinateX, part.CoordinateY + 1));
            var leftUp = Railway.GatPartFromPosXY((part.CoordinateX, part.CoordinateY + 1));

            var tempItems = new List<IRailwayItem>() 
            { 
                up, upRight, right, downRight, down, downLeft, left, leftUp
            };

            foreach(var item in tempItems)
                if (item != null)
                    partConnections.Add((IRailwayPart)item);

            return partConnections;
        }
    }
}
