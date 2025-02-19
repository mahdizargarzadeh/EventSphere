using System;
using System.Globalization;

namespace Mqeb.Application.Convertors
{
    public static class DateConvertor
    {
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00")
                   + "/" + pc.GetDayOfMonth(value).ToString("00");
        }

        public static string ToShamsiForNow()
        {
            PersianCalendar pc = new PersianCalendar();
            //return pc.GetYear(value) + "/" + pc.GetMonth(value).ToString("00")
            //+ "/" + pc.GetDayOfMonth(value).ToString("00");

            string day = "";
            switch (pc.GetDayOfWeek(DateTime.Now))
            {
                case DayOfWeek.Saturday:
                    {
                        day = "شنبه";
                        break;
                    }
                case DayOfWeek.Sunday:
                    {
                        day = "یکشنبه";
                        break;
                    }
                case DayOfWeek.Monday:
                    {
                        day = "دوشنبه";
                        break;
                    }
                case DayOfWeek.Tuesday:
                    {
                        day = "سه شنبه";
                        break;
                    }
                case DayOfWeek.Wednesday:
                    {
                        day = "چهار شنبه";
                        break;
                    }
                case DayOfWeek.Thursday:
                    {
                        day = "پنجشنبه";
                        break;
                    }
                case DayOfWeek.Friday:
                    {
                        day = "جمعه";
                        break;
                    }
            }

            string month = "";
            switch (pc.GetMonth(DateTime.Now))
            {
                case 1:
                {
                    month = "فروردین";
                    break;
                }
                case 2:
                {
                    month = "اردیبهشت";
                    break;
                }
                case 3:
                {
                    month = "خرداد";
                    break;
                }
                case 4:
                {
                    month = "تیر";
                    break;
                }
                case 5:
                {
                    month = "مرداد";
                    break;
                }
                case 6:
                {
                    month = "شهریور";
                    break;
                }
                case 7:
                {
                    month = "مهر";
                    break;
                }
                case 8:
                {
                    month = "آبان";
                    break;
                }
                case 9:
                {
                    month = "آذر";
                    break;
                }
                case 10:
                {
                    month = "دی";
                    break;
                }
                case 11:
                {
                    month = "بهمن";
                    break;
                }
                case 12:
                {
                    month = "اسفند";
                    break;
                }
            }

            return $"{day} , {pc.GetDayOfMonth(DateTime.Now)} {month} {pc.GetYear(DateTime.Now)}";
        }
    }
}