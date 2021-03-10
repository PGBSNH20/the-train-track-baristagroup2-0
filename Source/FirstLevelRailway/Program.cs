using System;
using System.Collections.Generic;
using System.Threading;

namespace FirstLevelRailway
{
    class Program
    {
        static void Main(string[] args)
        {
            Train train1 = new Train();
            foreach (var m in train1.Route)
            {
            train1.Move();
            Thread.Sleep(400);
            }
            Thread trainOne = new Thread(new ThreadStart(train1Work());
            

        }
        static void train1Work(List<String> Route)
        {

            for (int i = 0; i < Route.Count; i++)
            {
                Console.WriteLine(Route[i]);
                Thread.Sleep(400);
            }
        }
    }
    public class Train
    {
        private int position { get; set; } = 0;

        public List<string> Route { get; set; } = new List<string>
        {
            "Avgår från Alingsås",
            "Nästa anhalt Partille",
            "Stannar i Partille",
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
