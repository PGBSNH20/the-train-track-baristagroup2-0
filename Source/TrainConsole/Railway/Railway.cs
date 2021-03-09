using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public interface IRailwayPart { }
    public static class Railway
    {
        public static string Name { get; set; } = "Malmbanan";
        public static List<IRailwayPart> RailwayParts { get; set; } = new List<IRailwayPart>();
        public static List<TrainPlan> TrainPlans { get; set; } = new List<TrainPlan>();
        public static void ClockTick()
        {
            foreach (var trainPlan in TrainPlans)
            {
                
            }
        }
    }
}
