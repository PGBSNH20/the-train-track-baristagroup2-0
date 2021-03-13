
using System;

namespace TrainConsole
{
    public interface IDrawable
    {
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public string Chars { get; set; }
        public ConsoleColor Color { get; set; }
    }
}
