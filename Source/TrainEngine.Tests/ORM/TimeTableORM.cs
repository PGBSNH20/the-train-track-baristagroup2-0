using System;
using System.Linq;
using Xunit;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using FirstLevelRailway;

namespace TrainEngine.Tests
{
    public class TimeTableORMTests
    {
        [Fact]
        public void stringbuilder_test_simpleString_AssertTrue()
        {
            StringBuilder fileContent = new StringBuilder();
            fileContent.AppendLine(
                $"test");
            string output = fileContent.ToString();
            output = output.TrimEnd();
            Assert.True("test" == output);
            //File.AppendAllText(filePath, fileContent.ToString());
            //string 
        }
        //[Fact]
        //public void stringbuilder_test_WriteToFile()
        //{
        //    string filePath = @"ORM/TimeTableOrmTestFile.txt";

        //    StringBuilder fileContent = new StringBuilder();
        //    fileContent.AppendLine(
        //        $"test");
        //    string output = fileContent.ToString();
        //    File.AppendAllText(filePath, )
        //    Assert.True("test" == output);
        //    //File.AppendAllText(filePath, fileContent.ToString());
        //    //string 
        //}
        //[Fact]
        //public void Test1()
        //{
        //    var timeTableORM = new TimeTableORM("fff");
        //    var trainPlans = new List<TrainPlanner>() { new TrainPlanner(1) };
        //    timeTableORM.Save(trainPlans);

        //}
    }

}
