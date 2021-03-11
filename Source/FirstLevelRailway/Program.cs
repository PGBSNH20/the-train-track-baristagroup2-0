﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Transactions;

namespace FirstLevelRailway
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var charMover = new CharMover('z', (5, 5));

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                charMover.MoveRight();
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
    public class Clock
    {

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
