using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ePaila.ViewModel;
using System.Reflection;
using ePaila.Data.Repo;

namespace WebApp.Controllers
{
    public class BaseController : Controller
    {
        public LeftPanelRepository _leftPanelRepo { get; set; }
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            var model = filterContext.Controller.ViewData.Model as LeftPanelViewModel;
            List<int> articlesDays = getArticlesDaysOfMonth(DateTime.Now);
            model.Calendar = loadCalendar(articlesDays);
        }

        public BaseController()
        {

        }

        public BaseController(ePaila.Data.ePailaEntities db)
        {
            _leftPanelRepo = new LeftPanelRepository(db);
        }
        
        //load calendar
        TCalendar loadCalendar(List<int> articlesDays)
        {
            TCalendar calendar = new TCalendar();
            calendar.Title = DateTime.Now.ToString("MMMM yyyy");

            DateTime firstDayOfMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            int weekNo = 1;
            for (DateTime i = firstDayOfMonth; i <= lastDayOfMonth;)
            {
                TDay _day = new TDay()
                {
                    Day = i.Day,
                    Href = articlesDays.Contains(i.Day) ? "/Home/Index?day=" + i.Day.ToString() : ""
                };

                if (weekNo == 1)
                {
                    var prop = calendar.Week1.GetType().GetProperty(i.DayOfWeek.ToString());

                    prop.SetValue(calendar.Week1, _day, null);
                }
                else if (weekNo == 2)
                {
                    var prop = calendar.Week2.GetType().GetProperty(i.DayOfWeek.ToString());
                    prop.SetValue(calendar.Week2, _day, null);
                }

                else if (weekNo == 3)
                {
                    var prop = calendar.Week3.GetType().GetProperty(i.DayOfWeek.ToString());
                    prop.SetValue(calendar.Week3, _day, null);
                }

                else if (weekNo == 4)
                {
                    var prop = calendar.Week4.GetType().GetProperty(i.DayOfWeek.ToString());
                    prop.SetValue(calendar.Week4, _day, null);
                }

                else
                {
                    var prop = calendar.Week5.GetType().GetProperty(i.DayOfWeek.ToString());
                    prop.SetValue(calendar.Week5, _day, null);
                }

                //increase week number
                if (i.DayOfWeek == DayOfWeek.Saturday)
                    weekNo++;

                i = i.AddDays(1);
            }
            return calendar;
        }

        //get days on which article has been published
        List<int> getArticlesDaysOfMonth(DateTime date)
        {
            List<int> days = _leftPanelRepo.ArticleDays(DateTime.Today);
            days.Add(DateTime.Today.Day);
            return days;
        }
    }
}