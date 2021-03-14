using System.Threading;

namespace TrainConsole
{
    public class TimeKeeper 
    {
        public delegate void Refresh();
        //public Thread thread { get; set; }
        public int Sleep { get; set; }
        public IClock Clock { get; set; }
        public TimeDisplayer Displayer { get; set; }
        public TimeKeeper(IClock clock, TimeDisplayer displayer, int sleep)
        {
            //this.thread = thread;
            Clock = clock;
            Displayer = displayer;
            Sleep = sleep;
        }

        public void StartTime(Refresh refreshMethod)
        {
            //thread.Start();
            while (true)
            {
                Displayer.ClockToMemoryLayer(Clock);
                Program.RefreshScreen();
                Thread.Sleep(Sleep);
                Clock.Tick();
            }
        }
    }
}
