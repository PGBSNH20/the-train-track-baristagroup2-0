using System;

namespace TrainConsole
{
    public class DrawableRailwayPart : IDrawable
    {
        public ConsoleColor Color { get; set; } = ConsoleColor.White;
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public string Chars { get; set; }

        public static IDrawable ConvertItem(IRailwayPart item, ConsoleColor color = ConsoleColor.White)
        {
            return new DrawableRailwayPart()
            {
                CoordinateX = item.CoordinateX,
                CoordinateY = item.CoordinateY,
                Chars = item.Char.ToString(),
                Color = color
            };
        }
    }
}