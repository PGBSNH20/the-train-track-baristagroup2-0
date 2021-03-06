using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstLevelRailway
{
    public class TwentyFourHourClock : IClock
    {
        public string Time { get; set; } = "00:00";
        public int Ticks { get; set; } = 0;
        public int GetDays()
            => Ticks / 1440;
        public static int TimeToTicks(string digitalFormat)
        {
            int singleTicks = int.Parse(digitalFormat[^1].ToString());
            int tenTicks = 10 * int.Parse(digitalFormat[^2].ToString());
            int sixtyTicks = 60 * int.Parse(digitalFormat[^4].ToString());
            int sixhundredTicks = 600 * int.Parse(digitalFormat[^5].ToString());
            return sixhundredTicks + sixtyTicks + tenTicks + singleTicks;
        }

        public static string ConvertTicks(int ticks)
        {
            int thisDayTicks = ticks % 1440;
            int hours = thisDayTicks / 60;
            int min = thisDayTicks % 60;

            string h = hours.ToString();
            if (h.Length == 1)
                h = "0" + h;
            string m = min.ToString();
            if (m.Length == 1)
                m = "0" + m;
            return h + ":" + m;
        }
        public void Tick()
        {
            Ticks++;
            Time = ConvertTicks(Ticks);
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
