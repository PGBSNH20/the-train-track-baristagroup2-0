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
            var charMover = new CharMover('z', (5, 5));
            var singleSecondsDigit = new SingleSecondsDigit((1, 1), 9);

            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(100);
                charMover.MoveRight();
                singleSecondsDigit.IncrementDigit();
            }

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
    public class SingleSecondsDigit
    {
        
        int currentDigit = 0;
        int lastDigit = 9;
        public SingleSecondsDigit((int x, int y) fixedCoord, int lastDigit)
        {
            FixedCoord = fixedCoord;
            this.lastDigit = lastDigit;
        }
        (int x, int y) FixedCoord;

        private void WriteDigit(int digit)
        {
            Console.SetCursorPosition(FixedCoord.x, FixedCoord.y);
            Console.Write(digit);
        }
        public void IncrementDigit()
        {
            if (currentDigit > lastDigit)
                currentDigit = 0;

            WriteDigit(currentDigit);
            currentDigit++;
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
