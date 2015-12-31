using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePaila.Models.Channel
{
    public class NagarikNews: FeedChannel
    {
        public NagarikNews()
        {
            Title = "Nagarik News";
            URL = "http://www.nagariknews.com";
            FeedURL = "http://www.nagariknews.com/main-story.feed";
        }
    }
}
