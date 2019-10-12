using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticleProject.Models;
using ArticleProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArticleProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        IArticleRepository ArticleRepository;
        public ArticleController(IArticleRepository _ArticleRepository)
        {
            ArticleRepository = _ArticleRepository;
        }
        [HttpGet]
        [Route("GetCategories")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await ArticleRepository.GetCategories();
                if (categories == null)
                {
                    return NotFound();
                }

                return Ok(categories);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpGet]
        [Route("GetArticles")]
        public async Task<IActionResult> GetArticles()
        {
            try
            {
                var Articles = await ArticleRepository.GetArticles();
                if (Articles == null)
                {
                    return NotFound();
                }

                return Ok(Articles);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetArticle")]
        public async Task<IActionResult> GetArticle(int? ArticleId)
        {
            if (ArticleId == null)
            {
                return BadRequest();
            }

            try
            {
                var Article = await ArticleRepository.GetArticle(ArticleId);

                if (Article == null)
                {
                    return NotFound();
                }

                return Ok(Article);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("AddArticle")]
        public async Task<IActionResult> AddArticle([FromBody]Article model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var ArticleId = await ArticleRepository.AddArticle(model);
                    if (ArticleId > 0)
                    {
                        return Ok(ArticleId);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {

                    return BadRequest();
                }

            }

            return BadRequest();
        }

        [HttpPost]
        [Route("DeleteArticle")]
        public async Task<IActionResult> DeleteArticle(int? ArticleId)
        {
            int result = 0;

            if (ArticleId == null)
            {
                return BadRequest();
            }

            try
            {
                result = await ArticleRepository.DeleteArticle(ArticleId);
                if (result == 0)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPost]
        [Route("UpdateArticle")]
        public async Task<IActionResult> UpdateArticle([FromBody]Article model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await ArticleRepository.UpdateArticle(model);

                    return Ok();
                }
                catch (Exception ex)
                {
                    if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
                    {
                        return NotFound();
                    }

                    return BadRequest();
                }
            }

            return BadRequest();
        }
    }
}