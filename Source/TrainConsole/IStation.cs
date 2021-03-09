using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public interface IStation: IEndPoint, IRailwayItem
    {
        public int Id { get; set; }
        public string StationName { get; set; }
        public bool EndStation { get; set; }
    }
}
