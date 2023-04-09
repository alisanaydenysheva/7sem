using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF2022User02Lib
{
    public class MyTime
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }

        public MyTime(int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
        }

        public static MyTime operator +(MyTime t1, MyTime t2)
        {
            int totalMinutes = (t1.Hours * 60 + t1.Minutes) + (t2.Hours * 60 + t2.Minutes);
            int hours = totalMinutes / 60;
            int minutes = totalMinutes % 60;
            return new MyTime(hours, minutes);
        }
    }
}
