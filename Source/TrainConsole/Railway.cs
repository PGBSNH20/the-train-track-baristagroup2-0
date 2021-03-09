using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public interface IRailwayPart { }
    public class Railway
    {
        public string Name { get; set; } = "Malmbanan";
        public List<IRailwayPart> RailwayParts { get; set; }
        public List<Train> Trains { get; set; } = new List<Train>();
    }
}
