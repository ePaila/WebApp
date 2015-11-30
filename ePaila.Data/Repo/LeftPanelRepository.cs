﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePaila.Data.Repo
{
    public class LeftPanelRepository
    {
        ePailaEntities _db;

        public LeftPanelRepository(ePailaEntities db)
        {
            _db = db;
        }

        public List<ViewModel.Article> Archives()
        {
            return new List<ViewModel.Article>();
        }

        public string AboutMe()
        {
            return "";
        }

        public string ContactMe()
        {
            return "";
        }

        public string Search(string text)
        {
            return "";
        }

        public string HashTags()
        {
            return "";
        }

        public string RecentPosts()
        {
            return "";
        }

        public string RecentComments()
        {
            return "";
        }

        public List<int> ArticleDays(DateTime currentMonth)
        {
            DateTime dt = new DateTime(DateTime.Now.Year, currentMonth.Month, 1);
            List<DateTime> postedDays = new List<DateTime>();
            postedDays = _db.Articles.Where(x => x.PostedDate >= dt).Select(y => y.PostedDate.Value).ToList();
            
            List<int> days = new List<int>();
            if(postedDays.Count>0)
                days= postedDays.Select(n => n.Day).ToList();
            return days;
        }
    }
}