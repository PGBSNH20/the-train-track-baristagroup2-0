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
    public class RailwayTests : IDisposable
    {
        public RailwayTests()
        {
            ScreenMemoryLayer.Drawables.Clear();
            Railway.RailwayItems.Clear();
        }
        public void Dispose()
        {
            ScreenMemoryLayer.Drawables.Clear();
            Railway.RailwayItems.Clear();
        }
        [Fact]
        public void RailwayTestFull_9Parts()
        {
            var charCoord = TrainTrackReader.Read(new string[] { "---", "111", "<<<" });
            RailwayPartsORM.Map(charCoord);
            ScreenMemoryLayer.AppendRailway();
            int units = ScreenMemoryLayer.Drawables.Count;
            Assert.True(units == 9);
        }
        [Fact]
        public void RailwayTestFull_6Parts()
        {
            var charCoord = TrainTrackReader.Read(new string[] { "- -", "1 1", "< <" });
            RailwayPartsORM.Map(charCoord);
            ScreenMemoryLayer.AppendRailway();
            int units = ScreenMemoryLayer.Drawables.Count;
            Assert.True(units == 6);
        }


    }
}
