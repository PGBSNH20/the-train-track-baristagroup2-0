using System.Threading;
using System.Transactions;

namespace FirstLevelRailway
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Train redDragon = new Train();
            Train blackDragon = new Train();

            Thread redDragonThread = new Thread(new ThreadStart(() => TrainThread("Red dragon")));
            Thread blackDragonThread = new Thread(new ThreadStart(() => TrainThread("Black dragon")));
            
            
            redDragonThread.Start();
            blackDragonThread.Start();
            //trainTwo.Start();
        }
        static void TrainThread(string name)
        {

            Train train1 = new Train()
            { Name = name };
            foreach (var m in train1.Route)
            {
                train1.Move();
                Thread.Sleep(500);
            }
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
