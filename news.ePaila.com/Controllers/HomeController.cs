using ePaila.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ePaila.Data.Repo;

namespace news.ePaila.com.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            FeedMeViewModel model = new FeedMeViewModel();
            //add channel
            FeedChannel channel_01 = new FeedChannel()
            {
                Title = "Setopati",
                URL = "http://setopati.com/",
                FeedURL = "http://setopati.com/rss/"
            };

            model.Channels.Add(channel_01);

            //load rss items
            NewsFeedRadarRepository feedRepo = new NewsFeedRadarRepository();
            model.Items = feedRepo.GetFeedItems(channel_01);
            return View(model);
        }
    }
}