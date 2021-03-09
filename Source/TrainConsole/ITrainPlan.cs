using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public interface ITrainPlan
    {
        public ITrain train { get; set; }
        public TimeTable timeTable { get; set; }
        public void Save(string filePath);
        public void Load(string filePath);
    }
}
