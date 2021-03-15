using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLevelRailway
{
    public static class Railway
    {
        public const double PartLength_km = 10.0;
        public static string Name { get; set; } = "Trans-Siberian Railway";
        public static List<IRailwayPart> RailwayParts { get; set; } = new List<IRailwayPart>();
        //public static List<TimeTable> timeTables { get; set; } = new List<TimeTable>();
        public static List<IRailwayPart> GetRailwayParts()
        {
            return RailwayParts;
        }
        //public static int SetIdAddId(IRailwayItem newPart, int? id = null)
        //{
        //    var ids = RailwayItems.Select(x => x.Id).ToList();
        //    if (id != null && ids.Contains((int)id))
        //        throw new Exception($"Id already exists for {newPart.GetType()}");

        //    if (RailwayItems.Count == 0 && id == null)
        //    {
        //        return newPart.Id = 1;
        //    }
        //    if (id == null)
        //    {
        //        int highest = RailwayItems.Select(x => x.Id).OrderBy(x => x).Last();
        //        newPart.Id = highest + 1;
        //        return highest + 1;
        //    }
        //    else
        //    {
        //        newPart.Id = (int)id;
        //        return (int)id;
        //    }
        //}
    }
}