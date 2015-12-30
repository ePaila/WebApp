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
                URL = "http://www.setopati.com/",
                FeedURL = "http://setopati.com/rss/"
            };

            FeedChannel channel_02 = new FeedChannel()
            {
                Title = "Onlinekhabar",
                URL = "http://www.onlinekhabar.com/",
                FeedURL = "http://www.onlinekhabar.com/feed/"
            };
            FeedChannel channel_03 = new FeedChannel()
            {
                Title = "Ratopati",
                URL = "http://ratopati.com/",
                FeedURL = "http://www.ratopati.com/feed/"
            };

            FeedChannel channel_04 = new FeedChannel()
            {
                Title = "Pahilopost",
                URL = "http://pahilopost.com/",
                FeedURL = "http://www.pahilopost.com/rss/"
            };
            
            model.Channels.Add(channel_01);
            model.Channels.Add(channel_02);
            model.Channels.Add(channel_03);
            model.Channels.Add(channel_04);

            //load rss items
            NewsFeedRadarRepository feedRepo = new NewsFeedRadarRepository();
            foreach (var item in model.Channels)
            {
                model.Items.AddRange(feedRepo.GetFeedItems(item));
            }
            return View(model);
        }
    }
}