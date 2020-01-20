using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Master
{
    public class dayType
    {

        int _ISHOLIDAY;
        int _ISWEEKEND;
        int _ISWORKING;
        int _ISOVERTIME;
        string _holidayPriceList;
        string _weekDaysPriceList;
        string _weekEndsPriceList;
        string _overTimePriceList;

        string _totalExclusive;
        string _totalTaxAmount;
        string _totalInclusive;
        public int ISHOLIDAY
        {
            get
            {
                return _ISHOLIDAY;
            }

            set
            {
                _ISHOLIDAY = value;
            }
        }

        public int ISWEEKEND
        {
            get
            {
                return _ISWEEKEND;
            }

            set
            {
                _ISWEEKEND = value;
            }
        }

        public int ISWORKING
        {
            get
            {
                return _ISWORKING;
            }

            set
            {
                _ISWORKING = value;
            }
        }

        public int ISOVERTIME
        {
            get
            {
                return _ISOVERTIME;
            }

            set
            {
                _ISOVERTIME = value;
            }
        }

        public string HolidayPriceList
        {
            get
            {
                return _holidayPriceList;
            }

            set
            {
                _holidayPriceList = value;
            }
        }

        public string WeekDaysPriceList
        {
            get
            {
                return _weekDaysPriceList;
            }

            set
            {
                _weekDaysPriceList = value;
            }
        }

        public string WeekEndsPriceList
        {
            get
            {
                return _weekEndsPriceList;
            }

            set
            {
                _weekEndsPriceList = value;
            }
        }

        public string OverTimePriceList
        {
            get
            {
                return _overTimePriceList;
            }

            set
            {
                _overTimePriceList = value;
            }
        }

        public string TotalExclusive
        {
            get
            {
                return _totalExclusive;
            }

            set
            {
                _totalExclusive = value;
            }
        }

        public string TotalTaxAmount
        {
            get
            {
                return _totalTaxAmount;
            }

            set
            {
                _totalTaxAmount = value;
            }
        }

        public string TotalInclusive
        {
            get
            {
                return _totalInclusive;
            }

            set
            {
                _totalInclusive = value;
            }
        }
    }
}
