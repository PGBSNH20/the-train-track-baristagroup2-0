using System;
using System.Linq;
using Xunit;
using TrainConsole;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;
using TrainConsole;

namespace TrainEngine.Tests
{
    public class RailwayGeneratorTests
    {
        [Fact]
        public void RailwayPartGenerator_Generate_ExpectEqual()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "[1]" });
            var railParts = RailwayPartGenerator.Generate(dataRead);
            var expected = new List<IRailwayPart>
            {
                new Station()
                {
                    Char = '1',
                    CoordinateX = 1,
                    CoordinateY = 0,
                    Id = 1
                }
            };
            var railString = JsonConvert.SerializeObject(railParts);
            var expString = JsonConvert.SerializeObject(expected);
            Assert.Equal(expString, railString);
        }
        [Fact]
        public void RailwayPartGenerator_Generate_ExpectThree()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "-1-" });
            var railParts = RailwayPartGenerator.Generate(dataRead);
            Assert.True(railParts.Count == 3);
        }
        [Fact]
        public void RailwayPartGenerator_Generate_ExpectThree2()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "-1-" });
            RailwayPartGenerator.Generate(dataRead);
            Assert.True(Railway.RailwayItems.Count == 3);
        }
        [Fact]
        public void Station_Generate_ExpectStation()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "-1-" });
            RailwayPartGenerator.Generate(dataRead);
            var items = Railway.RailwayItems;
            Assert.IsType<Station>(items[1]);
        }
    }
}
