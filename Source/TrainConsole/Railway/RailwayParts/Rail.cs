﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public class Rail : IRail
    {
        public int Id { get; set; }
        public List<IRailwayPart> Connections { get; set; }
    }
}
