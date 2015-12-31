using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ePaila.Models.Channel;
using ePaila.Models;

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

            channel = new SetoPati();
            model.Channels.Add(channel);

            channel = new OnlineKhabar();
            model.Channels.Add(channel);

            channel = new RatoPati();
            model.Channels.Add(channel);

            channel = new PahiloPost();
            model.Channels.Add(channel);

            channel = new BizMandu();
            model.Channels.Add(channel);

            channel = new ImageKhabar();
            model.Channels.Add(channel);

            channel = new HimalKhabar();
            model.Channels.Add(channel);

            channel = new UjyaloOnline();
            model.Channels.Add(channel);

            channel = new BBCNepali();
            model.Channels.Add(channel);

            channel = new NagarikNews();
            model.Channels.Add(channel);
            #endregion
            //load rss items
            
            foreach (var item in model.Channels)
            {
                model.Items.AddRange(item.ReadFeedItems());
            }
            return View(model);
        }
    }
}