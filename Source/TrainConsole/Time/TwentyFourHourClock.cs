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
            int oneMin = 0;
            int tenMin = 0;
            int oneHour = 0;
            int tenHour = 0;
            var time = Time;
            var tick24 = 0;

            for (int i = 0; i < times; i++)
            {
                Ticks++;
                tick24++;
                oneMin++;
                time[4] = oneMin.ToString()[^1].ToString();

                if (tick24 % 10 == 0)
                {
                    tenMin++;
                    time[3] = tenMin.ToString();
                }
                if (tick24 % 10 == 0)
                {
                    oneMin = 0;
                    time[4] = oneMin.ToString();
                }
                if (tick24 % 60 == 0)
                {
                    tenMin = 0;
                    time[3] = tenMin.ToString();
                }

                if (tick24 % 60 == 0)
                {
                    oneHour++;
                    time[1] = oneHour.ToString();
                }
                if (tick24 % 600 == 0)
                {
                    oneHour = 0;
                    time[1] = oneHour.ToString();
                }
                if (tick24 % 600 == 0)
                {
                    tenHour++;
                    time[0] = tenHour.ToString();
                }
                if(tick24 % 1440 == 0)
                {
                    tenHour = 0;
                    time[0] = tenHour.ToString();

                    oneHour = 0;
                    time[1] = oneHour.ToString();

                    tick24 = 0;
                }
            }
        }
    }
}
