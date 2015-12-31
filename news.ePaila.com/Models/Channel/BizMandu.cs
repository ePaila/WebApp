using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePaila.Models.Channel
{
    public class BizMandu: FeedChannel
    {
        public BizMandu()
        {
            Title = "Bizmandu";
            URL = "http://bizmandu.com/";
            FeedURL = "http://www.bizmandu.com/feed/news";
        }
    }
}
