using ePaila.Models;
using ePaila.Models.Channel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace news.ePaila.com.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            var model = new SearchViewModel();
            var channel = new GoogleNews();
            model.Items.AddRange(channel.ReadFeedItems());
            ViewBag.Search = "Google News";
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            var model = new SearchViewModel();
            var channel = new GoogleNews(search);
            model.Items.AddRange(channel.ReadFeedItems());
            ViewBag.Search = search;
            return View(model);
        }
    }
}