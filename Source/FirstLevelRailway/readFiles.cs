using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FirstLevelRailway
{
    public class readFiles
    {
        public string timeTablePath = "firstleveltimetable.txt";

        public List<(string Train, string Call)> timeTableDict (string timeTablePath)
        {
            var listOfTraincall = new List<(string Train, string Call)>();
            string[] lines = File.ReadAllLines(timeTablePath);

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
