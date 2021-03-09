﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public class RailwayBuilder
    {
        private int Id = 0;
        public Railway railway = new Railway();
        private int GetId()
        {
            Id++;
            return Id;
        }
        public IStation BuildStation(string name, bool endStation)
        {
            var station = Factory.BuildStation(GetId(), name, endStation);
            return station;
        }
        public void BuildRail(IEndPoint A, IEndPoint B)
        {
            var rail = Factory.BuildRail(GetId(), A, B);
            railway.RailwayParts.Add(rail);
        }

        public Railway Build()
        {
            return this.railway;
        }
    }
}
