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

            var tempList = new List<IRailwayPart>()
            { 
                RailwayLocator.LocateUp(part),
                RailwayLocator.LocateUpRight(part),
                RailwayLocator.LocateRight(part),
                RailwayLocator.LocateDownRight(part),
                RailwayLocator.LocateDown(part),
                RailwayLocator.LocateDownLeft(part),
                RailwayLocator.LocateLeft(part),
                RailwayLocator.LocateUpLeft(part),
            };

            foreach(var p in tempList)
            {
                if(p != null)
                partConnections.Add(p);
            }

            return partConnections;
        }
    }
}
