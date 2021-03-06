using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public interface IStation: IEndPoint, IRailwayPart
    {
        public string StationName { get; set; }
        public bool EndStation { get; set; }
    }
}
