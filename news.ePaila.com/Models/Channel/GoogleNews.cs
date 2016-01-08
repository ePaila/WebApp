using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePaila.Models.Channel
{
    public class GoogleNews : FeedChannel
    {
        private string _searchTerm;
        public GoogleNews()
        {
            Title = "Google News";
            URL = "http://www.news.google.com";
            FeedURL = "https://news.google.com/news/section?cf=all&hl=en&pz=1&ned=us&output=rss&zx=9sc8igswsiqi&as_maxd=27&q=";
        }

        public GoogleNews(string searchTerm)
        {
            _searchTerm = searchTerm;
            Title = "Google News";
            URL = "http://www.news.google.com";
            FeedURL = "https://news.google.com/news/section?cf=all&hl=en&pz=1&ned=us&output=rss&zx=9sc8igswsiqi&as_maxd=27&q=" + _searchTerm;
        }
    }
}
