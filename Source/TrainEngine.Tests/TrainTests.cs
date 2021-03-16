using System;
using System.Linq;
using Xunit;
using FirstLevelRailway;
using System.Collections.Generic;

namespace TrainEngine.Tests
{
    public class TrainTests
    {
        [Fact]
        public void TickFromTrainPlanner_ExpectTrue()
        {
            var trainPlanner = new TrainPlanner(1);
            trainPlanner.StartTrainAt("1", "05:00");
            var ticks = TwentyFourHourClock.TimeToTicks(trainPlanner.DepartureTime);
            Assert.True(ticks == 300);
        }
        [Fact]
        public void _ConvertOneInstance_ExpectTrue()
        {
            Railway.RailwayParts.Clear();
            var station = new Station();
            station.Char = '1';
            Railway.RailwayParts.Add(station);
            var train = new Train();
            var timesToConvert = new List<(string StationID, string Time)>
            {
                ("1", "10:00")
            };
            train.ConvertTimes(timesToConvert);

            Assert.True(train.Route.Count == 1);
        }
        [Fact]
        public void _InsideConvert_OneInstance_ExpectTrue()
        {
            Railway.RailwayParts.Clear();
            var station = new Station();
            station.Char = '1';
            Railway.RailwayParts.Add(station);
            var part = Railway.RailwayParts.Find(x => x.Char.ToString() == "1");
            Assert.True(part == station);
        }
        [Fact]
        public void _ConvertTimes_OneInstance_ExpectTrue()
        {
            Railway.RailwayParts.Clear();
            var station = new Station();
            station.Char = '1';
            Railway.RailwayParts.Add(station);
            var train = new Train();
            var timesToConvert = new List<(string StationID, string Time)>
            {
                ("1", "10:00")
            };
            train.ConvertTimes(timesToConvert);

            Assert.True(train.Route[0].Part == station);
        }
        [Fact]
        public void _ConvertTimes_TwoInstance_ExpectTrue()
        {
            Railway.RailwayParts.Clear();
            var station = new Station();
            station.Char = '1';
            Railway.RailwayParts.Add(station);
            var train = new Train();
            var timesToConvert = new List<(string StationID, string Time)>
            {
                ("1", "10:00"),
                ("2", "20:00")
            };
            train.ConvertTimes(timesToConvert);

            Assert.True(train.Route.Count == 2);
        }
        [Fact]
        public void _Train_RuntTrain_300_ExpectTrue()
        {
            Railway.RailwayParts.Clear();
            var station = new Station();
            station.Char = '1';
            Railway.RailwayParts.Add(station);
            var train = new Train();
            var timesToConvert = new List<(string StationID, string Time)>
            {
                ("1", "00:00"),
                ("2", "10:00")
            };
            train.ConvertTimes(timesToConvert);
            var clock = new TwentyFourHourClock();
            Program.Clock = clock;

            for (int i = 0; i < 300; i++)
            {
                clock.Tick();
                train.RunTrain(false);
            }

            Assert.True(0 == train.Index);
        }
        [Fact]
        public void _Train_RuntTrain_1000_ExpectTrue()
        {
            Railway.RailwayParts.Clear();
            var station = new Station();
            station.Char = '1';
            Railway.RailwayParts.Add(station);

            var station2 = new Station();
            station2.Char = '2';
            Railway.RailwayParts.Add(station2);

            var train = new Train();
            var timesToConvert = new List<(string StationID, string Time)>
            {
                ("1", "00:00"),
                ("2", "10:00")
            };
            train.ConvertTimes(timesToConvert);
            var clock = new TwentyFourHourClock();
            Program.Clock = clock;

            for (int i = 0; i < 1000; i++)
            {
                clock.Tick();
                train.RunTrain(false);
            }
            var index = train.Index;
            Assert.True(1 == index);
        }
        [Fact]
        public void _Train_RuntTrain_599_ExpectTrue()
        {
            Railway.RailwayParts.Clear();
            var station = new Station();
            station.Char = '1';
            Railway.RailwayParts.Add(station);

            var station2 = new Station();
            station2.Char = '2';
            Railway.RailwayParts.Add(station2);

            var train = new Train();
            var timesToConvert = new List<(string StationID, string Time)>
            {
                ("1", "00:00"),
                ("2", "10:00")
            };
            train.ConvertTimes(timesToConvert);
            var clock = new TwentyFourHourClock();
            Program.Clock = clock;

            for (int i = 0; i < 599; i++)
            {
                clock.Tick();
                train.RunTrain(false);
            }
            var index = train.Index;
            Assert.True(0 == index);
        }
        [Fact]
        public void _Train_RuntTrain_600_ExpectTrue()
        {
            Railway.RailwayParts.Clear();
            var station = new Station();
            station.Char = '1';
            Railway.RailwayParts.Add(station);

            var station2 = new Station();
            station2.Char = '2';
            Railway.RailwayParts.Add(station2);

            var train = new Train();
            var timesToConvert = new List<(string StationID, string Time)>
            {
                ("1", "00:00"),
                ("2", "10:00")
            };
            train.ConvertTimes(timesToConvert);
            var clock = new TwentyFourHourClock();
            Program.Clock = clock;

            for (int i = 0; i < 600; i++)
            {
                clock.Tick();
                train.RunTrain(false);
            }
            var index = train.Index;
            Assert.True(1 == index);
        }
        [Fact]
        public void _3Stations_RuntTrain_900_ExpectTrue()
        {
            Railway.RailwayParts.Clear();

            var station = new Station();
            station.Char = '1';
            Railway.RailwayParts.Add(station);

            var station2 = new Station();
            station2.Char = '2';
            Railway.RailwayParts.Add(station2);

            var station3 = new Station();
            station3.Char = '3';
            Railway.RailwayParts.Add(station3);

            var train = new Train();
            var timesToConvert = new List<(string StationID, string Time)>
            {
                ("1", "00:00"),
                ("2", "12:00"),
                ("3", "20:00")
            };
            train.ConvertTimes(timesToConvert);
            var clock = new TwentyFourHourClock();
            Program.Clock = clock;

            for (int i = 0; i < 900; i++)
            {
                clock.Tick();
                train.RunTrain(false);
            }
            var index = train.Index;
            Assert.True(1 == index);
            public void TickAndStation_TrainPlanner_ExpectTrue()
            {
                var trainPlanner = new TrainPlanner(1);
            trainPlanner.StartTrainAt("1", "05:00");
            var ticks = TwentyFourHourClock.TimeToTicks(trainPlanner.DepartureTime);
            Assert.True(ticks == 300);
        }
    }
}
