using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticleProject.Models;
using ArticleProject.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ArticleProject.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        ArticleDBContext db;
        public ArticleRepository(ArticleDBContext _db)
        {
            db = _db;
        }
        public async Task<int> AddArticle(Article Article)
        {
            if (db != null)
            {
                await db.Article.AddAsync(Article);
                await db.SaveChangesAsync();

                return Article.Id;
            }

            return 0;
        }

        public async Task<int> DeleteArticle(int? ArticleId)
        {
            int result = 0;

            if (db != null)
            {
                var post = await db.Article.FirstOrDefaultAsync(x => x.Id == ArticleId);

                if (post != null)
                {
                    db.Article.Remove(post);

                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<ArticleViewModel> GetArticle(int? ArticleId)
        {
            if (db != null)
            {
                var query = await db.Article.Where(x => x.Id == ArticleId).FirstOrDefaultAsync();
                if (query != null)
                {
                    return await (from a in db.Article
                                  join c in db.Category on a.CategoryId equals c.Id
                                  where a.Id == ArticleId
                                  select new ArticleViewModel
                                  {
                                      id = a.Id,
                                      article_title = a.ArticleTitle,
                                      article_description = a.ArticleDescription,
                                      category_id = a.CategoryId,
                                      category_name = c.CategoryName,
                                      category_description = c.CategoryDescription
                                  }).FirstOrDefaultAsync();
                }
            }

            return null;
        }

        public async Task<List<ArticleViewModel>> GetArticles()
        {
            if (db != null)
            {
                return await (from a in db.Article
                              join c in db.Category on a.CategoryId equals c.Id
                              select new ArticleViewModel
                              {
                                  id = a.Id,
                                  article_title = a.ArticleTitle,
                                  article_description = a.ArticleDescription,
                                  category_id = a.CategoryId,
                                  category_name = c.CategoryName,
                                  category_description = c.CategoryDescription
                              }).ToListAsync();
            }

            return null;
        }

        public async Task<List<Category>> GetCategories()
        {
            if (db != null)
            {
                return await db.Category.ToListAsync();
            }

            return null;
        }

        public async Task UpdateArticle(Article Article)
        {
            if (db != null)
            {
                db.Article.Update(Article);
                await db.SaveChangesAsync();
            }
        }
    }
}
