using System;
using System.Collections.Generic;

namespace FirstLevelRailway
{
    public class Train
    {
        private int position { get; set; } = 0;
        public string Name { get; set; }
        //public List<string> Route { get; set; } = new List<string>
        //{
        //    "Avgår från Alingsås",
        //    "Nästa anhalt Partille",
        //    "Stannar i Partille",
        //    "Nästa anhalt Göteborg",
        //    "Stannar i Göteborg"
        //};
        public void Move()
        {
            Console.WriteLine($"{ Name }: {Route[position]}");
            position++;
        }
    }
}