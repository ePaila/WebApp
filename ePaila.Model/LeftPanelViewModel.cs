using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePaila.ViewModel
{
    public class LeftPanelViewModel
    {
        public string HashTag { get; set; }
        public string RecentComments { get; set; }
        public string RecentPosts { get; set; }
        public TCalendar Calendar { get; set; }
    }
}
