using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public interface IRailwayItem{}
    public class Railway
    {
        public string Name { get; set; } = "Malmbanan";
        public List<IRailwayItem> RailwayParts { get; set; }
    }
}
