using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePaila.Models.Channel
{
    public class UjyaloOnline :FeedChannel
    {
        public UjyaloOnline()
        {
            Title = "Ujyaaloonline";
            URL = "http://ujyaaloonline.com/";
            FeedURL = "http://ujyaaloonline.com/rss";
        }
    }
}
