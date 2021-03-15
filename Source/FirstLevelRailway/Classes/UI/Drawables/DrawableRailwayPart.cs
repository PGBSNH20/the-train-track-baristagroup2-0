using System;

namespace TrainConsole
{
    public class DrawableRailwayPart : IDrawable
    {
        public ConsoleColor Color { get; set; } = ConsoleColor.White;
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public string Chars { get; set; }
        public bool IsDrawn { get; set; }
        public bool IsSame(IDrawable drawable)
        {
            if (CoordinateX != drawable.CoordinateX) return false;
            if (CoordinateY != drawable.CoordinateY) return false;
            if (Chars != drawable.Chars) return false;
            if (Color != drawable.Color) return false;
            return true;
        }
        public static IDrawable ConvertPart(IRailwayPart item, ConsoleColor color = ConsoleColor.White)
        {
            return new DrawableRailwayPart()
            {
                CoordinateX = item.CoordinateX,
                CoordinateY = item.CoordinateY,
                Chars = item.Char.ToString(),
                Color = color,
                IsDrawn = false
            };
        }
    }
}