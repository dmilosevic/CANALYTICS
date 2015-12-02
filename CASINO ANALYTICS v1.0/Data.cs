using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CASINO_ANALYTICS_v1._0
{
    class Data
    {
        public string user;
        public string tableName;
        public int year;
        public int month;
        public int day;
        public int fromH;
        public int toH;
        public double drop;
        public double result;
        public int headcount;

        public Data(string user, string tablename, int year, int month, int day, int fromH, int toH, double drop, double result, int headcount)
        {
            this.user = user;
            this.tableName = tablename;
            this.year = year;
            this.month = month;
            this.day = day;
            this.fromH = fromH;
            this.toH = toH;
            this.drop = drop;
            this.result = result;
            this.headcount = headcount;
        }

    }
}
