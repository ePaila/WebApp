using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePaila.Models
{
    public class FeedMeViewModel : ViewModel
    {
        public List<FeedChannel> Channels { get; set; } = new List<FeedChannel>(); 
    }
}
