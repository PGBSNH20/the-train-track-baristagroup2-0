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
    public class RailwayTests
    {
        [Fact]
        public void RailwayTestFull_9Parts()
        {
            var layer = new RailwayMemoryLayer();
            var charCoord = TrainTrackReader.Read(new string[] { "---", "111", "<<<" });
            RailwayPartsORM.Map(charCoord);
            layer.AppendRailwayDrawables();
            int units = layer.Drawables.Count;
            Assert.True(units == 9);
        }
        [Fact]
        public void RailwayTestFull_6Parts()
        {
            var layer = new RailwayMemoryLayer();
            var charCoord = TrainTrackReader.Read(new string[] { "- -", "1 1", "< <" });
            RailwayPartsORM.Map(charCoord);
            layer.AppendRailwayDrawables();
            int units = layer.Drawables.Count;
            Assert.True(units == 6);
        }


    }
}
