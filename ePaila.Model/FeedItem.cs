using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePaila.ViewModel
{
    public class FeedItem : FeedChannel
    {
        public string HeadLine { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
