using System;
using System.Linq;
using Xunit;
using TrainConsole;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace TrainEngine.Tests
{
    public class IDrawableTests
    {
        [Fact]
        public void ConsoleUnit_ConvertItem_ExpectTrue()
        {
            var rail = new Rail()
            {
                Char = '-',
                CoordinateX = 1,
                CoordinateY = 1,
            };
            var unit = DrawableRailwayPart.ConvertPart(rail);
            Assert.True(unit.Chars == "-");


        }
        [Fact]
        public void Reflection_Get_Property()
        {
            var unit = new DrawableRailwayPart();

            var property = unit.GetType().GetProperty(nameof(DrawableRailwayPart.Chars));

            Assert.True(property.Name == "Chars");
        }
        [Fact]
        public void DrawableRailwayPart_IsSame_ExpectFalse()
        {
            var unit = new DrawableRailwayPart();
            var unit2 = new DrawableRailwayPart()
            {
                Color = ConsoleColor.Red
            };

            Assert.False(unit.IsSame(unit2));
        }
        [Fact]
        public void DrawableRailwayPart_IsSame_ExpectTrue()
        {
            var unit = new DrawableRailwayPart()
            {
                Color = ConsoleColor.Red
            };
            var unit2 = new DrawableRailwayPart()
            {
                Color = ConsoleColor.Red
            };

            Assert.True(unit.IsSame(unit2));
        }
        [Fact]
        public void DrawableRailwayPart_IsDrawnAndSame_ExpectTrue()
        {
            var unit = new DrawableRailwayPart()
            {
                Color = ConsoleColor.Red,
                IsDrawn = true
            };
            var unit2 = new DrawableRailwayPart()
            {
                Color = ConsoleColor.Red
            };

            Assert.True(unit.IsSame(unit2));
        }
        [Fact]
        public void DrawableRailwayPart_IsDrawnAndOtherChar_ExpectFalse()
        {
            var unit = new DrawableRailwayPart()
            {
                Color = ConsoleColor.Red,
                IsDrawn = true
            };
            var unit2 = new DrawableRailwayPart()
            {
                Color = ConsoleColor.Red,
                Chars = "X"
            };

            Assert.False(unit.IsSame(unit2));
        }
        [Fact]
        public void DrawableRailwayPart_IsNewRail_ExpectSame()
        {
            var rail = new Rail()
            {
                Char = '-',
                CoordinateX = 0,
                CoordinateY = 0
            };
            var item = DrawableRailwayPart.ConvertPart(rail);

            Assert.True(item.IsSame(item));
        }
        [Fact]
        public void DrawableRailwayPart_Rail_Custom_ExpectSame()
        {
            var rail = new Rail()
            {
                Char = '-',
                CoordinateX = 0,
                CoordinateY = 0
            };
            var item = DrawableRailwayPart.ConvertPart(rail);
            var item2 = new DrawableRailwayPart()
            {
                Chars = "-",
                CoordinateX = 0,
                CoordinateY = 0
            };
            Assert.True(item.IsSame(item2));
        }
        [Fact]
        public void DrawableRailwayPart_Rail_Custom_ExpectDifferent()
        {
            var rail = new Rail()
            {
                Char = '-',
                CoordinateX = 0,
                CoordinateY = 0
            };
            var item = DrawableRailwayPart.ConvertPart(rail);
            var item2 = new DrawableRailwayPart()
            {
                Chars = "-",
                CoordinateX = 1,
                CoordinateY = 0
            };
            Assert.False(item.IsSame(item2));
        }
        [Fact]
        public void DrawableRailwayPart_Rail_Color_ExpectDifferent()
        {
            var rail = new Rail()
            {
                Char = '-',
                CoordinateX = 0,
                CoordinateY = 0
            };
            var item = DrawableRailwayPart.ConvertPart(rail);
            var item2 = new DrawableRailwayPart()
            {
                Chars = "-",
                CoordinateX = 0,
                CoordinateY = 0,
                Color = ConsoleColor.Red
            };
            Assert.False(item.IsSame(item2));
        }
    }
}
