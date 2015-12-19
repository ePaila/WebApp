using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePaila.ViewModel
{
    public class ArticleViewModel : LeftPanelViewModel
    {
        public List<Article> Articles { get; set; } = new List<Article>();
    }
}
