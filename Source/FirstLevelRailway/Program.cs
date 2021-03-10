using System;
using System.Collections.Generic;

namespace FirstLevelRailway
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    public class Train
    {
        private int position { get; set; } = 0;
        public List<string> Route { get; set; } = new List<string>
        {
            "Avgår från Alingsås",
            "Nästa anhalt Göteborg",
            "Stannar i Göteborg"
        };
        public void Move()
        {
            Console.WriteLine(Route[position]);
            position++;
        }
    }
    /*
     * Tåg
     * Startpunkt
     * Slutpunkt
     * 
     * object
     *      tåg
     *      station
     *      räls/spår
     *      Rutt
     *      
     *      station
     *      räls
     *      station
     *      
     *      Avgår från Alingsås
     *      Nästa anhalt Göteborg
     *      Stannar i Göteborg
     */




}
