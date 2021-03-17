using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Transactions;

namespace FirstLevelRailway
{

    public class Program
    {
        public enum Demo
        {
            RailwayORM,
            TimeTableBuilder,
            ClockWithStations
        }
        public static List<IMemoryLayer> Layers = new List<IMemoryLayer>();
        public static IClock Clock { get; set; }
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            switch (Demo.ClockWithStations)
            {
                case Demo.RailwayORM:
                    DemoRailwayORM();
                    break;
                case Demo.TimeTableBuilder:
                    DemoTimeTableBuilder();
                    break;
                case Demo.ClockWithStations:
                    DemoClockWithStations();
                    break;
                default:
                    break;
            }

            Console.ReadLine();
        }
        public static void DemoRailwayORM()
        {
            var read = TrackReader.Read(File.ReadAllLines(@"TextFiles/octagon-track.txt"));
            var parts = RailwayPartsORM.Map(read);
            Railway.AppendParts(parts);
            ConsoleWriter.WriteParts(parts);
            Console.WriteLine("press a key to view the parts as json!");
            Console.ReadKey();

            foreach (var part in Railway.RailwayParts)
            {
                WriteFormattedJsonObject(part);
            }
        }
        public static void DemoTimeTableBuilder()
        {
            var timeTable5a = new TimeTableBuilder(5)
             .StartTrainAt("1", "11:00")
             .ArriveTrainAt("2", "11:15")
             .ToPlan();

            var timeTable5b = new TimeTableBuilder(5)
                .StartTrainAt("2", "12:00")
               .ArriveTrainAt("3", "12:15")
               .ToPlan();

            var timeTable5c = new TimeTableBuilder(5)
                .StartTrainAt("3", "12:20")
               .ArriveTrainAt("4", "12:35")
               .ToPlan();

            WriteFormattedJsonObject(timeTable5a);
            WriteFormattedJsonObject(timeTable5b);
            WriteFormattedJsonObject(timeTable5c);
        }
      
        public static void DemoClockWithStations()
        {
            var read = TrackReader.Read(File.ReadAllLines(@"TextFiles/Simple-track.txt"));
            var parts = RailwayPartsORM.Map(read);
            Railway.AppendParts(parts);
            ConsoleWriter.WriteParts(parts);

            var timeTableBuilder = new TimeTableBuilder(1);

            var testORM = new TimeTableORM();
            testORM.Load(5);
            var stationTimes = timeTableBuilder.createStationTimeList();

            Console.SetCursorPosition(0, 0);
            foreach(var timePair in stationTimes)
            { 
                Console.WriteLine(timePair.Item1 + " " + timePair.Item2);
            }
            Console.SetCursorPosition(0, 5);

            var train = new Train();
            train.ConvertStationTimes(stationTimes);
            train.GetFullRoute();

            var clock = new TwentyFourHourClock();
            Clock = clock;
            Thread clockThread = CreateClockThread(500, clock);
            clockThread.Start();

            while (true)
            {
                Thread.Sleep(200);
                train.RunTrain(false);
                RefreshScreen();
            }
        }

        public static void RefreshScreen()
        {
            foreach (var layer in Layers)
            {
                for (int i = 0; i < layer.Drawables.Count; i++)
                {
                    if (layer.Drawables[i] != null)
                        ConsoleWriter.Write(layer.Drawables[i]);
                }
            }
        }

        public static Thread CreateClockThread(int ns_per_tick, IClock clock)
        {
            var clockLayer = new ClockMemoryLayer();
            Layers.Add(clockLayer);
            var timeDisplay = new TimeDisplayer(13, 1, clockLayer);
            var timeKeeper = new TimeKeeper(clock, timeDisplay, ns_per_tick);
            return new Thread(new ThreadStart(() => timeKeeper.StartTime(null)));
        }
        public static void WriteFormattedJsonObject(object objectToParse)
        {
            string jsonObject = System.Text.Json.JsonSerializer.Serialize(objectToParse);
            string newString = "";
            foreach (char chr in jsonObject)
            {
                newString += chr;
                if (chr == ',')
                    newString += '\n';
            }
            Console.WriteLine("Part Type: " + objectToParse.GetType());
            Console.WriteLine(newString);
            Console.WriteLine();
        }
    }
}
