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
            File.AppendAllText("TimeTableOrmTestfile.txt", fileContent.ToString());
            
        }
        [Fact]
        public void test1()
        {
            var timetableorm = new TimeTableORM();
            var trainplans = new List<TimeTableBuilder>() { new TimeTableBuilder(1) };
            timetableorm.Save(trainplans);

        }
    }

}
