using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleProject.ViewModels
{
    public class ArticleViewModel
    {
        public int id { get; set; }
        public string article_title { get; set; }
        public string article_description { get; set; }
        public int? category_id { get; set; }
        public string category_name { get; set; }
        public string category_description { get; set; }

    }
}
