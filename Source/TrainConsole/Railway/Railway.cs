using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public static class Railway
    {
        public static string Name { get; set; } = "Trans-Siberian Railway";
        public static List<TrainPlan> TrainPlans { get; set; } = new List<TrainPlan>();
        public static List<IRailwayItem> RailwayItems { get; set; } = new List<IRailwayItem>();
        public static List<TimeTable> timeTables { get; set; } = new List<TimeTable>();
        public static IRailwayItem GetPartFromId(int id)
            => RailwayItems.Find(x => x.Id == id);
        public static IRailwayItem GatPartFromPosXY((int X, int Y) coord)
            => RailwayItems.Find(item => item.CoordinateX == coord.X && item.CoordinateY == coord.Y);

        public static int SetIdAddId(IRailwayItem newPart, int? id = null)
        {
            var ids = RailwayItems.Select(x => x.Id).ToList();
            if (id != null && ids.Contains((int)id))
                throw new Exception($"Id already exists for {newPart.GetType()}");

            if (RailwayItems.Count == 0 && id == null)
            {
                return newPart.Id = 1;
            }
            if (id == null)
            {
                int highest = RailwayItems.Select(x => x.Id).OrderBy(x => x).Last();
                newPart.Id = highest + 1;
                return highest + 1;
            }
            else
            {
                newPart.Id = (int)id;
                return (int)id;
            }
        }
    }
}
