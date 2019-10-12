using System;
using System.Collections.Generic;

namespace ArticleProject.Models
{
    public partial class Category
    {
        public Category()
        {
            Article = new HashSet<Article>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public ICollection<Article> Article { get; set; }
    }
}
