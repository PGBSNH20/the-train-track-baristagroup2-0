using System;
using System.Linq;
using Xunit;
using TrainConsole;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

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
        public void TrainTrackReader_ReadFile_ExpectEqual()
        {
            var dataRead = TrainTrackReader.Read(File.ReadAllLines(@"testStation.txt"));
            var expected = new List<(char chr, int X, int Y)>
            {
                ('[', 0, 0),
                ('1', 1, 0),
                ('-', 2, 0),
                ('<', 3, 0),
                ('>', 4, 0),
                (']', 5, 0),
                ('/', 6, 0),
                ('\\', 7, 0),
                ('=', 9, 0),
            };
            Assert.Equal(expected, dataRead);
        }
        public void TrainTrackReader_ReadFile_ExpectNoWhiteSpace()
        {
            var dataRead = TrainTrackReader.Read(new string[] { " " });
            Assert.True(dataRead.Count == 0);
        }
        [Fact]
        public void TrainTrackReader_ReadArray_ExpectEqual()
        {
            var dataRead = TrainTrackReader.Read(new string[] {"[1]" });
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
            var dataRead = TrainTrackReader.Read(new string[] {"[1]" });
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
        public void RailwayLocator_LocateWithId_ExpectFromIStation()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] {"[1]" });
            var railParts = RailwayPartGenerator.Generate(dataRead);
            var station = RailwayLocator.LocateWithId(1);
            Assert.IsAssignableFrom<IStation>(station);
        }
        [Fact]
        public void RailwayLocator_LocateWithId_ExpectAssignableFromIRailwayItem()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "[1]" });
            var railParts = RailwayPartGenerator.Generate(dataRead);
            var station = RailwayLocator.LocateWithId(1);
            Assert.IsAssignableFrom<IRailwayItem>(station);
        }
        [Fact]
        public void RailwayLocator_LocateWithId_ExpectAssignableFromIRailwayPart()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "[1]" });
            var railParts = RailwayPartGenerator.Generate(dataRead);
            var station = RailwayLocator.LocateWithId(1);
            Assert.IsAssignableFrom<IRailwayPart>(station);
        }
        [Fact]
        public void RailwayPart_ExpectAssignableFromIRail()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "-" });
            var railParts = RailwayPartGenerator.Generate(dataRead);
            var rail = Railway.RailwayItems[0];
            Assert.IsAssignableFrom<IRail>(rail);
        }
        [Fact]
        public void RailwayPart_ExpectRail()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "-" });
            var railParts = RailwayPartGenerator.Generate(dataRead);
            var rail = Railway.RailwayItems[0];
            Assert.IsType<Rail>(rail);
        }
        [Fact]
        public void RailwayPart_ExpectCrossing()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "=" });
            var railParts = RailwayPartGenerator.Generate(dataRead);
            var crossing = Railway.RailwayItems[0];
            Assert.IsType<Crossing>(crossing);
        }
        [Fact]
        public void RailwayPart_ExpectSwitch()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "<" });
            var railParts = RailwayPartGenerator.Generate(dataRead);
            var railSwitch = Railway.RailwayItems[0];
            Assert.IsType<RailSwitch>(railSwitch);
        }
        [Fact]
        public void RailwayPart_ExpectSwitch2()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { ">" });
            var railParts = RailwayPartGenerator.Generate(dataRead);
            var railSwitch = Railway.RailwayItems[0];
            Assert.IsType<RailSwitch>(railSwitch);
        }
        [Fact]
        public void RailwayPart_ExpectRail2()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "\\" });
            var railParts = RailwayPartGenerator.Generate(dataRead);
            var rail = Railway.RailwayItems[0];
            Assert.IsType<Rail>(rail);
        }
        [Fact]
        public void RailwayPart_ExpectRail3()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "/" });
            var railParts = RailwayPartGenerator.Generate(dataRead);
            var rail = Railway.RailwayItems[0];
            Assert.IsType<Rail>(rail);
        }
        [Fact]
        public void RailwayLocator_LocateWithId_ExpectNotRail()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "[1]" });
            var railParts = RailwayPartGenerator.Generate(dataRead);
            var station = RailwayLocator.LocateWithId(1);
            Assert.IsNotType<Rail>(station);
        }
        [Fact]
        public void RailwayLocator_LocateWithId_ExpectFromStation()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] {"[1]" });
            var railParts = RailwayPartGenerator.Generate(dataRead);
            var station = RailwayLocator.LocateWithId(1);
            Assert.IsAssignableFrom<Station>(station);
        }
        [Fact]
        public void RailwayLocator_LocateWithPosXY_ExpectIStation()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] {"[1]" });
            var railParts = RailwayPartGenerator.Generate(dataRead);
            var station = RailwayLocator.LocateWithPosXY((1, 0));
            Assert.IsAssignableFrom<IStation>(station);
        }
        [Fact]
        public void RailwayLocator_LocateWithPosXY_ExpectStation()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] {"[1]" });
            var railParts = RailwayPartGenerator.Generate(dataRead);
            var station = RailwayLocator.LocateWithPosXY((1, 0));
            Assert.IsAssignableFrom<Station>(station);
        }
        [Fact]
        public void RailwayLocator_LocateWithPosXY_ExpectNull()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] {"[1]" });
            var railParts = RailwayPartGenerator.Generate(dataRead);
            var station = RailwayLocator.LocateWithPosXY((0, 0));
            Assert.True(station == null);
        }
        [Fact]
        public void RailwayLocator_LocateWithId_ExpectNull()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] {"[1]" });
            var railParts = RailwayPartGenerator.Generate(dataRead);
            var station = RailwayLocator.LocateWithId(99);
            Assert.True(station == null);
        }
        [Fact]
        public void RailwayAssembler_Assemble_ExpectNoException()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] {"[1]" });
            var railParts = RailwayPartGenerator.Generate(dataRead);
            try
            {
                RailwayAssembler.Assemble(railParts);
            }
            catch (Exception)
            {
                throw new Exception("RailwayAssembler_Assemble_ExpectNoException throw an exception");
            }
        }
        [Fact]
        public void RailwayAssembler_Assemble_LocatePartConnections_ExpectZero()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] {"[1]" });
            var railParts = RailwayPartGenerator.Generate(dataRead);
            var station = railParts[0];
            var connections = RailwayAssembler.LocatePartConnections(station);
            Assert.True(connections.Count == 0);
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
            Assert.IsType<Station>(Railway.RailwayItems[1]);
        }
        [Fact]
        public void Station_Generate_ExpectPropertyTrue()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "-1-" });
            RailwayPartGenerator.Generate(dataRead);

            Assert.True(Railway.RailwayItems[1].CoordinateX == 1);
        }
        [Fact]
        public void RailwayLocator_LocateUp_ExpectSwitch()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "-->", "-=-" });
            RailwayPartGenerator.Generate(dataRead);
            var station = Railway.RailwayItems[5];
            var up = RailwayLocator.LocateUp((IRailwayPart)station);
            Assert.IsType<RailSwitch>(up);
        }
        [Fact]
        public void RailwayLocator_LocateUpRight_ExpectSwitch()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "--<", "-=-" });
            RailwayPartGenerator.Generate(dataRead);
            var crossing = Railway.RailwayItems[4];
            var upRight = RailwayLocator.LocateUpRight((IRailwayPart)crossing);
            Assert.IsType<RailSwitch>(upRight);
        }
        [Fact]
        public void RailwayLocator_LocateRight_ExpectStation()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "-1-" });
            RailwayPartGenerator.Generate(dataRead);
            var rail = Railway.RailwayItems[0];
            var right = RailwayLocator.LocateRight((IRailwayPart)rail);
            Assert.IsType<Station>(right);
        }
        [Fact]
        public void RailwayLocator_LocateDownRight_ExpectRail()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "111", "1-1"});
            RailwayPartGenerator.Generate(dataRead);
            var station = Railway.RailwayItems[0];
            var downRight = RailwayLocator.LocateDownRight((IRailwayPart)station);
            Assert.IsType<Rail>(downRight);
        }

        [Fact]
        public void RailwayLocator_LocateDown_ExpectCrossing()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "-1-", "-=-" });
            RailwayPartGenerator.Generate(dataRead);
            var station = Railway.RailwayItems[1];
            var down = RailwayLocator.LocateDown((IRailwayPart)station);
            Assert.IsType<Crossing>(down);
        }
        [Fact]
        public void RailwayLocator_LocateDownLeft_ExpectCrossing()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "---", "=--" });
            RailwayPartGenerator.Generate(dataRead);
            var rail = Railway.RailwayItems[1];
            var downLeft = RailwayLocator.LocateDownLeft((IRailwayPart)rail);
            Assert.IsType<Crossing>(downLeft);
        }
        [Fact]
        public void RailwayLocator_LocateLeft_ExpectRail()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "-1-" });
            RailwayPartGenerator.Generate(dataRead);
            var station = Railway.RailwayItems[1];
            var left = RailwayLocator.LocateLeft((IRailwayPart)station);
            Assert.IsType<Rail>(left);
        }
        [Fact]
        public void RailwayLocator_UpLeft_ExpectRail()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "=<=", "===" });
            RailwayPartGenerator.Generate(dataRead);
            var station = Railway.RailwayItems[5];
            var upLeft = RailwayLocator.LocateUpLeft((IRailwayPart)station);
            Assert.IsType<RailSwitch>(upLeft);
        }
        [Fact]
        public void RailwayLocator_Up_ExpectNull()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "=<=", "===" });
            RailwayPartGenerator.Generate(dataRead);
            var station = Railway.RailwayItems[0];
            var upLeft = RailwayLocator.LocateUpLeft((IRailwayPart)station);

            Assert.True(upLeft == null);
        }
    }
}
