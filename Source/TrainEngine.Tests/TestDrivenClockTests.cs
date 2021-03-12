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
    public class TestDrivenClockTests
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
        public void Simple_Clock_AssertCorrectString()
        {
            var clock = new TestDrivenClock();
            clock.Tick(8);
            Assert.True(clock.Time == new[] { "0", "8" });
        }
        [Fact]
        public void Simple_Clock_CorrectTick()
        {
            var clock = new TestDrivenClock();
            clock.Tick(8);
            Assert.True(clock.Ticks == 8);
        }
        [Fact]
        public void Simple_Clock_Switch_TenSecondDigit()
        {
            var clock = new TestDrivenClock();
            clock.Tick(10);
            Assert.True(clock.Time == "10");
        }
    }
}
