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
