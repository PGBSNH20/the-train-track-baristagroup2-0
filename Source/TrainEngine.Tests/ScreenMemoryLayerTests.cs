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
    public class ScreenMemoryLayerTests : IDisposable
    {
        public ScreenMemoryLayerTests()
        {
            RailwayMemoryLayer.Drawables.Clear();
            Railway.RailwayItems.Clear();
        }
        public void Dispose()
        {
            RailwayMemoryLayer.Drawables.Clear();
            Railway.RailwayItems.Clear();
        }
        [Fact]
        public void ScreenMemoryLayer_Expect_NotExist()
        {
            RailwayMemoryLayer.Drawables.Clear();
            RailwayMemoryLayer.Drawables.Add(
                new DrawableRailwayPart()
                {
                    CoordinateX = 0,
                    CoordinateY = 0,
                    Chars = "1"
                });
            var tryUnit = new DrawableRailwayPart()
            {
                CoordinateX = 0,
                CoordinateY = 1,
                Chars = "2"
            };

            bool exists = RailwayMemoryLayer.IsInDrawables(tryUnit);
            Assert.False(exists);
        }
      
        [Fact]
        public void ScreenMemoryLayer_tryAppend_Expect_2()
        {
            RailwayMemoryLayer.Drawables.Clear();
            RailwayMemoryLayer.Drawables.Add(
            new DrawableRailwayPart()
            {
                CoordinateX = 0,
                CoordinateY = 0,
                Chars = "1",
            });

            var tryUnit = new DrawableRailwayPart()
            {
                CoordinateX = 2,
                CoordinateY = 2,
                Chars = "2",
            };
            RailwayMemoryLayer.TryAppend(tryUnit);
            var units = RailwayMemoryLayer.Drawables;
            Assert.True(units.Count == 2);
        }
        [Fact]
        public void ScreenMemoryLayer_tryAppend_Expect_1()
        {
            RailwayMemoryLayer.Drawables.Clear();
            RailwayMemoryLayer.Drawables.Add(
                new DrawableRailwayPart()
                {
                    CoordinateX = 0,
                    CoordinateY = 0,
                    Chars = "1"
                });
            var tryUnit = new DrawableRailwayPart()
            {
                CoordinateX = 0,
                CoordinateY = 0,
                Chars = "1",
                Color = ConsoleColor.Green
            };
            RailwayMemoryLayer.TryAppend(tryUnit);
            var units = RailwayMemoryLayer.Drawables;
            Assert.True(units.Count == 1);
        }
        [Fact]
        public void ScreenMemoryLayer_tryAppDrawn_Expect_Same()
        {
            var first = new DrawableRailwayPart()
            {
                CoordinateX = 0,
                CoordinateY = 0,
                Chars = "1",
                IsDrawn = true
            };
            RailwayMemoryLayer.Drawables.Add(first);
            var tryUnit = new DrawableRailwayPart()
            {
                CoordinateX = 0,
                CoordinateY = 0,
                Chars = "1"
            };
            RailwayMemoryLayer.TryAppend(tryUnit);
            var units = RailwayMemoryLayer.Drawables;
            Assert.True(units[0] == first);
        }
        [Fact]
        public void ScreenMemoryLayer_AppendRailway_Expect()
        {
            var rail = new Rail()
            {
                CoordinateX = 1,
                CoordinateY = 1,
                Char = '-'
            };
            Railway.RailwayItems.Add(rail);
            RailwayMemoryLayer.AppendRailwayDrawables();
            var units = RailwayMemoryLayer.Drawables;
            Assert.True(units.Count == 1);
        }

        [Fact]
        public void ScreenMemoryLayer_IsInDrawables_ExpectTrue()
        {
            var rail = new Rail()
            {
                CoordinateX = 1,
                CoordinateY = 1,
                Char = '-'
            };
            var item = DrawableRailwayPart.ConvertPart(rail);
            RailwayMemoryLayer.Drawables.Add(item);
            bool isInDrawables = RailwayMemoryLayer.IsInDrawables(item);
            Assert.True(isInDrawables);
        }
        [Fact]
        public void ScreenMemoryLayer_IsNotInDrawables_ExpectFalse()
        {
            var rail = new Rail()
            {
                CoordinateX = 1,
                CoordinateY = 1,
                Char = '-'
            };
            var item = DrawableRailwayPart.ConvertPart(rail);
            bool isInDrawables = RailwayMemoryLayer.IsInDrawables(item);
            Assert.False(isInDrawables);
        }
        [Fact]
        public void ScreenMemoryLayer_IsInDrawablesTrainRail_ExpectTrue()
        {
            var rail = new Rail()
            {
                CoordinateX = 1,
                CoordinateY = 1,
                Char = '-'
            };
            var item = DrawableRailwayPart.ConvertPart(rail);
            var station = new Station()
            {
                CoordinateX = 1,
                CoordinateY = 1,
                Char = '-'
            };
            var item2 = DrawableRailwayPart.ConvertPart(station);

            RailwayMemoryLayer.Drawables.Add(item);
            bool isInDrawables = RailwayMemoryLayer.IsInDrawables(item2);
            Assert.True(isInDrawables);
        }
        [Fact]
        public void ScreenMemoryLayer_IsInDrawablesTrainRail_ExpectFalse()
        {
            var rail = new Rail()
            {
                CoordinateX = 1,
                CoordinateY = 1,
                Char = '-'
            };
            var item = DrawableRailwayPart.ConvertPart(rail);
            var station = new Station()
            {
                CoordinateX = 1,
                CoordinateY = 1,
                Char = '+'
            };
            var item2 = DrawableRailwayPart.ConvertPart(station);

            RailwayMemoryLayer.Drawables.Add(item);
            bool isInDrawables = RailwayMemoryLayer.IsInDrawables(item2);
            Assert.False(isInDrawables);
        }
    }
}
