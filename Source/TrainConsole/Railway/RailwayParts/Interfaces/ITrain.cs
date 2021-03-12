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
        public List<CheckPoint> Stops { get; set; }
        //public List<(int Name, int X, int Y, int Time)> Stops;
        public void MoveForward();
    }
}
