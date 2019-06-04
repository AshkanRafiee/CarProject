using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject
{
    class Time
    {
        int Hour, Minute, Second, Day = 0;

        public Time()
        {
            DateTime theDate;
            theDate = DateTime.Now;
            Hour = theDate.Hour;
            Minute = theDate.Minute;
            Second = theDate.Second;
        }

        public Time(int h, int m, int s)
        {
            Hour = h;
            Minute = m;
            Second = s;
        }
        public static Time operator -(Time t1, Time t2)
        {
            Time t3 = new Time();
            t3.Second = t2.Second - t1.Second;
            t3.Minute = t2.Minute - t1.Minute;
            t3.Hour = t2.Hour - t1.Hour;

            if (t3.Second > 59)
            {
                t3.Minute -= (t3.Second / 60);
                t3.Second = t3.Second % 60;
            }

            if (t3.Minute > 59)
            {
                t3.Hour -= (t3.Minute / 60);
                t3.Minute = t3.Minute % 60;
            }

            if (t3.Hour > 24)
            {
                t3.Day -= (t3.Hour / 24);
                t3.Hour = t3.Hour % 24;
            }

            return(t3);
        }

        public string ShowTime()
        {
            string zaman = "";
            zaman = zaman + Hour.ToString() + ":" + Minute.ToString() + ":" + Second.ToString();
            return zaman;
        }

        public string ShowCurrentTime()
        {
            DateTime theDate;
            theDate = DateTime.Now;
            string zaman = "Current Time: " + theDate.Hour.ToString() + ":" + theDate.Minute.ToString() + ":" + theDate.Second.ToString();
            return zaman;
        }
    }
}

