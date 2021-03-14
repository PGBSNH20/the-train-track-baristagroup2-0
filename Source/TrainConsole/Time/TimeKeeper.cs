using System.Threading;

namespace TrainConsole
{
    public class TimeKeeper 
    {
        public delegate void Refresh();
        public int Sleep { get; set; }
        public IClock Clock { get; set; }
        public TimeDisplayer Displayer { get; set; }
        public TimeKeeper(IClock clock, TimeDisplayer displayer, int sleep)
        {
            //this.thread = thread;
            Clock = clock;
            Displayer = displayer;
            Sleep = sleep;
            Displayer.ClockToMemoryLayer(Clock);
        }

        public void StartTime(Refresh refreshMethod)
        {
            while (true)
            {
                Thread.Sleep(Sleep);
                Clock.Tick();
                Displayer.ClockToMemoryLayer(Clock);
            }
        }
    }
}
