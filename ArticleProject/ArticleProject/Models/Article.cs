using System;
using System.Collections.Generic;

namespace ArticleProject.Models
{
    public partial class Article
    {
        public int Id { get; set; }
        public string ArticleTitle { get; set; }
        public string ArticleDescription { get; set; }
        public int? CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
