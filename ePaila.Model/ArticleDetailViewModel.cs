using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePaila.ViewModel
{
    public class ArticleDetailViewModel: LeftPanelViewModel
    {
        public Article Article { get; set; } = new Article();
    }
}
