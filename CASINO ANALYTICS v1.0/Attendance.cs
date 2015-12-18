using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CASINO_ANALYTICS_v1._0
{
    class Attendance
    {
        public int Year;
        public int Month;
        public int Day;
        public int Attendace;

        public Attendance(int year, int month, int day, int att)
        {
            this.Year = year;
            this.Month = month;
            this.Day = day;
            this.Attendace = att;
        }
    }
}
