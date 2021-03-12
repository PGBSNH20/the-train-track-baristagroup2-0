using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public class TwentyFourHourClock
    {
        public string[] Time { get; set; } = new string[] { "0", "0", ":", "0", "0" };
        public int Ticks { get; set; } = 0;
        public string[] TickOnce()
        {
            TickTimes(1);
            return this.Time;
        }
        public void TickTimes(int times)
        {
            string min = "0";
            int tenMin = 0;
            int oneHour = 0;
            int tenHour = 0;
            var time = Time;

            for (int i = 0; i < times; i++)
            {
                Ticks++;
                min = Ticks.ToString()[^1].ToString();
                time[4] = min;

                if (Ticks % 10 == 0)
                {
                    tenMin++;
                    time[3] = tenMin.ToString();
                }
                if (Ticks % 60 == 0)
                {
                    tenMin = 0;
                    time[3] = tenMin.ToString();
                }

                if (Ticks % 60 == 0)
                {
                    oneHour++;
                    time[1] = oneHour.ToString();
                }
                if (Ticks % 600 == 0)
                {
                    oneHour = 0;
                    time[1] = oneHour.ToString();
                }
                if (Ticks % 600 == 0)
                {
                    tenHour++;
                    time[0] = tenHour.ToString();
                }
                if(Ticks % 1440 == 0)
                {
                    tenHour = 0;
                    time[0] = tenHour.ToString();

                    oneHour = 0;
                    time[1] = oneHour.ToString();
                }
            }
        }
    }
}
