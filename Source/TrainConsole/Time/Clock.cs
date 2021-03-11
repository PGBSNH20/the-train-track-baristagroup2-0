using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TrainConsole
{
    public class Clock
    {
        (int x, int y) LeftPosition;
        int Tick_ns;

        public string Time {
            get => Time;
            set => Time = value;
        }

        SingleDigit singleMinute;
        SingleDigit tenMinute;
        SingleDigit singleHour;
        SingleDigit tenHour;
        public Clock((int x, int y) leftPosition, int tick_ns)
        {
            LeftPosition = leftPosition;
            Tick_ns = tick_ns;

            singleMinute = new SingleDigit((LeftPosition.x + 4, LeftPosition.y), 9);
            tenMinute = new SingleDigit((LeftPosition.x + 3, LeftPosition.y), 5);
            singleHour = new SingleDigit((LeftPosition.x + 1, LeftPosition.y), 9);
            tenHour = new SingleDigit(LeftPosition, 2);
            ConsoleWriter.Write(':', (LeftPosition.x + 2, LeftPosition.y));
        }
        public void StartClock(int maxTicks)
        {
            int tick = 0;
            bool past20 = false;
            string time;

            while (tick < maxTicks)
            {
                Thread.Sleep(Tick_ns);

                if (singleMinute.IncrementDigit() == 0)
                    if (tenMinute.IncrementDigit() == 0)
                        if (singleHour.IncrementDigit() == 0)
                        {
                            if (2 == tenHour.IncrementDigit())
                                singleHour.lastDigit = 2;
                            else
                                singleHour.lastDigit = 9;

                            past20 = !past20;
                        }
                time = $"{tenHour.currentDigit}{singleHour.currentDigit}:{tenMinute.currentDigit}{singleMinute.currentDigit}";
                tick++;
                Time = time;
            }
        }
        public class SingleDigit
        {
            public int currentDigit = 0;
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
                bool pastLastDigit = currentDigit > lastDigit;

                if (firstIteration == true)
                {
                    currentDigit = 1;
                    firstIteration = false;
                }

                if (pastLastDigit == true)
                    currentDigit = 0;

                WriteDigit(currentDigit);
                currentDigit++;

                return currentDigit - 1;
            }
        }
    }
}
