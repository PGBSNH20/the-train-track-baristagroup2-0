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
            ScreenMemoryLayer.Drawables.Clear();
            Railway.RailwayItems.Clear();
        }
        public void Dispose()
        {
            ScreenMemoryLayer.Drawables.Clear();
            Railway.RailwayItems.Clear();
        }
        [Fact]
        public void ScreenMemoryLayer_Expect_NotExist()
        {
            ScreenMemoryLayer.Drawables.Clear();
            ScreenMemoryLayer.Drawables.Add(
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

            bool exists = ScreenMemoryLayer.UnitExists(tryUnit);
            Assert.False(exists);
        }
        [Fact]
        public void ScreenMemoryLayer_Expect_Exist()
        {
            ScreenMemoryLayer.Drawables.Clear();
            ScreenMemoryLayer.Drawables.Add(
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
                Chars = "2"
            };

            bool exists = ScreenMemoryLayer.UnitExists(tryUnit);
            Assert.True(exists);
        }
        [Fact]
        public void ScreenMemoryLayer_Expect_NoChange()
        {
            ScreenMemoryLayer.Drawables.Clear();
            ScreenMemoryLayer.Drawables.Add(
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
                Chars = "1"
            };

            bool changed = ScreenMemoryLayer.UnitChanged(tryUnit);
            Assert.False(changed);
        }
        [Fact]
        public void ScreenMemoryLayer_Expect_Changed()
        {
            ScreenMemoryLayer.Drawables.Clear();
            ScreenMemoryLayer.Drawables.Add(
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
                Chars = "2"
            };

            bool changed = ScreenMemoryLayer.UnitChanged(tryUnit);
            Assert.True(changed);
        }
        [Fact]
        public void ScreenMemoryLayer_Expect_NoReplace()
        {
            ScreenMemoryLayer.Drawables.Clear();
            ScreenMemoryLayer.Drawables.Add(
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
                Chars = "1"
            };

            bool replace = ScreenMemoryLayer.TryReplace(tryUnit);
            Assert.False(replace);
        }
        [Fact]
        public void ScreenMemoryLayer_Expect_Replace()
        {
            ScreenMemoryLayer.Drawables.Clear();
            ScreenMemoryLayer.Drawables.Add(
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
                Chars = "2"
            };

            bool replace = ScreenMemoryLayer.TryReplace(tryUnit);
            Assert.True(replace);
        }
        [Fact]
        public void ScreenMemoryLayer_ColorReplace_Expect_Replace()
        {
            ScreenMemoryLayer.Drawables.Clear();
            ScreenMemoryLayer.Drawables.Add(
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

            bool replace = ScreenMemoryLayer.TryReplace(tryUnit);
            Assert.True(replace);
        }
        [Fact]
        public void ScreenMemoryLayer_Expect_ReplacedInList()
        {
            ScreenMemoryLayer.Drawables.Clear();
            ScreenMemoryLayer.Drawables.Add(
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
            ScreenMemoryLayer.TryReplace(tryUnit);
            bool replace = tryUnit==ScreenMemoryLayer.Drawables[0];
            Assert.True(replace);
        }
        [Fact]
        public void ScreenMemoryLayer_tryAppend_Expect_2()
        {
            ScreenMemoryLayer.Drawables.Clear();
            ScreenMemoryLayer.Drawables.Add(
                new DrawableRailwayPart()
                {
                    CoordinateX = 0,
                    CoordinateY = 0,
                    Chars = "1"
                });
            var tryUnit = new DrawableRailwayPart()
            {
                CoordinateX = 1,
                CoordinateY = 0,
                Chars = "1",
                Color = ConsoleColor.Green
            };
            ScreenMemoryLayer.TryAppendUnit(tryUnit);
            var units = ScreenMemoryLayer.Drawables;
            Assert.True(units.Count == 2);
        }
        [Fact]
        public void ScreenMemoryLayer_tryAppend_Expect_1()
        {
            ScreenMemoryLayer.Drawables.Add(
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
            ScreenMemoryLayer.TryAppendUnit(tryUnit);
            var units = ScreenMemoryLayer.Drawables;
            Assert.True(units.Count == 1);
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
            ScreenMemoryLayer.AppendRailway();
            var units = ScreenMemoryLayer.Drawables;
            Assert.True(units.Count == 1);
        }


    }
}
