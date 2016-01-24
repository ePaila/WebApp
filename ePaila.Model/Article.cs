using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePaila.ViewModel
{
    public class Article
    {
        public int ArticleID { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PostedDate { get; set; }
        public bool IsVisible { get; set; }
        public int Favorite { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
