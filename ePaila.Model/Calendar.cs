using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePaila.ViewModel
{
    public class TCalendar
    {
        public string Title { get; set; }
        public TWeek Week1 { get; set; } = new TWeek();
        public TWeek Week2 { get; set; } = new TWeek();
        public TWeek Week3 { get; set; } = new TWeek();
        public TWeek Week4 { get; set; } = new TWeek();
        public TWeek Week5 { get; set; } = new TWeek();
    }

    public class TWeek
    {
        public TDay Monday { get; set; } = new TDay() { WeekDay = DayOfWeek.Monday };
        public TDay Tuesday { get; set; } = new TDay() { WeekDay = DayOfWeek.Tuesday };
        public TDay Wednesday { get; set; } = new TDay() { WeekDay = DayOfWeek.Wednesday };
        public TDay Thursday { get; set; } = new TDay() { WeekDay = DayOfWeek.Thursday };
        public TDay Friday { get; set; } = new TDay() { WeekDay = DayOfWeek.Friday };
        public TDay Saturday { get; set; } = new TDay() { WeekDay = DayOfWeek.Saturday };
        public TDay Sunday { get; set; } = new TDay() { WeekDay = DayOfWeek.Sunday };
    }

    public class TDay
    {
        public DayOfWeek WeekDay { get; set; }
        public int Day { get; set; }
        public string DayText { get { return this.Day > 0 ? this.Day.ToString() : ""; } }
        public string Href { get; set; } = string.Empty;
        public string Today { get { return this.Day == DateTime.Today.Day ? "today" : ""; } }
    }

    //public enum TWeekDay
    //{
    //    Monday = 1,
    //    Tuesday = 2,
    //    Wednesday = 3,
    //    Thursday = 4,
    //    Friday = 5,
    //    Saturday = 6,
    //    Sunday = 7
    //}
}
