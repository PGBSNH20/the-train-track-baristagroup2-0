using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace FirstLevelRailway
{
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
