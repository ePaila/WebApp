using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePaila.Models.Channel
{
    public class OnlineKhabar: FeedChannel
    {
        public OnlineKhabar()
        {
            Title = "Onlinekhabar";
            URL = "http://www.onlinekhabar.com/";
            FeedURL = "http://www.onlinekhabar.com/feed/";
        }
    }
}
