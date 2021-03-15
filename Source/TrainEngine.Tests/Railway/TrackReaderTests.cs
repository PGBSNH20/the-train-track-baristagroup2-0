using Xunit;
using FirstLevelRailway;
using System.Collections.Generic;
using System.IO;

namespace TrainEngine.Tests
{
    public class TrackReaderTests

    {
        [Fact]
        public void TrackReader_ReadFile_ExpectEqual()
        {
            var dataRead = TrackReader.Read(File.ReadAllLines(@"Railway/test-track.txt"));
            var expected = new List<(char chr, int X, int Y)>
            {
                ('[', 0, 0),
                ('1', 1, 0),
                ('-', 2, 0),
                ('<', 3, 0),
                ('>', 4, 0),
                (']', 5, 0),
                ('/', 6, 0),
                ('\\', 7, 0),
                ('=', 9, 0),
            };
            Assert.Equal(expected, dataRead);
        }
        [Fact]
        public void TrackReader_ReadFile_ExpectNoWhiteSpace()
        {
            var dataRead = FirstLevelRailway.TrackReader.Read(new string[] { " " });
            Assert.True(dataRead.Count == 0);
        }
        [Fact]
        public void TrackReader_ReadArray_ExpectEqual()
        {
            var dataRead = FirstLevelRailway.TrackReader.Read(new string[] { "[1]" });
            var expected = new List<(char chr, int X, int Y)>
            {
                ('[', 0, 0),
                ('1', 1, 0),
                (']', 2, 0),
            };
            Assert.Equal(expected, dataRead);
        }
    }
}
