using System;
using System.Collections.Generic;
using System.Threading;
using System.Transactions;

namespace FirstLevelRailway
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            var clock = new DigitalClock(leftPosition: (5, 5), tick_ns: 1);
            clock.StartClock(maxTicks: 200000);

            Console.ReadLine();
            //var trainData = TrainCallLoader.Load();
            //var trains = Train.GenerateFrom(trainData);
            //var trainThreads = new List<Thread>();
            //foreach (var train in trains)
            //{
            //    trainThreads.Add( new Thread(new ThreadStart(() => TrainThread(train))));
            //}
            //foreach (var thread in trainThreads)
            //{
            //    thread.Start();
            //}
        }
        static void TrainThread(Train train)
        {
            foreach (var m in train.Route)
            {
                train.Move();
                Thread.Sleep(500);
            }
        }
    }
    public static class ConsoleWriter
    {
        public static void Write(char chr, (int X, int Y) coord)
        {
            Console.SetCursorPosition(coord.X, coord.Y);
            Console.Write(chr);
        }
    }
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
        public void StartClock(int maxTicks)
        {
            int tick = 0;
            bool past20 = true;

            while (tick < maxTicks)
            {
                Thread.Sleep(Tick_ns);

                if (singleMinute.IncrementDigit() == 1)
                    if (tenMinute.IncrementDigit() == 1)
                        if (singleHour.IncrementDigit() == 1)
                        {
                            tenHour.IncrementDigit();

                                if (past20)
                                {
                                    singleHour.lastDigit = 3;
                                }
                                else
                                {
                                    singleHour.lastDigit = 9;
                                }
                                past20 = !past20;
                        }
                tick++;
            }
        }
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

                return currentDigit;
            }
        }
    }

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
