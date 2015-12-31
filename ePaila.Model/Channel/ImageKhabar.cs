using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePaila.ViewModel.Channel
{
    public class ImageKhabar: FeedChannel
    {
        public ImageKhabar()
        {
            Title = "Imagekhabar";
            URL = "http://imagekhabar.com/";
            FeedURL = "http://www.imagekhabar.com/feed/";
        }
    }
}
