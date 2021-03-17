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
            var trainPlanner = new TimeTableBuilder(1);
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
        //[Fact]
        //public void _3Stations_RuntTrain_900_ExpectTrue()
        //{
        //    Railway.RailwayParts.Clear();

        //    var station = new Station();
        //    station.Char = '1';
        //    Railway.RailwayParts.Add(station);

        //    var station2 = new Station();
        //    station2.Char = '2';
        //    Railway.RailwayParts.Add(station2);

        //    var station3 = new Station();
        //    station3.Char = '3';
        //    Railway.RailwayParts.Add(station3);

        //    var train = new Train();
        //    var timesToConvert = new List<(string StationID, string Time)>
        //    {
        //        ("1", "00:00"),
        //        ("2", "12:00"),
        //        ("3", "20:00")
        //    };
        //    train.ConvertStationTimes(timesToConvert);
        //    var clock = new TwentyFourHourClock();
        //    Program.Clock = clock;

        //    for (int i = 0; i < 900; i++)
        //    {
        //        clock.Tick();
        //        train.RunTrain(false);
        //    }
        //    var index = train.Index;
        //    Assert.True(1 == index);
        //}
        [Fact]
        public void TickAndStation_TrainPlanner_ExpectTrue()
        {
            var trainPlanner = new TimeTableBuilder(1);
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
        [Fact]
        public void Stations3()
        {
            Railway.RailwayParts.Clear();
            var read = TrackReader.Read(File.ReadAllLines(@"TrainTestTrack.txt"));
            var parts = RailwayPartsORM.Map(read);
            Railway.AppendParts(parts);

            var timeList = new List<(string ID, string Time)>
            {
                ("1", "00:00"),
                ("2", "00:40"),
                ("3", "00:50")
            };
            var train = new Train();
            train.ConvertStationTimes(timeList);
            Assert.True(train.Route.Count == 3);
        }
        [Fact]
        public void Stations3_RouteDivide()
        {
            Railway.RailwayParts.Clear();
            var read = TrackReader.Read(File.ReadAllLines(@"TrainTestTrack3Stations.txt"));
            var parts = RailwayPartsORM.Map(read);
            Railway.AppendParts(parts);

            var timeList = new List<(string ID, string Time)>
            {
                ("1", "00:00"),
                ("2", "00:40"),
                ("3", "00:50")
            };
            var train = new Train();
            train.ConvertStationTimes(timeList);
            var station1 = train.Route.Find(x => x.Part.Char == '1');
            var rails1 = RouteDivider.GetRailsRightOf((Station)station1.Part);
            Assert.True(rails1.Count == 3);
        }
        [Fact]
        public void Stations3_RouteDivide_station2()
        {
            Railway.RailwayParts.Clear();
            var read = TrackReader.Read(File.ReadAllLines(@"TrainTestTrack3Stations.txt"));
            var parts = RailwayPartsORM.Map(read);
            Railway.AppendParts(parts);

            var timeList = new List<(string ID, string Time)>
            {
                ("1", "00:00"),
                ("2", "00:40"),
                ("3", "00:50")
            };
            var train = new Train();
            train.ConvertStationTimes(timeList);
            var station1 = train.Route.Find(x => x.Part.Char == '2').Part;
            var rails1 = RouteDivider.GetRailsRightOf((Station)station1);
            Assert.True(rails1.Count == 4);
        }
        [Fact]
        public void Stations3_Find_station3()
        {
            Railway.RailwayParts.Clear();
            var read = TrackReader.Read(File.ReadAllLines(@"TrainTestTrack3Stations.txt"));
            var parts = RailwayPartsORM.Map(read);
            Railway.AppendParts(parts);

            var timeList = new List<(string ID, string Time)>
            {
                ("1", "00:00"),
                ("2", "00:40"),
                ("3", "00:50")
            };
            var train = new Train();
            train.ConvertStationTimes(timeList);
            var route = train.Route;
            var station3 = route.Find(x => x.Part.Char == '3').Part;
           Assert.IsType<Station>(station3);
        }
        [Fact]
        public void Stations3_RightRails_RouteDivider_station3()
        {
            Railway.RailwayParts.Clear();
            var read = TrackReader.Read(File.ReadAllLines(@"TrainTestTrack3Stations.txt"));
            var parts = RailwayPartsORM.Map(read);
            Railway.AppendParts(parts);

            var timeList = new List<(string ID, string Time)>
            {
                ("1", "00:00"),
                ("2", "00:40"),
                ("3", "00:50")
            };
            var train = new Train();
            train.ConvertStationTimes(timeList);
            var route = train.Route;
            var station3 = route.Find(x => x.Part.Char == '3').Part;
            var rails = RouteDivider.GetRailsRightOf((Station)station3);
            Assert.True(rails == null);
        }
        [Fact]
        public void Stations3_RightRails_RouteDivider_station2()
        {
            Railway.RailwayParts.Clear();
            var read = TrackReader.Read(File.ReadAllLines(@"TrainTestTrack3Stations.txt"));
            var parts = RailwayPartsORM.Map(read);
            Railway.AppendParts(parts);

            var timeList = new List<(string ID, string Time)>
            {
                ("1", "00:00"),
                ("2", "00:40"),
                ("3", "00:50")
            };
            var train = new Train();
            train.ConvertStationTimes(timeList);
            var route = train.Route;
            var station3 = route.Find(x => x.Part.Char == '2').Part;
            var rails = RouteDivider.GetRailsRightOf((Station)station3);
            Assert.True(rails.Count == 4);
        }
        [Fact]
        public void Stations3_RightRails_RouteDivider_RailsWithTicks()
        {
            Railway.RailwayParts.Clear();
            var read = TrackReader.Read(File.ReadAllLines(@"TrainTestTrack3Stations.txt"));
            var parts = RailwayPartsORM.Map(read);
            Railway.AppendParts(parts);

            var timeList = new List<(string ID, string Time)>
            {
                ("1", "00:00"),
                ("2", "00:40"),
                ("3", "00:50")
            };
            var train = new Train();
            var route = train.Route;
            route.Clear();
            train.ConvertStationTimes(timeList);
            var station1WithTicks = train.Route[0];
            var station2WithTicks = train.Route[1];
            var rails = RouteDivider.GetRailsRightOf((Station)station1WithTicks.Part);
            var railsWithTicks = RouteDivider.GetRailsWithTicks(station1WithTicks.Ticks, station2WithTicks.Ticks, rails);
            Assert.True(railsWithTicks.Count==3);
        }
        [Fact]
        public void Station1_2_RailsBetweenWithTicks_Expect10()
        {
            Railway.RailwayParts.Clear();
            var read = TrackReader.Read(File.ReadAllLines(@"TrainTestTrack3Stations.txt"));
            var parts = RailwayPartsORM.Map(read);
            Railway.AppendParts(parts);

            var timeList = new List<(string ID, string Time)>
            {
                ("1", "00:00"),
                ("2", "00:40"),
                ("3", "00:50")
            };
            var train = new Train();

            var route = train.Route;
            route.Clear();
            train.ConvertStationTimes(timeList);
            var station1WithTicks = train.Route[0];
            var station2WithTicks = train.Route[1];
            var rails = RouteDivider.GetRailsRightOf((Station)station1WithTicks.Part);
            var railsWithTicks = RouteDivider.GetRailsWithTicks(station1WithTicks.Ticks, station2WithTicks.Ticks, rails);
            Assert.True(railsWithTicks[0].Ticks == 10);
        }
        [Fact]
        public void Station1_2_RailsBetweenWithTicks_Expect30()
        {
            Railway.RailwayParts.Clear();
            var read = TrackReader.Read(File.ReadAllLines(@"TrainTestTrack3Stations.txt"));
            var parts = RailwayPartsORM.Map(read);
            Railway.AppendParts(parts);

            var timeList = new List<(string ID, string Time)>
            {
                ("1", "00:00"),
                ("2", "00:40"),
                ("3", "00:50")
            };
            var train = new Train();
            var route = train.Route;
            route.Clear();

            train.ConvertStationTimes(timeList);
            var station1WithTicks = train.Route[0];
            var station2WithTicks = train.Route[1];
            var rails = RouteDivider.GetRailsRightOf((Station)station1WithTicks.Part);
            var railsWithTicks = RouteDivider.GetRailsWithTicks(station1WithTicks.Ticks, station2WithTicks.Ticks, rails);
            Assert.True(railsWithTicks[^1].Ticks == 30);
        }
        [Fact]
        public void Station1_2_TicksBetween_CompareList_ExpectTrue()
        {
            Railway.RailwayParts.Clear();
            var read = TrackReader.Read(File.ReadAllLines(@"TrainTestTrack3Stations.txt"));
            var parts = RailwayPartsORM.Map(read);
            Railway.AppendParts(parts);

            var timeList = new List<(string ID, string Time)>
            {
                ("1", "00:00"),
                ("2", "00:40"),
                ("3", "00:50")
            };
            var train = new Train();
            var route = train.Route;
            route.Clear();

            train.ConvertStationTimes(timeList);
            var station1WithTicks = train.Route[0];
            var station2WithTicks = train.Route[1];
            var rails = RouteDivider.GetRailsRightOf((Station)station1WithTicks.Part);
            var railsWithTicks = RouteDivider.GetRailsWithTicks(station1WithTicks.Ticks, station2WithTicks.Ticks, rails);

            var expectedTicks = new List<int> {10, 20, 30};

            var actualTicks = railsWithTicks.Select(x => x.Ticks).ToList();

            Assert.True(actualTicks.Except(expectedTicks).ToList().Count == 0);
        }
        //[Fact]
        //public void Station2_3_TicksBetween_CompareList_ExpectTrue()
        //{
        //    Railway.RailwayParts.Clear();
        //    var read = TrackReader.Read(File.ReadAllLines(@"TrainTestTrack3Stations.txt"));
        //    var parts = RailwayPartsORM.Map(read);
        //    Railway.AppendParts(parts);

        //    var timeList = new List<(string ID, string Time)>
        //    {
        //        ("1", "00:00"),
        //        ("2", "00:40"),
        //        ("3", "00:50")
        //    };
        //    var train = new Train();
        //    var route = train.Route;
        //    route.Clear();

        //    train.ConvertStationTimes(timeList);
        //    var station1WithTicks = train.Route[1];
        //    var station2WithTicks = train.Route[2];
        //    var rails = RouteDivider.GetRailsRightOf((Station)station1WithTicks.Part);
        //    var railsWithTicks = RouteDivider.GetRailsWithTicks(station1WithTicks.Ticks, station2WithTicks.Ticks, rails);

        //    var expectedTicks = new List<int> { 42, 44, 46, 48 };

        //    var actualTicks = railsWithTicks.Select(x => x.Ticks).ToList();

        //    Assert.True(actualTicks.Except(expectedTicks).ToList().Count == 0);
        //}
        //[Fact]
        //public void Train_AddSomeRailsToRoute_ExpectTrue()
        //{
        //    Railway.RailwayParts.Clear();
        //    var read = TrackReader.Read(File.ReadAllLines(@"TrainTestTrack3Stations.txt"));
        //    var parts = RailwayPartsORM.Map(read);
        //    Railway.AppendParts(parts);

        //    var timeList = new List<(string ID, string Time)>
        //    {
        //        ("1", "00:00"),
        //        ("2", "00:40"),
        //        ("3", "00:50")
        //    };
        //    var train = new Train();
        //    var route = train.Route;
        //    route.Clear();

        //    train.ConvertStationTimes(timeList);
        //    var list = train.RailWithTicksBetween(0, 1);

        //    var expectedTicks = new List<int> { 10, 20, 30};

        //    var actualTicks = list.Select(x => x.Ticks).ToList();

        //    //Assert.True(actualTicks.Except(expectedTicks).ToList().Count == 0);
        //}
        [Fact]
        public void Train_AddSomeRailsToRouteAll_ExpectTrue()
        {
            Railway.RailwayParts.Clear();
            var read = TrackReader.Read(File.ReadAllLines(@"TrainTestTrack3Stations.txt"));
            var parts = RailwayPartsORM.Map(read);
            Railway.AppendParts(parts);

            var timeList = new List<(string ID, string Time)>
            {
                ("1", "00:00"),
                ("2", "00:40"),
                ("3", "00:50")
            };
            var train = new Train();
            var route = train.Route;
            route.Clear();

            train.ConvertStationTimes(timeList);
            train.AddRailTimes();

            var trainRoute = train.Route;

            Assert.True(trainRoute.Count == 5);
        }
    }
}
