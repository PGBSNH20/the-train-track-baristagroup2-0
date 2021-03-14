
using System;

namespace TrainConsole
{
    public class TimeDisplayer
    {
        public int CoordFirstX { get; set; }
        public int CoordFirstY { get; set; }
        public ConsoleColor Color { get; set; }
        public TimeDisplayer(int coordFirstX, int coordFirstY, ConsoleColor color = ConsoleColor.White)
        {
            CoordFirstX = coordFirstX;
            CoordFirstY = coordFirstY;
            Color = color;
        }
        public void ClockToMemoryLayer(IClock clock)
        {
            RailwayMemoryLayer.TryAppend(
                new DrawableDigit(
                    CoordFirstX,
                    CoordFirstY,
                    clock.Time[0].ToString()
                    ));
            RailwayMemoryLayer.TryAppend(
               new DrawableDigit(
                   CoordFirstX + 1,
                   CoordFirstY,
                   clock.Time[1].ToString()
                   ));
            RailwayMemoryLayer.TryAppend(
              new DrawableDigit(
                  CoordFirstX + 2,
                  CoordFirstY,
                  clock.Time[2].ToString()
                  ));
            RailwayMemoryLayer.TryAppend(
              new DrawableDigit(
                  CoordFirstX + 3,
                  CoordFirstY,
                  clock.Time[3].ToString()
                  ));
            RailwayMemoryLayer.TryAppend(
              new DrawableDigit(
                  CoordFirstX + 4,
                  CoordFirstY,
                  clock.Time[4].ToString()
                  ));
        }
    }
}