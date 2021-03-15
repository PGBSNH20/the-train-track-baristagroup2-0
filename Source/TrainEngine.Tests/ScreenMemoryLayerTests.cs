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
            var layer = new RailwayMemoryLayer();
            layer.Drawables.Clear();
            Railway.RailwayItems.Clear();
        }
        public void Dispose()
        {
            var layer = new RailwayMemoryLayer();

            layer.Drawables.Clear();
            Railway.RailwayItems.Clear();
        }
        [Fact]
        public void ScreenMemoryLayer_Expect_NotExist()
        {
            var layer = new RailwayMemoryLayer();
            layer.Drawables.Clear();
            layer.Drawables.Add(
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

            bool exists = layer.IsInDrawables(tryUnit);
            Assert.False(exists);
        }
      
        [Fact]
        public void ScreenMemoryLayer_tryAppend_Expect_2()
        {
            var layer = new RailwayMemoryLayer();
            layer.Drawables.Clear();
            layer.Drawables.Add(
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
            layer.TryAppend(tryUnit);
            var units = layer.Drawables;
            Assert.True(units.Count == 2);
        }
        [Fact]
        public void ScreenMemoryLayer_tryAppend_Expect_1()
        {
            var layer = new RailwayMemoryLayer();
            layer.Drawables.Clear();
            layer.Drawables.Add(
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
            layer.TryAppend(tryUnit);
            var units = layer.Drawables;
            Assert.True(units.Count == 1);
        }
        [Fact]
        public void ScreenMemoryLayer_tryAppDrawn_Expect_Same()
        {
            var layer = new RailwayMemoryLayer();
            var first = new DrawableRailwayPart()
            {
                CoordinateX = 0,
                CoordinateY = 0,
                Chars = "1",
                IsDrawn = true
            };
            layer.Drawables.Add(first);
            var tryUnit = new DrawableRailwayPart()
            {
                CoordinateX = 0,
                CoordinateY = 0,
                Chars = "1"
            };
            layer.TryAppend(tryUnit);
            var units = layer.Drawables;
            Assert.True(units[0] == first);
        }
        [Fact]
        public void ScreenMemoryLayer_AppendRailway_Expect()
        {
            var layer = new RailwayMemoryLayer();
            var rail = new Rail()
            {
                CoordinateX = 1,
                CoordinateY = 1,
                Char = '-'
            };
            Railway.RailwayItems.Add(rail);
            layer.AppendRailwayDrawables();
            var units = layer.Drawables;
            Assert.True(units.Count == 1);
        }

        [Fact]
        public void ScreenMemoryLayer_IsInDrawables_ExpectTrue()
        {
            var layer = new RailwayMemoryLayer();
            var rail = new Rail()
            {
                CoordinateX = 1,
                CoordinateY = 1,
                Char = '-'
            };
            var item = DrawableRailwayPart.ConvertPart(rail);
            layer.Drawables.Add(item);
            bool isInDrawables = layer.IsInDrawables(item);
            Assert.True(isInDrawables);
        }
        [Fact]
        public void ScreenMemoryLayer_IsNotInDrawables_ExpectFalse()
        {
            var layer = new RailwayMemoryLayer();
            var rail = new Rail()
            {
                CoordinateX = 1,
                CoordinateY = 1,
                Char = '-'
            };
            var item = DrawableRailwayPart.ConvertPart(rail);
            bool isInDrawables = layer.IsInDrawables(item);
            Assert.False(isInDrawables);
        }
        [Fact]
        public void ScreenMemoryLayer_IsInDrawablesTrainRail_ExpectTrue()
        {
            var layer = new RailwayMemoryLayer();
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

            layer.Drawables.Add(item);
            bool isInDrawables = layer.IsInDrawables(item2);
            Assert.True(isInDrawables);
        }
        [Fact]
        public void ScreenMemoryLayer_IsInDrawablesTrainRail_ExpectFalse()
        {
            var layer = new RailwayMemoryLayer();
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

            layer.Drawables.Add(item);
            bool isInDrawables = layer.IsInDrawables(item2);
            Assert.False(isInDrawables);
        }
    }
}
