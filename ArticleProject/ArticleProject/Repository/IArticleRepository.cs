using ArticleProject.Models;
using ArticleProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticleProject.Repository
{
    public interface IArticleRepository
    {

        Task<List<Category>> GetCategories();

        Task<List<ArticleViewModel>> GetArticles();

        Task<ArticleViewModel> GetArticle(int? ArticleId);

        Task<int> AddArticle(Article Article);

        Task<int> DeleteArticle(int? ArticleId);

        Task UpdateArticle(Article Article);
    }
}
