using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePaila.Models.Channel
{
    public class PahiloPost: FeedChannel
    {
        public PahiloPost()
        {
            Title = "Pahilopost";
            URL = "http://pahilopost.com/";
            FeedURL = "http://www.pahilopost.com/rss/";
        }
    }
}
