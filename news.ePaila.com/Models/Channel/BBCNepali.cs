using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ePaila.Models.Channel
{
    public class BBCNepali : FeedChannel
    {
        public BBCNepali()
        {
            Title = "BBC Nepali";
            URL = "http://www.bbcnepali.com";
            FeedURL = "http://www.bbc.com/nepali/index.xml";
        }

        public override List<FeedItem> ReadFeedItems(int count = 20)
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
                XmlNamespaceManager nsmgr = new XmlNamespaceManager(rssXmlDoc.NameTable);
                nsmgr.AddNamespace("bbc", "http://www.w3.org/2005/Atom");
                XmlNodeList rssNodes = rssXmlDoc.SelectNodes("//bbc:entry", nsmgr);

                // Iterate through the items in the RSS file
                foreach (XmlNode rssNode in rssNodes)
                {
                    string title = rssNode["title"].InnerText;
                    string link = "http://www.bbc.com" + rssNode["dc:identifier"].InnerText;
                    string description = rssNode["summary"].InnerText;
                    DateTime pubDate = Utility.eDateTime.ToDateTime(rssNode["updated"].InnerText);

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
