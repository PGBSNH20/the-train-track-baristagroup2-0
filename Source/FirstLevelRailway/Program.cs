using System.Threading;
using System.Transactions;

namespace FirstLevelRailway
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread trainOne = new Thread(new ThreadStart(() => TrainThread("Red dragon")));
           // Thread trainTwo = new Thread(new ThreadStart(TrainThread));
            trainOne.Start();
            //trainTwo.Start();
        }
        static void TrainThread(string name)
        {

            Train train1 = new Train()
            { Name = name };
            foreach (var m in train1.Route)
            {
                train1.Move();
                Thread.Sleep(400);
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
