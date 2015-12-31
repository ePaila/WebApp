using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePaila.ViewModel.Channel
{
    public class HimalKhabar : FeedChannel
    {
        public HimalKhabar()
        {
            Title = "Himalkhabar";
            URL = "http://himalkhabar.com/";
            FeedURL = "http://www.himalkhabar.com/feed";
        }
    }
}
