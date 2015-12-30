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
            #region Add Channel
            FeedChannel channel;
            channel = new FeedChannel()
            {
                Title = "Setopati",
                URL = "http://www.setopati.com/",
                FeedURL = "http://setopati.com/rss/"
            };
            model.Channels.Add(channel);

            channel = new FeedChannel()
            {
                Title = "Onlinekhabar",
                URL = "http://www.onlinekhabar.com/",
                FeedURL = "http://www.onlinekhabar.com/feed/"
            };
            model.Channels.Add(channel);

            channel = new FeedChannel()
            {
                Title = "Ratopati",
                URL = "http://ratopati.com/",
                FeedURL = "http://www.ratopati.com/newsfeed/"
            };
            model.Channels.Add(channel);

            channel = new FeedChannel()
            {
                Title = "Pahilopost",
                URL = "http://pahilopost.com/",
                FeedURL = "http://www.pahilopost.com/rss/"
            };
            model.Channels.Add(channel);

            channel = new FeedChannel()
            {
                Title = "Bizmandu",
                URL = "http://bizmandu.com/",
                FeedURL = "http://www.bizmandu.com/feed/news"
            };
            model.Channels.Add(channel);

            channel = new FeedChannel()
            {
                Title = "Imagekhabar",
                URL = "http://imagekhabar.com/",
                FeedURL = "http://www.imagekhabar.com/feed/"
            };
            model.Channels.Add(channel);

            channel = new FeedChannel()
            {
                Title = "Himalkhabar",
                URL = "http://himalkhabar.com/",
                FeedURL = "http://www.himalkhabar.com/feed"
            };
            model.Channels.Add(channel);

            channel = new FeedChannel()
            {
                Title = "Ujyaaloonline",
                URL = "http://ujyaaloonline.com/",
                FeedURL = "http://ujyaaloonline.com/rss"
            };
            model.Channels.Add(channel);    
            #endregion
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