using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace FirstLevelRailway
{
    public class Train
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxSpeed { get; set; }
        public bool Operated { get; set; }
    }
}