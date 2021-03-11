using System;
using System.Collections.Generic;
using System.Text;

namespace FirstLevelRailway
{
    public class SingleDigit
    {
        int currentDigit = 0;
        public int lastDigit = 9;
        bool firstIteration = true;
        public SingleDigit((int x, int y) fixedCoord, int lastDigit)
        {
            FixedCoord = fixedCoord;
            this.lastDigit = lastDigit;
            WriteDigit(0);
        }
        (int x, int y) FixedCoord;

        private void WriteDigit(int digit)
        {
            Console.SetCursorPosition(FixedCoord.x, FixedCoord.y);
            Console.Write(digit);
        }
        public int IncrementDigit()
        {
            currentDigit++;
            bool pastLastDigit = currentDigit > lastDigit;

            if (pastLastDigit == true)
                currentDigit = 0;

            WriteDigit(currentDigit);

            return currentDigit;
        }
    }
}
