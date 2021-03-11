using System;
using System.IO;

namespace TrainConsole
{
    public class CharMover
    {
        char Chr;
        (int X, int Y) LastCoord;
        public CharMover(char chr, (int X, int Y) startCoord)
        {
            Chr = chr;
            LastCoord = startCoord;
            Write(startCoord);
        }
        public void MoveRight()
        {
            Write((LastCoord.X++, LastCoord.Y));
        }
        private void Write((int X, int Y) coord)
        {
            Console.SetCursorPosition(coord.X, coord.Y);
            Console.Write(Chr);
        }
    }
}
