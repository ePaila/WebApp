using ePaila.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace ePaila.com.Controllers
{
    public class FeedMeController : BaseController
    {
        public FeedMeController(ePaila.Data.ePailaEntities db) : base(db)
        {

        }
        // GET: eTV
        public ActionResult Index()
        {
            FeedMeViewModel model = new FeedMeViewModel();
            XmlDocument rssXmlDoc = new XmlDocument();
            rssXmlDoc.Load("http://setopati.com/rss/");
            // Parse the Items in the RSS file
            XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");
            // Iterate through the items in the RSS file
            foreach (XmlNode rssNode in rssNodes)
            {
                XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                string title = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("link");
                string link = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("description");
                string description = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("pubDate");

                DateTime? pubDate = DateTime.Now;
                try
                {
                    pubDate = rssSubNode != null ? DateTime.Parse(rssSubNode.InnerText) : DateTime.Now;
                }
                catch
                {
                }



                model.Items.Add(new FeedItem() { HeadLine = title, Description = description, Link = link, PublishedDate = pubDate.Value });
            }

            return View(model);
        }
    }
}