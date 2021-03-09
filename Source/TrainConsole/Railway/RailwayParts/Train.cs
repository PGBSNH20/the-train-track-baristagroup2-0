using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public class Train : ITrain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxSpeed { get; set; }
        public bool Operated { get; set; }
        public IRailwayPart CurrentPart { get; set; }
        public IRailwayPart NextPart { get; set; }

        public void Move()
        {
            NextPart = CurrentPart;
        }

        //public IRailwayPart NextPosition
        public void Start()
        {
            Console.WriteLine("Starting train");
        }
    }
}

