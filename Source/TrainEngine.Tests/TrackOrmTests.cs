using System;
using System.Linq;
using Xunit;
using TrainConsole;
using System.Collections.Generic;

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
    }
}
