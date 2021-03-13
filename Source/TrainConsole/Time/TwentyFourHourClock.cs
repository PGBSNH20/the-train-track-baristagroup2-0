using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public class TwentyFourHourClock
    {
        public string Time { get; set; } = "00:00";
        public int Ticks { get; set; } = 0;
        public int GetDays()
            => Ticks / 1440;
        public void Tick()
        {
            Ticks++;
            int thisDayTicks = Ticks % 1440;
            int hours = thisDayTicks / 60;
            int min = thisDayTicks % 60;

            string h = hours.ToString();
            if (h.Length == 1)
                h = "0" + h;
            string m = min.ToString();
            if (m.Length == 1)
                m = "0" + m;
            Time = h + ":" + m;
        }
        public void TickTimes(int times)
        {
            for (int i = 0; i < times; i++)
            {
                Tick();
            }
        }
    }
}
