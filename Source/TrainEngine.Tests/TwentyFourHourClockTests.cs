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
    public class TwentyFourHourClockTests
    {
        [Fact]
        public void Simple_Clock_Loop_AssertTrue()
        {
            string x = "0";

            for (int i = 0; i < 9; i++)
            {
                x = i.ToString();
            }
            Assert.True(x == "8");
        }
        [Fact]
        public void Simple_Clock_CorrectTick()
        {
            var clock = new TwentyFourHourClock();
            clock.Ticks = 0;
            clock.TickTimes(8);
            Assert.True(clock.Ticks == 8);
        }
        [Fact]
        public void Modulus_fullDay_ExpectZero()
        {
            int ticks = 1440;
            int ticksToParse = ticks % 1440;
            Assert.True(ticksToParse == 0);
        }
        [Fact]
        public void Modulus_NotFullDay_ExpectEight()
        {
            int ticks = 8;
            int ticksToParse = ticks % 1440;
            Assert.True(ticksToParse == 8);
        }
        [Fact]
        public void Modulus_NotFullDay_ExpectTen()
        {
            int ticks = 10;
            int ticksToParse = ticks % 1440;
            Assert.True(ticksToParse == 10);
        }
        [Fact]
        public void Modulus_Minutes_String_ExpectTen()
        {
            int ticks = 10;
            int minutes = ticks % 1440;
            string min = minutes.ToString();
            Assert.True(min == "10");
        }
        [Fact]
        public void Modulus_Hour_String_ExpectHours()
        {
            int ticks = 60;
            int thisDayTicks = ticks % 1440;
            int hours = thisDayTicks / 60;
            string h = hours.ToString();
            Assert.True(h == "1");
        }
        [Fact]
        public void Modulus_Hour_String_ExpectTwo()
        {
            int ticks = 120;
            int thisDayTicks = ticks % 1440;
            int hours = thisDayTicks / 60;
            string h = hours.ToString();
            Assert.True(h == "2");
        }
        [Fact]
        public void Modulus_Hour_String_FloorOne()
        {
            int ticks = 119;
            int thisDayTicks = ticks % 1440;
            int hours = thisDayTicks / 60;
            string h = hours.ToString();
            Assert.True(h == "1");
        }
        [Fact]
        public void Modulus_HourMinutes_Expect_h1_m1()
        {
            int ticks = 61;
            int thisDayTicks = ticks % 1440;
            int hours = thisDayTicks / 60;
            int min = thisDayTicks % 60;
            string h = hours.ToString();
            string m = min.ToString();

            Assert.True(h == "1" && m == "1");
        }
        [Fact]
        public void Modulus_InsertMinutesDigital_Expect_00_01()
        {
            int ticks = 61;
            int thisDayTicks = ticks % 1440;
            int hours = thisDayTicks / 60;
            int min = thisDayTicks % 60;
            string h = hours.ToString();
            string m = min.ToString();
            string digital = "00:0" + m;

            Assert.True(digital == "00:01");
        }
        [Fact]
        public void Modulus_InsertMinutesDigital_Expect_01_01()
        {
            int ticks = 61;
            int thisDayTicks = ticks % 1440;
            int hours = thisDayTicks / 60;
            int min = thisDayTicks % 60;
            string h = hours.ToString();
            string m = min.ToString();
            string digital = "0" + h + ":0" + m;

            Assert.True(digital == "01:01");
        }
        [Fact]
        public void Modulus_InsertMinutesDigital_Expect_01_11()
        {
            int ticks = 71;
            int thisDayTicks = ticks % 1440;
            int hours = thisDayTicks / 60;
            int min = thisDayTicks % 60;
            string h = hours.ToString();
            string m = min.ToString();

            string digital = "0" + h + ":" + m;

            Assert.True(digital == "01:11");
        }
        [Fact]
        public void Modulus_InsertFullDigital_Expect_00_01()
        {
            int ticks = 1;
            int thisDayTicks = ticks % 1440;
            int hours = thisDayTicks / 60;
            int min = thisDayTicks % 60;
            string h = hours.ToString();
            string m = min.ToString();
            if (m.Length == 1)
                m = "0" + m;
            string digital = "0" + h + ":" + m;

            Assert.True(digital == "00:01");
        }
        [Fact]
        public void Modulus_InsertFullDigital_Expect_11_colon_01()
        {
            int ticks = 661;
            int thisDayTicks = ticks % 1440;
            int hours = thisDayTicks / 60;
            int min = thisDayTicks % 60;
            
            string h = hours.ToString();
            string m = min.ToString();
            if (m.Length == 1)
                m = "0" + m;
            string digital = h + ":" + m;

            Assert.True(digital == "11:01");
        }
        [Fact]
        public void Modulus_InsertFullDigital_Expect_01_colon_01()
        {
            int ticks = 61;
            int thisDayTicks = ticks % 1440;
            int hours = thisDayTicks / 60;
            int min = thisDayTicks % 60;

            string h = hours.ToString();
            if (h.Length == 1)
                h = "0" + h;
            string m = min.ToString();
            if (m.Length == 1)
                m = "0" + m;
            string digital = h + ":" + m;

            Assert.True(digital == "01:01");
        }
        [Fact]
        public void Modulus_DayFullDigital_Expect_0Days_01_colon_01()
        {
            int ticks = 61;
            int days = ticks / 1440;
            int thisDayTicks = ticks % 1440;
            int hours = thisDayTicks / 60;
            int min = thisDayTicks % 60;

            string h = hours.ToString();
            if (h.Length == 1)
                h = "0" + h;
            string m = min.ToString();
            if (m.Length == 1)
                m = "0" + m;
            string digital = h + ":" + m;

            Assert.True(digital == "01:01" && days == 0);
        }
        [Fact]
        public void Modulus_DayFullDigital_Expect_1Days_01_colon_01()
        {
            int ticks = 1501;
            int days = ticks / 1440;
            int thisDayTicks = ticks % 1440;
            int hours = thisDayTicks / 60;
            int min = thisDayTicks % 60;

            string h = hours.ToString();
            if (h.Length == 1)
                h = "0" + h;
            string m = min.ToString();
            if (m.Length == 1)
                m = "0" + m;
            string digital = h + ":" + m;

            Assert.True(digital == "01:01" && days == 1);
        }
        [Fact]
        public void Modulus_DayFullDigital_Expect_1Days_11_colon_11()
        {
            //11*60 = 660
            //24*60=1440
            //660+1440+11=2111
            int ticks = 2111;
            int days = ticks / 1440;
            int thisDayTicks = ticks % 1440;
            int hours = thisDayTicks / 60;
            int min = thisDayTicks % 60;

            string h = hours.ToString();
            if (h.Length == 1)
                h = "0" + h;
            string m = min.ToString();
            if (m.Length == 1)
                m = "0" + m;
            string digital = h + ":" + m;

            Assert.True(digital == "11:11" && days == 1);
        }
        [Fact]
        public void Modulus_DayFullDigital_Expect_1Days_23_colon_01()
        {
            //11*60 = 660
            //24*60=1440
            //660+1440+11=2111
            //+720=2831
            int ticks = 2831;
            int days = ticks / 1440;
            int thisDayTicks = ticks % 1440;
            int hours = thisDayTicks / 60;
            int min = thisDayTicks % 60;

            string h = hours.ToString();
            if (h.Length == 1)
                h = "0" + h;
            string m = min.ToString();
            if (m.Length == 1)
                m = "0" + m;
            string digital = h + ":" + m;

            Assert.True(digital == "23:11" && days == 1);
        }
        [Fact]
        public void Modulus_fullDay_ExpectEight()
        {
            int ticks = 1448;
            int ticksToParse = ticks % 1440;
            Assert.True(ticksToParse == 8);
        }
        [Fact]
        public void Simple_Clock_AssertCorrectString()
        {
            var clock = new TwentyFourHourClock();
            clock.Ticks = 0;
            clock.TickTimes(8);
            var time = clock.Time;
            var equal = Enumerable.SequenceEqual(time, new[] { "0", "0", ":", "0", "8" });
            Assert.True(equal);
        }
        [Fact]
        public void Simple_Clock_Switch_TenSecondDigitToOne()
        {
            var clock = new TwentyFourHourClock();
            clock.Ticks = 0;
            clock.TickTimes(10);
            var time = clock.Time;
            var equal = Enumerable.SequenceEqual(time, new[] { "0", "0", ":", "1", "0" });
            Assert.True(equal);
        }
        [Fact]
        public void Simple_Clock_Switch_HourDigitToOne()
        {
            var clock = new TwentyFourHourClock();
            clock.Ticks = 0;
            clock.TickTimes(60);
            var time = clock.Time;
            var equal = Enumerable.SequenceEqual(time, new[] { "0", "1", ":", "0", "0" });
            Assert.True(equal);
        }
        [Fact]
        public void Simple_Clock_Switch_TenHourDigitToOne()
        {
            var clock = new TwentyFourHourClock();
            clock.Ticks = 0;
            clock.TickTimes(600);
            var time = clock.Time;
            var equal = Enumerable.SequenceEqual(time, new[] { "1", "0", ":", "0", "0" });
            Assert.True(equal);
        }
        [Fact]
        public void Simple_Clock_Switch_TenHourDigitTo25()
        {
            var clock = new TwentyFourHourClock();
            clock.Ticks = 0;
            clock.TickTimes(1500);
            var time = clock.Time;
            var equal = Enumerable.SequenceEqual(time, new[] { "2", "5", ":", "0", "0" });
            Assert.False(equal);
        }
        [Fact]
        public void Simple_Clock_1500Ticks_Assert()
        {
            var clock = new TwentyFourHourClock();
            clock.Ticks = 0;
            clock.TickTimes(1500);
            var time = clock.Time;
            var equal = Enumerable.SequenceEqual(time, new[] { "0", "1", ":", "0", "0" });
            Assert.True(equal);
        }
        [Fact]
        public void Simple_Clock_Assert23()
        {
            var clock = new TwentyFourHourClock();
            clock.Ticks = 0;
            clock.TickTimes(1380);
            var time = clock.Time;
            var equal = Enumerable.SequenceEqual(time, new[] { "2", "3", ":", "0", "0" });
            Assert.True(equal);
        }

        [Fact]
        public void Simple_Clock_AssertMidnight()
        {
            var clock = new TwentyFourHourClock();
            clock.Ticks = 0;
            clock.TickTimes(1440);
            var time = clock.Time;
            var equal = Enumerable.SequenceEqual(time, new[] { "0", "0", ":", "0", "0" });
            Assert.True(equal);
        }
        [Fact]
        public void Simple_Clock_AssertMidnightTwoDays()
        {
            var clock = new TwentyFourHourClock();
            clock.Ticks = 0;
            clock.TickTimes(2880);
            var time = clock.Time;
            var equal = Enumerable.SequenceEqual(time, new[] { "0", "0", ":", "0", "0" });
            Assert.True(equal);
        }
        [Fact]
        public void Simple_Clock_AssertMidnight01TwoDays()
        {
            var clock = new TwentyFourHourClock();
            clock.Ticks = 0;
            clock.TickTimes(2881);
            var time = clock.Time;
            var equal = Enumerable.SequenceEqual(time, new[] { "0", "0", ":", "0", "1" });
            Assert.True(equal);
        }
        [Fact]
        public void Simple_Clock_AssertMidnight01()
        {
            var clock = new TwentyFourHourClock();
            clock.Ticks = 0;
            clock.TickTimes(1441);
            var time = clock.Time;
            var equal = Enumerable.SequenceEqual(time, new[] { "0", "0", ":", "0", "1" });
            Assert.True(equal);
        }
        [Fact]
        public void Simple_Clock_AssertNextDay1111()
        {
            var clock = new TwentyFourHourClock();
            clock.Ticks = 0;
            clock.TickTimes(2111);
            var time = clock.Time;
            var equal = Enumerable.SequenceEqual(time, new[] { "1", "1", ":", "1", "1" });
            Assert.True(equal);
        }
        [Fact]
        public void Simple_Clock_AssertNextDay2311()
        {
            var clock = new TwentyFourHourClock();
            clock.Ticks = 0;
            clock.TickTimes(2831);
            var time = clock.Time;
            var equal = Enumerable.SequenceEqual(time, new[] { "2", "3", ":", "1", "1" });
            Assert.True(equal);
        }
    }
}
