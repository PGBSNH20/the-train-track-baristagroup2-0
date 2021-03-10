using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
   public class Station : IStation
    {
        public int Id { get; set; }
        public string StationName { get; set; }
        public bool EndStation { get; set; }
        public List<IRailwayPart> Connections { get; set; }
    }
}
