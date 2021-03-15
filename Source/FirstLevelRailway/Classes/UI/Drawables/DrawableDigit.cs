
using System;

namespace FirstLevelRailway
{
    public class DrawableDigit : IDrawable
    {
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public string Chars { get; set; }
        public ConsoleColor Color { get; set; }
        public bool IsDrawn { get; set; }
        public DrawableDigit(int coordX, int coordY, string chars, ConsoleColor color = ConsoleColor.White)
        {
            CoordinateX = coordX;
            CoordinateY = coordY;
            Chars = chars;
            Color = color;
            IsDrawn = false;
        }
        public bool IsSame(IDrawable drawable)
        {
            if (CoordinateX != drawable.CoordinateX) return false;
            if (CoordinateY != drawable.CoordinateY) return false;
            if (Chars != drawable.Chars) return false;
            if (Color != drawable.Color) return false;
            return true;
        }
    }
}