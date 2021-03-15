using System.Collections.Generic;

namespace FirstLevelRailway
{
    public interface ITimeTableORM
    {
        List<TrainPlanner> TimeTables { get; set; }
        void Load(int timeTableID);
        void Save();

    }
}
