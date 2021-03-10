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
        public int MaxSpeed { get; set; }
        public bool Operated { get; set; }
        public bool IsBetweenStops { get; set; }
        public List<Stop> Stops { get; set; }
        public void MoveForward();        
    }
}
