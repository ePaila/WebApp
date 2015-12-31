using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePaila.ViewModel.Channel
{
    public class SetoPati : FeedChannel
    {
        public SetoPati()
        {
            Title = "Setopati";
            URL = "http://www.setopati.com/";
            FeedURL = "http://setopati.com/rss/";
        }
    }
}
