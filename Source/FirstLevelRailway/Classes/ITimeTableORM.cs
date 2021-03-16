using System.Collections.Generic;

namespace FirstLevelRailway
{
    public interface ITimeTableORM
    {
        List<TimeTableBuilder> TimeTables { get; set; }
        void Load(int timeTableID);
        void Save(List<TimeTableBuilder> trainPlan);

    }
}
