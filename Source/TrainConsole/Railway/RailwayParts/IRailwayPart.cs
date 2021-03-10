using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public interface IRailwayPart : IRailwayItem
    {
        public List<IRailwayPart> Connections { get; set; }
    }

}
