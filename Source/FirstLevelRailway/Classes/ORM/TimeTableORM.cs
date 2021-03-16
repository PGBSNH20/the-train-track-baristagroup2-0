using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FirstLevelRailway
{
    public class TimeTableORM : ITimeTableORM
    {
        //List.where => i = i.timeTable == 1
        public List<TrainPlanner> TimeTables { get; set; }
        private string WorkFile;
        public TimeTableORM(string filePath)
        {
            WorkFile = filePath;
            TimeTables = new List<TrainPlanner>();
        }
        public void Load(int timeTableID)
        {
            string[] lines = File.ReadAllLines(WorkFile);
            TimeTables = new List<TrainPlanner>();

            // TODO exceptionhandling
            foreach (var line in lines)
            {
                string[] splittedContent = line.Split(',');

                if (string.IsNullOrEmpty(line.Trim()))
                    continue;
                if (File.Exists(WorkFile))
                {

                    var trainPlanner = new TrainPlanner(timeTableID);
                    trainPlanner.TimeTableID = int.Parse(splittedContent[0]);
                    trainPlanner.DepatureStationID = splittedContent[1];
                    trainPlanner.DepartureTime = splittedContent[2];
                    trainPlanner.ArrivalStationID = splittedContent[3];
                    trainPlanner.ArrivalTime = splittedContent[4];
                    TimeTables.Add(trainPlanner);
                    

                }
            }

        }
        public void Save(List<TrainPlanner> trainPlan)
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
