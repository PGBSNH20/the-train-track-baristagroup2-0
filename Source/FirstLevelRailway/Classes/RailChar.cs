using System;

namespace FirstLevelRailway
{
    public class RailChar
    {
        (int X, int Y) Coord { get; set; }
        char Chr { get; set; }
        bool Altered { get; set; } = false;
        public RailChar((int X, int Y) coord, char chr)
        {
            Coord = coord;
            Chr = chr;
        }
        public void Alter()
        {
            
            if (!Altered)
            {
                Console.ForegroundColor = ConsoleColor.White;
                ConsoleWriter.Write(Chr, Coord);
                Altered = !Altered;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                ConsoleWriter.Write(Chr, Coord);
                Console.ForegroundColor = ConsoleColor.White;
                Altered = false;
            }
            
        }
    }
}
