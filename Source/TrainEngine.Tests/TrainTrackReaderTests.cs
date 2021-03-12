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
    public class TrainTrackReaderTests

    {
        [Fact]
        public void TrainTrackReader_ReadFile_ExpectEqual()
        {
            var dataRead = TrainConsole.TrainTrackReader.Read(File.ReadAllLines(@"testStation.txt"));
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
        public void TrainTrackReader_ReadFile_ExpectNoWhiteSpace()
        {
            var dataRead = TrainConsole.TrainTrackReader.Read(new string[] { " " });
            Assert.True(dataRead.Count == 0);
        }
        [Fact]
        public void TrainTrackReader_ReadArray_ExpectEqual()
        {
            var dataRead = TrainConsole.TrainTrackReader.Read(new string[] { "[1]" });
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
