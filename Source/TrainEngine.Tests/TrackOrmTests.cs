using System;
using System.Linq;
using Xunit;
using TrainConsole;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TrainEngine.Tests
{
    public class TrackOrmTests
    {
        //[Fact]
        //public void When_OnlyAStationIsProvided_Expect_TheResultOnlyToContainAStationWithId1()
        //{
        //    // Arrange
        //    string track = "[1]";
        //    TrackOrm trackOrm = new TrackOrm();

        //    // Act
        //    var result = trackOrm.ParseTrackDescription(track);

        //    // Assert
        //    //Assert.IsType<Station>(result.TackPart[0]);
        //    //Station s = (Station)result.TackPart[0];
        //    //Assert.Equal(1, s.Id);
        //}

        //[Fact]
        //public void When_ProvidingTwoStationsWithOneTrackBetween_Expect_TheTrackToConcistOf3Parts()
        //{
        //    // Arrange
        //    string track = "[1]-[2]";
        //    TrackOrm trackOrm = new TrackOrm();
            
        //    // Act
        //    var result = trackOrm.ParseTrackDescription(track);

        //    // Assert
        //    Assert.Equal(3, result.NumberOfTrackParts);
        //}
        [Fact]
        public void Select_TimeTable_NotExpectTimeTable()
        {
            var timeTables = new List<TimeTable>()
            {
                new TimeTable(){TrainId = 2 },
                new TimeTable(){TrainId = 1 },
                new TimeTable(){TrainId = 3 },
            };
            var x = timeTables.Select(x => x.TrainId == 1);
            Assert.IsNotType<TimeTable>(x);
        }
        [Fact]
        public void Select_TimeTable_ExpectTimeTable()
        {
            var timeTables = new List<TimeTable>()
            {
                new TimeTable(){TrainId = 2 },
                new TimeTable(){TrainId = 1 },
                new TimeTable(){TrainId = 3 },
            };
            var x = timeTables.Select(x => x.TrainId == 1).First();
            Assert.IsType<bool>(x);
        }
        [Fact]
        public void Select_TimeTable_ExpectTimeTable2()
        {
            var timeTables = new List<TimeTable>()
            {
                new TimeTable(){TrainId = 2 },
                new TimeTable(){TrainId = 1 },
                new TimeTable(){TrainId = 3 },
            };
            var x = timeTables.Find(x => x.TrainId == 1);
            Assert.IsType<TimeTable>(x);
        }
        [Fact]
        public void Select_TimeTable_ExpectTimeTable3()
        {
            var timeTables = new List<TimeTable>()
            {
                new TimeTable(){TrainId = 2 },
                new TimeTable(){TrainId = 1 },
                new TimeTable(){TrainId = 3 },
            };
            var x = timeTables.First(x => x.TrainId == 1);
            Assert.IsType<TimeTable>(x);
        }
        [Fact]
        public void Char_Compare_ExpectNoEquaility()
        {
            var test = (int)'1';
            Assert.False(test == 1);
        }
        [Fact]
        public void Char_Compare_Expect48()
        {
            var test = (int)'0';
            Assert.True(test == 48);
        }
        [Fact]
        public void Char_Compare_Expect57()
        {
            var test = (int)'9';
            Assert.True(test == 57);
        }
        [Fact]
        public void Array_0Through5_ExpectNotEqual()
        {
            var array = Enumerable.Range(0, 5).Select(x => (char)x).ToArray();
            var expectedArray = new char[] { '0', '1', '2', '3', '4'};

            Assert.NotEqual(expectedArray, array);
        }
        [Fact]
        public void Array_0Through5_ExpectEqual()
        {
            var array = Enumerable.Range(0, 5).ToList();
            var charArray = array.Select(x => Char.Parse(x.ToString())).ToArray();

            var expectedArray = new char[] { '0', '1', '2', '3', '4' };

            Assert.Equal(expectedArray, charArray);
        }
        [Fact]
        public void TrainTrackReader_Read_ExpectEqual()
        {
            var dataRead = TrainTrackReader.Read(@"testStation.txt");
            var expected = new List<(char chr, int X, int Y)>
            {
                ('[', 0, 0),
                ('1', 1, 0),
                (']', 2, 0),
            };
            Assert.Equal(expected, dataRead);
        }
        [Fact]
        public void RailwayPartGenerator_Generate_ExpectEqual()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(@"testStation.txt");
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
        public void RailwayAssembler_Assemble_ExpectNotEqual()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(@"testStation.txt");
            var railParts = RailwayPartGenerator.Generate(dataRead);
            RailwayAssembler.Assemble(railParts);
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
            Assert.NotEqual(expString, railString);
        }

    }
}
