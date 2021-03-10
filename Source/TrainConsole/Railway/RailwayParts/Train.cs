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
        public string Name { get; set; }
        public int MaxSpeed { get; set; }
        public bool Operated { get; set; }
        public IRailwayPart CurrentLocation { get; set; }
        public List<IRailwayPart> Route { get; set; }
        public List<Stop> Stops { get; set; }
        public bool IsBetweenStops { get; set; }

        public void MoveForward()
        {
            if(IsBetweenStops == true)
            {
                var ilastDeparted = Stops.FindLastIndex(x => x.HasDeparted == true);
                var iLastArrived = Stops.FindLastIndex(x => x.HasArrived == true);
                var lastIndex = ilastDeparted > iLastArrived ? ilastDeparted : iLastArrived;

            }

        }

        //public IRailwayPart NextPosition
        public void Start()
        {
            Console.WriteLine("Starting train");
        }
    }
}

