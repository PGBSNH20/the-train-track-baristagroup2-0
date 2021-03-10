using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public interface IRailwayEngineer
    {
        public List<IRailwayPart> RailwayParts { get; set; }
        public void Build();
    }
}
