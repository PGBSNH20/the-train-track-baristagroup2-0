using System;
using System.Linq;
using Xunit;
using FirstLevelRailway;
using System.Collections.Generic;
using System.IO;

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
            train.ConvertStationTimes(timesToConvert);

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
            train.ConvertStationTimes(timesToConvert);

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
            train.ConvertStationTimes(timesToConvert);

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
            train.ConvertStationTimes(timesToConvert);
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
            train.ConvertStationTimes(timesToConvert);
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
            train.ConvertStationTimes(timesToConvert);
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
            train.ConvertStationTimes(timesToConvert);
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
            train.ConvertStationTimes(timesToConvert);
            var clock = new TwentyFourHourClock();
            Program.Clock = clock;

            for (int i = 0; i < 900; i++)
            {
                clock.Tick();
                train.RunTrain(false);
            }
            var index = train.Index;
            Assert.True(1 == index);
        }
        [Fact]
        public void TickAndStation_TrainPlanner_ExpectTrue()
        {
            var trainPlanner = new TrainPlanner(1);
            trainPlanner.StartTrainAt("1", "05:00");
            var ticks = TwentyFourHourClock.TimeToTicks(trainPlanner.DepartureTime);
            Assert.True(ticks == 300);
        }
        [Fact]
        public void ConnectStations_raw_2_testFile()
        {
            var array = File.ReadAllLines(@"TrainTestTrack.txt");
            Assert.IsType<string[]>(array);
        }
        [Fact]
        public void ConnectStations_raw_2_test_to_Railway()
        {
            Railway.RailwayParts.Clear();
            var read = TrackReader.Read(File.ReadAllLines(@"TrainTestTrack.txt"));
            var parts = RailwayPartsORM.Map(read);
            Railway.AppendParts(parts);

            Assert.True(parts.Count == 5);
        }
        [Fact]
        public void ConnectStations_raw_2_CheckStation()
        {
            Railway.RailwayParts.Clear();
            var read = TrackReader.Read(File.ReadAllLines(@"TrainTestTrack.txt"));
            var parts = RailwayPartsORM.Map(read);
            Railway.AppendParts(parts);

            var station = parts[0];

            Assert.IsType<Station>(station);
        }
        [Fact]
        public void ConnectStations_raw_2_Check_last()
        {
            Railway.RailwayParts.Clear();
            var read = TrackReader.Read(File.ReadAllLines(@"TrainTestTrack.txt"));
            var parts = RailwayPartsORM.Map(read);
            Railway.AppendParts(parts);

            var station = parts[^1];

            Assert.IsType<Station>(station);
        }
        [Fact]
        public void ConnectStations_raw_2_Check_railType()
        {
            Railway.RailwayParts.Clear();
            var read = TrackReader.Read(File.ReadAllLines(@"TrainTestTrack.txt"));
            var parts = RailwayPartsORM.Map(read);
            Railway.AppendParts(parts);

            var rails = parts.Find(x => x.GetType() == typeof(Rail));

            Assert.IsType<Rail>(rails);
        }
        [Fact]
        public void ConnectStations_raw_2_Check_railTypeList()
        {
            Railway.RailwayParts.Clear();
            var read = TrackReader.Read(File.ReadAllLines(@"TrainTestTrack.txt"));
            var parts = RailwayPartsORM.Map(read);
            Railway.AppendParts(parts);

            var rails = parts.FindAll(x => x.GetType() == typeof(Rail));

            Assert.IsType<Rail>(rails[0]);
        }
        [Fact]
        public void ConnectStations_raw_2_Count_Rails()
        {
            Railway.RailwayParts.Clear();
            var read = TrackReader.Read(File.ReadAllLines(@"TrainTestTrack.txt"));
            var parts = RailwayPartsORM.Map(read);
            Railway.AppendParts(parts);

            var rails = parts.FindAll(x => x.GetType() == typeof(Rail));

            Assert.True(rails.Count == 3);
        }
        [Fact]
        public void ConnectStations_raw_2_Count_FindStation()
        {
            Railway.RailwayParts.Clear();
            var read = TrackReader.Read(File.ReadAllLines(@"TrainTestTrack.txt"));
            var parts = RailwayPartsORM.Map(read);
            Railway.AppendParts(parts);

            var station1 = parts.Find(x => x.Char.ToString() == "1");

            Assert.IsType<Station>(station1);
        }

        [Fact]
        public void ConnectStations_raw_2_Count_Rail_Next_To_station1()
        {
            Railway.RailwayParts.Clear();
            var read = TrackReader.Read(File.ReadAllLines(@"TrainTestTrack.txt"));
            var parts = RailwayPartsORM.Map(read);
            Railway.AppendParts(parts);

            var station1 = parts.Find(x => x.Char.ToString() == "1");
            var rail = parts.Find(x => x.CoordinateX == station1.CoordinateX + 1);
            Assert.IsType<Rail>(rail);
        }
        [Fact]
        public void ConnectStations_raw_2_Count_Rail_Between()
        {
            Railway.RailwayParts.Clear();
            var read = TrackReader.Read(File.ReadAllLines(@"TrainTestTrack.txt"));
            var parts = RailwayPartsORM.Map(read);
            Railway.AppendParts(parts);

            var station1 = parts.Find(x => x.Char.ToString() == "1");
            var station2 = parts.Find(x => x.Char.ToString() == "2");

            var rails = new List<IRailwayPart>();
            bool isRunning = true;
            int x = 1;
            while (isRunning)
            {
                int nextX = station1.CoordinateX + x;
                var partToRight = parts.Find(x => x.CoordinateX == nextX);
                if (partToRight.Char == '2')
                {
                    isRunning = false;
                }
                else
                {
                    rails.Add(partToRight);
                    x++;
                }
            }
            Assert.True(rails.Count == 3);
        }
        [Fact]
        public void ConnectStations_AppendRailsFromTrain()
        {
            Railway.RailwayParts.Clear();
            var read = TrackReader.Read(File.ReadAllLines(@"TrainTestTrack.txt"));
            var parts = RailwayPartsORM.Map(read);
            Railway.AppendParts(parts);

            var timeList = new List<(string ID, string Time)>
            {
                ("1", "00:00"),
                ("2", "00:30"),
            };
            var train = new Train();
            train.ConvertStationTimes(timeList);

            var station1 = train.Route[0].Part;
            var station2 = train.Route[1].Part;

            bool isRunning = true;
            var rails = new List<IRailwayPart>();
            int x = 1;
            while (isRunning)
            {
                int nextX = station1.CoordinateX + x;
                var partToRight = parts.Find(x => x.CoordinateX == nextX);
                if (partToRight.Char == '2')
                {
                    isRunning = false;
                }
                else
                {
                    rails.Add(partToRight);
                    x++;
                }
            }
            Assert.True(rails.Count == 3);
        }
        [Fact]
        public void ConnectStations_CountRail()
        {
            Railway.RailwayParts.Clear();
            var read = TrackReader.Read(File.ReadAllLines(@"TrainTestTrack.txt"));
            var parts = RailwayPartsORM.Map(read);
            Railway.AppendParts(parts);

            var timeList = new List<(string ID, string Time)>
            {
                ("1", "00:00"),
                ("2", "00:40"),
            };
            var train = new Train();
            train.ConvertStationTimes(timeList);

            var station1 = train.Route[0].Part;
            var station2 = train.Route[1].Part;

            bool isRunning = true;
            var rails = new List<IRailwayPart>();
            int x = 1;
            int amountRail = 0;

            while (isRunning)
            {
                int nextX = station1.CoordinateX + x;
                var partToRight = parts.Find(x => x.CoordinateX == nextX);
                if (partToRight.Char == '2')
                {
                    isRunning = false;
                }
                else
                {
                    amountRail++;
                    x++;
                }
            }
            Assert.True(amountRail == 3);
        }
        [Fact]
        public void ConnectStations_TrainRail_Increment()
        {
            Railway.RailwayParts.Clear();
            var read = TrackReader.Read(File.ReadAllLines(@"TrainTestTrack.txt"));
            var parts = RailwayPartsORM.Map(read);
            Railway.AppendParts(parts);

            var timeList = new List<(string ID, string Time)>
            {
                ("1", "00:00"),
                ("2", "00:40"),
            };
            var train = new Train();
            train.ConvertStationTimes(timeList);

            var station1 = train.Route[0].Part;
            var station2 = train.Route[1].Part;

            bool isRunning = true;
            var rails = new List<IRailwayPart>();
            int x = 1;
            int amountRail = 0;

            while (isRunning)
            {
                int nextX = station1.CoordinateX + x;
                var partToRight = parts.Find(x => x.CoordinateX == nextX);
                if (partToRight.Char == '2')
                {
                    isRunning = false;
                }
                else
                {
                    amountRail++;
                    x++;
                }
            }

            double divide = amountRail + 1.0;
            int ticksStation1 = train.Route[0].Ticks;
            int tickStation2 = train.Route[1].Ticks;

            double railIncrement = (tickStation2 - ticksStation1)/divide;
           
            Assert.True(10.0 == railIncrement);
        }
        [Fact]
        public void ConnectStations_AppendRailsToListAtIndex()
        {
            Railway.RailwayParts.Clear();
            var read = TrackReader.Read(File.ReadAllLines(@"TrainTestTrack.txt"));
            var parts = RailwayPartsORM.Map(read);
            Railway.AppendParts(parts);

            var timeList = new List<(string ID, string Time)>
            {
                ("1", "00:00"),
                ("2", "00:40"),
            };
            var train = new Train();
            train.ConvertStationTimes(timeList);

            var station1 = train.Route[0].Part;
            var station2 = train.Route[1].Part;

            bool isRunning = true;
            var rails = new List<IRailwayPart>();
            int x = 1;
            int amountRail = 0;

            while (isRunning)
            {
                int nextX = station1.CoordinateX + x;
                var partToRight = parts.Find(x => x.CoordinateX == nextX);
                if (partToRight.Char == '2')
                {
                    isRunning = false;
                }
                else
                {
                    amountRail++;
                    x++;
                    rails.Add(partToRight);
                }
            }

            double divide = amountRail + 1.0;
            int ticksStation1 = train.Route[0].Ticks;
            int tickStation2 = train.Route[1].Ticks;

            double railIncrement = (tickStation2 - ticksStation1) / divide;

            var railListWithTicks = new List<(IRailwayPart, int)>();
            double add = 0;
            foreach (var rail in rails)
            {
                add += railIncrement;
                railListWithTicks.Add((rail, (int)Math.Floor(add)));
            }

            train.Route.InsertRange(1, railListWithTicks);

            Assert.True(5 == train.Route.Count);
        }
    }
}
