using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace FirstLevelRailway
{
    public interface ITimeTableORM
    {
        List<TrainPlanner> TimeTables { get; set; }
        void Load();
        void Save();

    }

    public class TimeTableORM : ITimeTableORM
    {

        public List<TrainPlanner> TimeTables { get; set; }
        private string WorkFile;
        public TimeTableORM(string filePath)
        {
            WorkFile = filePath;
            TimeTables = new List<TrainPlanner>();

        }
        public void Load(int timeTableID)
        {
            var trainPlanner = new TrainPlanner(timeTableID);
            string[] lines = File.ReadAllLines(WorkFile);
            TimeTables = new List<TrainPlanner>();

            foreach (var line in lines)
            {
                var splittedContent = line.Split(new[] { ',' });

                trainPlanner.DepartureAtStation = splittedContent[1];

            }



        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }




    public static class TrainCallLoader
    {
        public static string timeTablePath = @"firstleveltimetable.txt";
        public static List<(string TrainName, string Call)> Load()
        {
            var listOfTraincall = new List<(string TrainName, string Call)>();

            string[] fileLines = File.ReadAllLines(timeTablePath);
            var lines = fileLines.ToList();
            lines.RemoveAt(0);

            foreach (var line in lines)
            {
                string[] parts = line.Split(',');
                var newTrainCall = (parts[0], parts[1]);
                listOfTraincall.Add(newTrainCall);
            }
            return listOfTraincall;
        }
    }
}
