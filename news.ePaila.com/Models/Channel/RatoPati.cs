using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ePaila.Models.Channel
{
    public class RatoPati : FeedChannel
    {
        public RatoPati()
        {
            Title = "Ratopati";
            URL = "http://ratopati.com/";
            FeedURL = "http://www.ratopati.com/newsfeed/";
        }

        public override List<FeedItem> ReadFeedItems(int count = 20)             
        {
            List<FeedItem> items = new List<FeedItem>();
            XmlDocument rssXmlDoc = new XmlDocument();
            try
            {
                try
                {
                    WebClient wc = new WebClient();
                    Stream st = wc.OpenRead(this.FeedURL);
                    string rss = "";
                    using (StreamReader sr = new StreamReader(st))
                    {
                        rss = sr.ReadToEnd();
                    }
                    int index = rss.IndexOf('<');
                    rss = rss.Remove(0, index);
                    rssXmlDoc.LoadXml(rss);
                }
                catch (Exception ex1)
                {

                }
                // Parse the Items in the RSS file

                XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");

                // Iterate through the items in the RSS file
                foreach (XmlNode rssNode in rssNodes)
                {
                    string title = ReadNodeElement(rssNode, "title");
                    string link = ReadNodeElement(rssNode, "link");
                    string description = ReadNodeElement(rssNode, "description");
                    DateTime pubDate = Utility.eDateTime.ToDateTime(ReadNodeElement(rssNode, "pubDate"));

                    items.Add(new FeedItem() { Title = this.Title, URL = this.URL, HeadLine = title, Description = description, Link = link, PublishedDate = pubDate });
                }

            }
            catch (Exception ex)
            {

            }
            return items.Take(count).ToList();
        }
    }
}
