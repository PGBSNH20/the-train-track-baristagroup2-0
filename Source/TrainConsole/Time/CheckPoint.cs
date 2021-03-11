using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public class CheckPoint : ICheckPoint
    {
        public IRailwayPart location { get; set; }
        public bool HasArrived { get; set; }
        public bool HasDeparted { get; set; }
    }
}
