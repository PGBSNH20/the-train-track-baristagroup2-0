using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainConsole
{
    public class TestDrivenClock
    {
        public string[] Time { get; set; } = new string[] {"0","0" };
        public int Ticks { get; set; } = 0;
        public void Tick(int times)
        {
            string ten = "";
            string one = "";
            for (int i = 0; i < times; i++)
            {
                Ticks++;
                Time = ten + (i+1).ToString();
                var test = Ticks.ToString();
                if(test.Length ==2)
                    Time = 1 + (i + 1).ToString();
            }
        }
    }
}
