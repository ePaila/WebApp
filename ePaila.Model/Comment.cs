using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePaila.ViewModel
{
    public class Comment
    {
        public int ID { get; set; }
        public int ArticleID { get; set; }
        public string CommenBy { get; set; }
        public string Text { get; set; }
        public DateTime CommentOn { get; set; }
    }
}
