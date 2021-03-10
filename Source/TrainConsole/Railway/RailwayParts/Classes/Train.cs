using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public class Train : ITrain, IRailwayItem
    {
        public int Id { get; set; }
        public char Char { get; set; }
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public string Name { get; set; }
        public List<IRailwayPart> Route { get; set; }
        public List<CheckPoint> Stops { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void MoveForward()
        {
            throw new NotImplementedException();
        }

        //public IRailwayPart NextPosition
        public void Start()
        {
            Console.WriteLine("Starting train");
        }
    }
}

