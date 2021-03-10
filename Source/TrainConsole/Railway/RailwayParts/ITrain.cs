using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public interface ITrain : IRailwayItem
    {
        public string Name { get; set; }
        public bool IsBetweenStops { get; set; }
        public List<CheckPoint> Stops { get; set; }
        public void MoveForward();
    }
}
