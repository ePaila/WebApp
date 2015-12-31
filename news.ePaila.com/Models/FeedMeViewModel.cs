using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePaila.Models
{
    public class FeedMeViewModel
    {
        private List<FeedItem> _items = new List<FeedItem>();
        public List<FeedChannel> Channels { get; set; } = new List<FeedChannel>();
        public List<FeedItem> Items { get { SortFeedItemByPostedDate(); return _items; } set { value = _items; } }

        private void SortFeedItemByPostedDate()
        {
            _items = _items.OrderByDescending(x => x.PublishedDate).ToList();
        }
    }
}
