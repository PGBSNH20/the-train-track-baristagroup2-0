using System;
using System.Linq;
using Xunit;
using TrainConsole;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace TrainEngine.Tests
{
    public class ConsoleUnitTests
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
            var unit = DrawableRailwayPart.ConvertItem(rail);
            Assert.True(unit.Chars == "-");


        }
        [Fact]
        public void JSonTesting_Equality()
        {
            var unit = new DrawableRailwayPart()
            { 
            };
            string tryUnit = "{\"Color\":15,\"CoordinateX\":0,\"CoordinateY\":0,\"Chars\":null}";

        string jUnit = JsonSerializer.Serialize(unit);

            Assert.True(jUnit == tryUnit);
        }

    }
}
