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
            var ticks = TwentyFourHourClock.TimeToTicks(trainPlanner.StartTime);
            Assert.True(ticks == 300);
        }
        [Fact]
        public void TickAndStation_TrainPlanner_ExpectTrue()
        {
            var trainPlanner = new TrainPlanner(1);
            trainPlanner.StartTrainAt("1", "05:00");
            var ticks = TwentyFourHourClock.TimeToTicks(trainPlanner.StartTime);
            Assert.True(ticks == 300);
        }
    }
}
