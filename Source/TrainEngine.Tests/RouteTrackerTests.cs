using Xunit;
using TrainConsole;
namespace TrainEngine.Tests
{
    public class RouteTrackerTests
    {
        [Fact]
        public void RouteTracker_SimpleTrack_ExpectTrue()
        {
            Railway.RailwayItems.Clear();
            var layer = new RailwayMemoryLayer();
            var charCoord = TrainTrackReader.Read(new string[] { "-----" });
            var parts = RailwayPartsORM.Map(charCoord);
            RailwayAssembler.Assemble(parts);
            var start = parts[0];
            var end = parts[^1];
            var route = RouteTracker.Track(start, end);

            Assert.True(route.Count == 5);
        }
        [Fact]
        public void RouteTracker_Track_ExpectFalse()
        {
            Railway.RailwayItems.Clear();
            var layer = new RailwayMemoryLayer();
            var charCoord = TrainTrackReader.Read(new string[] { "-- --" });
            var parts = RailwayPartsORM.Map(charCoord);
            RailwayAssembler.Assemble(parts);
            var start = parts[0];
            var end = parts[^1];
            var route = RouteTracker.Track(start, end);

            Assert.False(route.Count == 4);
        }
        [Fact]
        public void RouteTracker_Track_ExpectTrue()
        {
            Railway.RailwayItems.Clear();
            var layer = new RailwayMemoryLayer();
            var charCoord = TrainTrackReader.Read(new string[] { "-- --" });
            var parts = RailwayPartsORM.Map(charCoord);
            RailwayAssembler.Assemble(parts);
            var start = parts[0];
            var end = parts[^1];
            var route = RouteTracker.Track(start, end);

            Assert.True(route.Count == 2);
        }
        [Fact]
        public void RouteTracker_ShortTrack_StationStation_ExpectTrue()
        {
            Railway.RailwayItems.Clear();
            var layer = new RailwayMemoryLayer();
            var charCoord = TrainTrackReader.Read(new string[] { "-1--2-" });
            var parts = RailwayPartsORM.Map(charCoord);
            RailwayAssembler.Assemble(parts);
            var start = parts[1];
            var end = parts[^2];
            var route = RouteTracker.Track(start, end);

            Assert.True(route.Count == 4);
        }
        [Fact]
        public void RouteTracker_ShortTrack_StationStationReverse_ExpectTrue()
        {
            Railway.RailwayItems.Clear();
            var layer = new RailwayMemoryLayer();
            var charCoord = TrainTrackReader.Read(new string[] { "-1--2" });
            var parts = RailwayPartsORM.Map(charCoord);
            RailwayAssembler.Assemble(parts);
            var start = parts[^1];
            var end = parts[1];
            var route = RouteTracker.Track(start, end);

            Assert.True(route.Count == 4);
        }
        [Fact]
        public void RouteTracker_ShortTrack_StationStationReversePlusOne_ExpectTrue()
        {
            Railway.RailwayItems.Clear();
            var layer = new RailwayMemoryLayer();
            var charCoord = TrainTrackReader.Read(new string[] { "-1--2-" });
            var parts = RailwayPartsORM.Map(charCoord);
            RailwayAssembler.Assemble(parts);
            var start = parts[^2];
            var end = parts[1];
            var route = RouteTracker.Track(start, end);

            Assert.True(route.Count == 4);
        }
        [Fact]
        public void RouteTracker_ShortTrack_FindStation_ExpectTrue()
        {
            Railway.RailwayItems.Clear();
            var layer = new RailwayMemoryLayer();
            var charCoord = TrainTrackReader.Read(new string[] { "-1---2-" });
            var parts = RailwayPartsORM.Map(charCoord);
            RailwayAssembler.Assemble(parts);
            var start = parts.Find(x => x.Char == '2');
            var end = parts.Find(x => x.Char == '1');
            var route = RouteTracker.Track(start, end);

            Assert.True(route.Count == 5);
        }
        [Fact]
        public void RouteTracker_UTrack_FindStation_ExpectTrue()
        {
            Railway.RailwayItems.Clear();
            var layer = new RailwayMemoryLayer();
            var charCoord = TrainTrackReader.Read(new string[] { "1---", "   -", "2---" });
            var parts = RailwayPartsORM.Map(charCoord);
            RailwayAssembler.Assemble(parts);
            var start = parts.Find(x => x.Char == '1');
            var end = parts.Find(x => x.Char == '2');
            var route = RouteTracker.Track(start, end);

            Assert.True(route.Count == 9);
        }
        [Fact]
        public void RouteTracker_hTrack_FindStation_ExpectTrue()
        {
            Railway.RailwayItems.Clear();
            var layer = new RailwayMemoryLayer();
            var charCoord = TrainTrackReader.Read(new string[] { "1- ", "  - ", "2- " });
            var parts = RailwayPartsORM.Map(charCoord);
            RailwayAssembler.Assemble(parts);
            var start = parts.Find(x => x.Char == '1');
            var end = parts.Find(x => x.Char == '2');
            var route = RouteTracker.Track(start, end);

            Assert.True(route.Count == 5);
        }
        [Fact]
        public void RouteTracker_h2Track_FindStation_ExpectTrue()
        {
            Railway.RailwayItems.Clear();
            var layer = new RailwayMemoryLayer();
            var charCoord = TrainTrackReader.Read(new string[] { "1--", " - ", "2- " });
            var parts = RailwayPartsORM.Map(charCoord);
            RailwayAssembler.Assemble(parts);
            var start = parts.Find(x => x.Char == '1');
            var end = parts.Find(x => x.Char == '2');
            var route = RouteTracker.Track(start, end);
            var count = route.Count;
            Assert.True(count == 5); //not fastest route
        }
        [Fact]
        public void RouteTracker_VTrackReverese_FindStation_ExpectTrue()
        {
            Railway.RailwayItems.Clear();
            var layer = new RailwayMemoryLayer();
            var charCoord = TrainTrackReader.Read(new string[] 
            { 
                "1", 
                " - ", 
                "2" });
            var parts = RailwayPartsORM.Map(charCoord);
            RailwayAssembler.Assemble(parts);
            var start = parts.Find(x => x.Char == '2');
            var end = parts.Find(x => x.Char == '1');
            var route = RouteTracker.Track(start, end);
            var count = route.Count;
            Assert.True(count == 3);
        }
        [Fact]
        public void RouteTracker_V2TrackReverese_FindStation_ExpectTrue()
        {
            Railway.RailwayItems.Clear();
            var layer = new RailwayMemoryLayer();
            var charCoord = TrainTrackReader.Read(new string[]
            {
                "1",
                " \\",
                " /",
                "2" });
            var parts = RailwayPartsORM.Map(charCoord);
            RailwayAssembler.Assemble(parts);
            var start = parts.Find(x => x.Char == '2');
            var end = parts.Find(x => x.Char == '1');
            var route = RouteTracker.Track(start, end);
            var count = route.Count;
            Assert.True(count == 4);
        }
        [Fact]
        public void RouteTracker_hAltTrack_FindStation_ExpectTrue()
        {
            Railway.RailwayItems.Clear();
            var layer = new RailwayMemoryLayer();
            var charCoord = TrainTrackReader.Read(new string[]
            {
                "1-",
                "  \\",
                "  /",
                "2-" });
            var parts = RailwayPartsORM.Map(charCoord);
            RailwayAssembler.Assemble(parts);
            var start = parts.Find(x => x.Char == '2');
            var end = parts.Find(x => x.Char == '1');
            var route = RouteTracker.Track(start, end);
            var count = route.Count;
            Assert.True(count == 6);
        }
        [Fact]
        public void RouteTracker_AltTrack2_1_FindStation_ExpectTrue()
        {
            Railway.RailwayItems.Clear();
            var layer = new RailwayMemoryLayer();
            var charCoord = TrainTrackReader.Read(new string[]
            {
                "1-",
                "  \\",
                "  /",
                "2---" });
            var parts = RailwayPartsORM.Map(charCoord);
            RailwayAssembler.Assemble(parts);
            var start = parts.Find(x => x.Char == '2');
            var end = parts.Find(x => x.Char == '1');
            var route = RouteTracker.Track(start, end);
            var count = route.Count;
            Assert.True(count == 6);
        }
        [Fact]
        public void RouteTracker_AltTrack2_1_TwoDetours_ExpectTrue()
        {
            Railway.RailwayItems.Clear();
            var layer = new RailwayMemoryLayer();
            var charCoord = TrainTrackReader.Read(new string[]
            {
                "1-----",
                "  \\",
                "  /",
                "2----" });
            var parts = RailwayPartsORM.Map(charCoord);
            RailwayAssembler.Assemble(parts);
            var start = parts.Find(x => x.Char == '2');
            var end = parts.Find(x => x.Char == '1');
            var route = RouteTracker.Track(start, end);
            var count = route.Count;
            Assert.True(count == 6); //Not correct path
        }
    }
}
