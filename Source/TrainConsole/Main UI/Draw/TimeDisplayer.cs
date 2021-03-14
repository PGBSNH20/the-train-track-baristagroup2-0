
using System;

namespace TrainConsole
{
    public class TimeDisplayer
    {
        public ClockMemoryLayer Layer { get; set; }
        public int CoordFirstX { get; set; }
        public int CoordFirstY { get; set; }
        public ConsoleColor Color { get; set; }
        public TimeDisplayer(int coordFirstX, int coordFirstY, ClockMemoryLayer layer, ConsoleColor color = ConsoleColor.White)
        {
            CoordFirstX = coordFirstX;
            CoordFirstY = coordFirstY;
            Color = color;
            Layer = layer; 
        }
        public void ClockToMemoryLayer(IClock clock)
        {
            Layer.TryAppend(
                new DrawableDigit(
                    CoordFirstX,
                    CoordFirstY,
                    clock.Time[0].ToString()
                    ));
            Layer.TryAppend(
               new DrawableDigit(
                   CoordFirstX + 1,
                   CoordFirstY,
                   clock.Time[1].ToString()
                   ));
            Layer.TryAppend(
              new DrawableDigit(
                  CoordFirstX + 2,
                  CoordFirstY,
                  clock.Time[2].ToString()
                  ));
            Layer.TryAppend(
              new DrawableDigit(
                  CoordFirstX + 3,
                  CoordFirstY,
                  clock.Time[3].ToString()
                  ));
            Layer.TryAppend(
              new DrawableDigit(
                  CoordFirstX + 4,
                  CoordFirstY,
                  clock.Time[4].ToString()
                  ));
        }
    }
}