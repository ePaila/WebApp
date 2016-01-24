using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ePaila.Models
{
    public abstract class FeedChannel
    {
        public string Title { get; set; }
        public string URL { get; set; }
        public string FeedURL { get; set; }

        protected string ReadNodeElement(XmlNode rssNode, string element)
        {
            XmlNode rssSubNode = rssNode.SelectSingleNode(element);
            return rssSubNode != null ? rssSubNode.InnerText : "";
        }

        public virtual List<FeedItem> ReadFeedItems(int count = 20)
        {
            List<FeedItem> items = new List<FeedItem>();
            XmlDocument rssXmlDoc = new XmlDocument();
            try
            {
                try
                {
                    rssXmlDoc.Load(this.FeedURL);
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
