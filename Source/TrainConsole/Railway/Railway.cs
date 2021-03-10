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
        public static List<IRailwayItem> RailwayItems { get; set; } = new List<IRailwayItem>();
        public static List<TimeTable> timeTables { get; set; } = new List<TimeTable>();
        public static IRailwayItem GetPartFromId(int id)
        {
            return RailwayItems.Find(x => x.Id == id);
        }

        public static int SetIdAddId(int? id, IRailwayItem newPart)
        {
            if (RailwayItems.Select(x => x.Id).ToList().Contains((int)id) == true)
                throw new Exception($"Id already exists for {newPart.GetType()}");

            if(id == null)
            {
                int highest = RailwayItems.Select(x => x.Id).OrderBy(x => x).Last();
                newPart.Id = highest++;
                return highest++;
            }
            else
            {
                newPart.Id = (int)id;
                return (int)id;
            }
        }
        public static List<TrainPlan> TrainPlans { get; set; } = new List<TrainPlan>();
    }
}
