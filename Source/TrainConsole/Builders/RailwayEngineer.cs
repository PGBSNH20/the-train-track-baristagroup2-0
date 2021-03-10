using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public class RailwayEngineer
    {
        private List<IRailwayPart> RailwayParts = new List<IRailwayPart>();
        public RailwayEngineer Connect(IRailwayPart part)
        {
            RailwayParts.Add(part);
            return this;
        }
        public void Build()
        {
            var buildList = RailwayParts.SkipLast(1).ToList();
            for (int i = 0; i < buildList.Count; i++)
            {
                var newRail = Factory.AddRail(null, buildList[i], buildList[i + 1]);

            }
        }
    }
}
