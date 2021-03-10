using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public interface ICheckPoint
    {
        public IRailwayPart location { get; set; }
    }
}
