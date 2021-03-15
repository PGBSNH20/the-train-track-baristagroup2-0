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
    public class RailwayPartORMTests : IDisposable
    {
        public RailwayPartORMTests()
        {
            Railway.RailwayParts.Clear();
        }
        public void Dispose()
        {
            Railway.RailwayParts.Clear();
        }
        [Fact]
        public void RailwayPartGenerator_Generate_ExpectEqual()
        {
            Railway.RailwayParts.Clear();
            var dataRead = TrackReader.Read(new string[] { "[1]" });
            var railParts = RailwayPartsORM.Map(dataRead);
            var expected = new List<IRailwayPart>
            {
                new Rail()
                {
                    Char = '[',
                    CoordinateX = 0,
                    CoordinateY = 0,
                },
                new Station()
                {
                    Char = '1',
                    CoordinateX = 1,
                    CoordinateY = 0,
                },
                 new Rail()
                {
                    Char = ']',
                    CoordinateX = 2,
                    CoordinateY = 0,
                },
            };
            var railString = JsonConvert.SerializeObject(railParts);
            var expString = JsonConvert.SerializeObject(expected);
            Assert.Equal(expString, railString);
        }
        [Fact]
        public void RailwayPartGenerator_Generate_ExpectThree()
        {
            Railway.RailwayParts.Clear();
            var dataRead = TrackReader.Read(new string[] { "-1-" });
            var railParts = RailwayPartsORM.Map(dataRead);
            Assert.True(railParts.Count == 3);
        }
        [Fact]
        public void RailwayPartGenerator_Generate_ExpectThree2()
        {
            Railway.RailwayParts.Clear();
            var dataRead = TrackReader.Read(new string[] { "-1-" });
            var railParts = RailwayPartsORM.Map(dataRead);
            Assert.True(railParts.Count == 3);
        }
        [Fact]
        public void Station_Generate_ExpectStation()
        {
            Railway.RailwayParts.Clear();
            var dataRead = TrackReader.Read(new string[] { "-1-" });
            var railParts = RailwayPartsORM.Map(dataRead);
            Assert.IsType<Station>(railParts[1]);
        }
    }
}
