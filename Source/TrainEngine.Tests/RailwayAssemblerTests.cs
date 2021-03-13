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
    public class RailwayAssemblerTests : IDisposable

    {
        public RailwayAssemblerTests()
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
        public void RailwayAssembler_LocatePartConnections_ExpectTwo()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "[1]" });
            var railParts = RailwayPartsORM.Map(dataRead);
            var station = railParts[1];
            var connections = RailwayAssembler.LocatePartConnections(station);
            var countConn = connections.Count;
            Assert.True(connections.Count == 2);
        }
        [Fact]
        public void RailwayAssembler_LocatePartConnections_Expect1()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "1-" });
            var railParts = RailwayPartsORM.Map(dataRead);
            var station = railParts[0];
            var connections = RailwayAssembler.LocatePartConnections(station);
            Assert.True(connections.Count == 1);
        }
        [Fact]
        public void RailwayAssembler_LocatePartConnections_Expect2()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "-1-" });
            var railParts = RailwayPartsORM.Map(dataRead);
            var station = railParts[1];
            var connections = RailwayAssembler.LocatePartConnections(station);
            Assert.True(connections.Count == 2);
        }
        [Fact]
        public void RailwayAssembler_LocatePartConnections_Expect8()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "---", "-1-", "---" });
            var railParts = RailwayPartsORM.Map(dataRead);
            var station = railParts[4];
            var connections = RailwayAssembler.LocatePartConnections(station);
            Assert.True(connections.Count == 8);
        }
        [Fact]
        public void RailwayAssembler_Assemble_ExpectNoException()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "[1]" });
            var railParts = RailwayPartsORM.Map(dataRead);
            try
            {
                RailwayAssembler.Assemble(railParts);
            }
            catch (Exception)
            {
                throw new Exception("RailwayAssembler_Assemble_ExpectNoException throw an exception");
            }
        }
        [Fact]
        public void RailwayAssembler_Assemble_LocatePartConnections_Expect8()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "---", "-1-", "---" });
            var railParts = RailwayPartsORM.Map(dataRead);
            var station = railParts[4];
            RailwayAssembler.Assemble(railParts);

            Assert.True(station.Connections.Count == 8);
        }
        [Fact]
        public void RailwayAssembler_Assemble_LocatePartConnections_Expect0()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "1" });
            var railParts = RailwayPartsORM.Map(dataRead);
            var station = railParts[0];
            RailwayAssembler.Assemble(railParts);

            Assert.True(station.Connections.Count == 0);
        }
        [Fact]
        public void RailwayAssembler_Assemble_LocatePartConnections_Expect2()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "  /", " / ", "/  " });
            var railParts = RailwayPartsORM.Map(dataRead);
            var rail = railParts[1];
            RailwayAssembler.Assemble(railParts);

            Assert.True(rail.Connections.Count == 2);
        }
        [Fact]
        public void RailwayAssembler_Assemble_LocatePartConnections_ExpectStation()
        {
            Railway.RailwayItems.Clear();
            var dataRead = TrainTrackReader.Read(new string[] { "   ", " / ", "1  " });
            var railParts = RailwayPartsORM.Map(dataRead);
            var rail = railParts[0];
            RailwayAssembler.Assemble(railParts);
            var station = rail.Connections[0];
            Assert.IsType<Station>(station);
        }
    }
}
