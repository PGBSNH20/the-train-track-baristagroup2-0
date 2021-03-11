using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FirstLevelRailway
{
    public class DigitalClock
    {
        (int x, int y) LeftPosition;
        int Tick_ns;

        SingleDigit singleMinute;
        SingleDigit tenMinute;
        SingleDigit singleHour;
        SingleDigit tenHour;
        public DigitalClock((int x, int y) leftPosition, int tick_ns)
        {
            LeftPosition = leftPosition;
            Tick_ns = tick_ns;

            singleMinute = new SingleDigit((LeftPosition.x + 4, LeftPosition.y), 9);
            tenMinute = new SingleDigit((LeftPosition.x + 3, LeftPosition.y), 5);
            singleHour = new SingleDigit((LeftPosition.x + 1, LeftPosition.y), 9);
            tenHour = new SingleDigit(LeftPosition, 2);
            ConsoleWriter.Write(':', (LeftPosition.x + 2, LeftPosition.y));
        }
        public string Tick()
        {
            int singleMinuteDigit = 0;
            int tenMinuteDigit = 0;
            int singleHourDigit = 0;
            int tenHourDigit = 0;
            bool past20 = false;

            singleMinuteDigit = singleMinute.IncrementDigit();
            if (singleMinuteDigit == 0)
            {
                tenMinuteDigit = tenMinute.IncrementDigit();
                if (tenMinuteDigit == 0)
                {
                    singleHourDigit = singleHour.IncrementDigit();
                    if (singleHourDigit == 0)
                    {
                        tenHourDigit = tenHour.IncrementDigit();
                        if (tenHourDigit == 2)
                            singleHour.lastDigit = 3;
                        else
                            singleHour.lastDigit = 9;

                        past20 = !past20;
                    }
                }
            }
            return $"{tenHourDigit}{singleHourDigit}:{tenMinuteDigit}{singleMinuteDigit}";
        }
        public void StartClock(int maxTicks)
        {
            int tick = 0;
            
            while (tick < maxTicks)
            {
                Thread.Sleep(Tick_ns);
                Tick();
                tick++;
            }
        }
        
    }
}
