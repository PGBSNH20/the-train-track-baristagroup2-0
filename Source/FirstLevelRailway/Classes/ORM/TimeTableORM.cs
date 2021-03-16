using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FirstLevelRailway
{
    public class TimeTableORM : ITimeTableORM
    {
        //List.where => i = i.timeTable == 1
        public List<TimeTableBuilder> TimeTables { get; set; }
        private string WorkFile = @"../../../firstleveltimetable.txt";
        public TimeTableORM()
        {
            TimeTables = new List<TimeTableBuilder>();
        }
        public void Load(int timeTableID)
        {
            string[] lines = File.ReadAllLines(WorkFile);
            TimeTables = new List<TimeTableBuilder>();

            // TODO exceptionhandling
            foreach (var line in lines)
            {
                string[] splittedContent = line.Split(',');

                if (string.IsNullOrEmpty(line.Trim()))
                    continue;
                if (File.Exists(WorkFile))
                {
                    var timeTables = new TimeTableBuilder(timeTableID);
                    timeTables.TimeTableID = int.Parse(splittedContent[0]);
                    timeTables.DepatureStationID = splittedContent[1];
                    timeTables.DepartureTime = splittedContent[2];
                    timeTables.ArrivalStationID = splittedContent[3];
                    timeTables.ArrivalTime = splittedContent[4];
                    TimeTables.Add(timeTables);
                }
            }
        }
        public void Save(List<TimeTableBuilder> trainPlan)
        {
            StringBuilder fileContent = new StringBuilder();

            foreach (var item in trainPlan)
            {
                fileContent.AppendLine(
                    $"{item.TimeTableID},{item.DepatureStationID},{item.DepartureTime},{item.ArrivalStationID},{item.ArrivalTime}");


            }
            Console.WriteLine($"{trainPlan.Count} is saved to {WorkFile}String{fileContent}");
            File.AppendAllText(WorkFile, fileContent.ToString());
        }
    }
}
