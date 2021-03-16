using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace FirstLevelRailway
{
    public class Train
    {
        public string Name { get; set; }
        public List<(IRailwayPart, int)> Route { get; set; }
        //public void GetRoute(TrainPlanner trainPlanner)
        //{

        //}
    }


}