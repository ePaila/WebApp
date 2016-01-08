using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePaila.Models
{
    public abstract class ViewModel
    {
        private List<FeedItem> _items = new List<FeedItem>();
        public List<FeedItem> Items { get { SortFeedItemByPostedDate(); return _items; } set { value = _items; } }

        private void SortFeedItemByPostedDate()
        {
            _items.OrderByDescending(x => x.PublishedDate).ToList();
        }
    }
}
