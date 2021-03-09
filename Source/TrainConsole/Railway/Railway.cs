using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public static class Railway
    {
        public static string Name { get; set; } = "Malmbanan";
        public static List<IRailwayPart> RailwayParts { get; set; } = new List<IRailwayPart>();
        public static List<TimeTable> timeTables { get; set; } = new List<TimeTable>();
        public static IRailwayPart GetPartFromId(int id)
        {
            return RailwayParts.Find(x => x.Id == id);
        }
        public static List<TrainPlan> TrainPlans { get; set; } = new List<TrainPlan>();
        public static void ClockTick()
        {
            foreach (var trainPlan in TrainPlans)
            {
                
            }
        }
    }
}
