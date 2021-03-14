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
    public class RailwayLocatorTests : IDisposable
    {
        public RailwayLocatorTests()
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
        public void RailwayLocator_LocateWithId_ExpectFromIStation()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainConsole.TrainTrackReader.Read(new string[] { "[1]" });
            var railParts = RailwayPartsORM.Map(dataRead);
            var station = RailwayLocator.LocateWithId(2);
            Assert.IsAssignableFrom<IStation>(station);
        }
        [Fact]
        public void RailwayLocator_LocateWithId_ExpectAssignableFromIRailwayItem()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainConsole.TrainTrackReader.Read(new string[] { "[1]" });
            var railParts = RailwayPartsORM.Map(dataRead);
            var station = RailwayLocator.LocateWithId(1);
            Assert.IsAssignableFrom<IRailwayItem>(station);
        }
        [Fact]
        public void RailwayLocator_LocateWithId_ExpectAssignableFromIRailwayPart()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainConsole.TrainTrackReader.Read(new string[] { "[1]" });
            var railParts = RailwayPartsORM.Map(dataRead);
            var station = RailwayLocator.LocateWithId(1);
            Assert.IsAssignableFrom<IRailwayPart>(station);
        }
        [Fact]
        public void RailwayPart_ExpectAssignableFromIRail()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainConsole.TrainTrackReader.Read(new string[] { "-" });
            var railParts = RailwayPartsORM.Map(dataRead);
            var rail = Railway.RailwayItems[0];
            Assert.IsAssignableFrom<IRail>(rail);
        }
        [Fact]
        public void RailwayPart_ExpectRail()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainConsole.TrainTrackReader.Read(new string[] { "-" });
            var railParts = RailwayPartsORM.Map(dataRead);
            var rail = Railway.RailwayItems[0];
            Assert.IsType<Rail>(rail);
        }
        [Fact]
        public void RailwayPart_ExpectCrossing()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainConsole.TrainTrackReader.Read(new string[] { "=" });
            var railParts = RailwayPartsORM.Map(dataRead);
            var crossing = Railway.RailwayItems[0];
            Assert.IsType<Crossing>(crossing);
        }
        [Fact]
        public void RailwayPart_ExpectSwitch()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainConsole.TrainTrackReader.Read(new string[] { "<" });
            var railParts = RailwayPartsORM.Map(dataRead);
            var railSwitch = Railway.RailwayItems[0];
            Assert.IsType<RailSwitch>(railSwitch);
        }
        [Fact]
        public void RailwayPart_ExpectSwitch2()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainConsole.TrainTrackReader.Read(new string[] { ">" });
            var railParts = RailwayPartsORM.Map(dataRead);
            var railSwitch = Railway.RailwayItems[0];
            Assert.IsType<RailSwitch>(railSwitch);
        }
        [Fact]
        public void RailwayPart_ExpectRail2()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainConsole.TrainTrackReader.Read(new string[] { "\\" });
            var railParts = RailwayPartsORM.Map(dataRead);
            var rail = Railway.RailwayItems[0];
            Assert.IsType<Rail>(rail);
        }
        [Fact]
        public void RailwayPart_ExpectRail3()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "/" });
            var railParts = RailwayPartsORM.Map(dataRead);
            var rail = Railway.RailwayItems[0];
            Assert.IsType<Rail>(rail);
        }
        [Fact]
        public void RailwayLocator_LocateWithId_ExpectNotRail()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainConsole.TrainTrackReader.Read(new string[] { "[1]" });
            var railParts = RailwayPartsORM.Map(dataRead);
            var rail = RailwayLocator.LocateWithId(1);
            Assert.IsNotType<Station>(rail);
        }
        [Fact]
        public void RailwayLocator_LocateWithId_ExpectFromStation()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainConsole.TrainTrackReader.Read(new string[] { "[1]" });
            var railParts = RailwayPartsORM.Map(dataRead);
            var station = RailwayLocator.LocateWithId(2);
            Assert.IsAssignableFrom<Station>(station);
        }
        [Fact]
        public void RailwayLocator_LocateWithPosXY_ExpectIStation()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainConsole.TrainTrackReader.Read(new string[] { "[1]" });
            var railParts = RailwayPartsORM.Map(dataRead);
            var station = RailwayLocator.LocateWithPosXY((1, 0));
            Assert.IsAssignableFrom<IStation>(station);
        }
        [Fact]
        public void RailwayLocator_LocateWithPosXY_ExpectStation()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainConsole.TrainTrackReader.Read(new string[] { "[1]" });
            var railParts = RailwayPartsORM.Map(dataRead);
            var station = RailwayLocator.LocateWithPosXY((1, 0));
            Assert.IsAssignableFrom<Station>(station);
        }
        [Fact]
        public void RailwayLocator_LocateWithPosXY_ExpectRail()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainConsole.TrainTrackReader.Read(new string[] { "[1]" });
            var railParts = RailwayPartsORM.Map(dataRead);
            var rail = RailwayLocator.LocateWithPosXY((0, 0));
            Assert.IsType<Rail>(rail);
        }
        [Fact]
        public void RailwayLocator_LocateWithId_ExpectNull()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainConsole.TrainTrackReader.Read(new string[] { "[1]" });
            var railParts = RailwayPartsORM.Map(dataRead);
            var station = RailwayLocator.LocateWithId(99);
            Assert.True(station == null);
        }
        [Fact]
        public void RailwayLocator_LocateUp_ExpectSwitch()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainConsole.TrainTrackReader.Read(new string[] { "-->", "-=-" });
            RailwayPartsORM.Map(dataRead);
            var station = Railway.RailwayItems[5];
            var up = RailwayLocator.LocateUp((IRailwayPart)station);
            Assert.IsType<RailSwitch>(up);
        }
        [Fact]
        public void RailwayLocator_LocateUpRight_ExpectSwitch()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainConsole.TrainTrackReader.Read(new string[] { "--<", "-=-" });
            RailwayPartsORM.Map(dataRead);
            var crossing = Railway.RailwayItems[4];
            var upRight = RailwayLocator.LocateUpRight((IRailwayPart)crossing);
            Assert.IsType<RailSwitch>(upRight);
        }
        [Fact]
        public void RailwayLocator_LocateRight_ExpectStation()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainConsole.TrainTrackReader.Read(new string[] { "-1-" });
            RailwayPartsORM.Map(dataRead);
            var rail = Railway.RailwayItems[0];
            var right = RailwayLocator.LocateRight((IRailwayPart)rail);
            Assert.IsType<Station>(right);
        }
        [Fact]
        public void RailwayLocator_LocateDownRight_ExpectRail()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainConsole.TrainTrackReader.Read(new string[] { "111", "1-1" });
            RailwayPartsORM.Map(dataRead);
            var station = Railway.RailwayItems[0];
            var downRight = RailwayLocator.LocateDownRight((IRailwayPart)station);
            Assert.IsType<Rail>(downRight);
        }

        [Fact]
        public void RailwayLocator_LocateDown_ExpectCrossing()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainConsole.TrainTrackReader.Read(new string[] { "-1-", "-=-" });
            RailwayPartsORM.Map(dataRead);
            var station = Railway.RailwayItems[1];
            var down = RailwayLocator.LocateDown((IRailwayPart)station);
            Assert.IsType<Crossing>(down);
        }
        [Fact]
        public void RailwayLocator_LocateDownLeft_ExpectCrossing()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainConsole.TrainTrackReader.Read(new string[] { "---", "=--" });
            RailwayPartsORM.Map(dataRead);
            var rail = Railway.RailwayItems[1];
            var downLeft = RailwayLocator.LocateDownLeft((IRailwayPart)rail);
            Assert.IsType<Crossing>(downLeft);
        }
        [Fact]
        public void RailwayLocator_LocateLeft_ExpectRail()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainConsole.TrainTrackReader.Read(new string[] { "-1-" });
            RailwayPartsORM.Map(dataRead);
            var station = Railway.RailwayItems[1];
            var left = RailwayLocator.LocateLeft((IRailwayPart)station);
            Assert.IsType<Rail>(left);
        }
        [Fact]
        public void RailwayLocator_UpLeft_ExpectSwitch()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "=<=", "===" });
            RailwayPartsORM.Map(dataRead);
            var crossing = Railway.RailwayItems[5];
            var upLeft = RailwayLocator.LocateUpLeft((IRailwayPart)crossing);
            Assert.IsType<RailSwitch>(upLeft);
        }
        [Fact]
        public void RailwayLocator_Up_ExpectNull()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainConsole.TrainTrackReader.Read(new string[] { "=<=", "===" });
            RailwayPartsORM.Map(dataRead);
            var station = Railway.RailwayItems[0];
            var upLeft = RailwayLocator.LocateUpLeft((IRailwayPart)station);

            Assert.True(upLeft == null);
        }
    }
}
