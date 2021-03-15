using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLevelRailway
{
    public class TrainORM
    {
        public List<Train> filePathTrains(string trainsFilePath)
        {
            var trainList = new List<Train>();
            string[] lines = File.ReadAllLines(trainsFilePath);

            foreach (var line in lines)
            {
                string[] parts = line.Split(',');

                var trainsInList = new Train
                {
                    Id = int.Parse(parts[0]),
                    Name = parts[1],
                    MaxSpeed = int.Parse(parts[2]),
                    Operated = bool.Parse(parts[3])
                };
                trainList.Add(trainsInList);
            }
            return trainList;
        }

    }
}
