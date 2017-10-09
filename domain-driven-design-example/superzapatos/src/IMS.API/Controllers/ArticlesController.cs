using System;
using System.Web.Http;
using IMS.Application.Articles;

namespace IMS.API.Controllers
{
    [RoutePrefix("services")]
    public class ArticlesController : ApiController
    {
        private readonly IArticleAppService _articleAppService;

        public ArticlesController(IArticleAppService articleAppService)
        {
            _articleAppService = articleAppService;
        }

        // GET services/articles
        public IHttpActionResult Get()
        {
            try
            {
             var articles = _articleAppService.GetAllArticles();

                return Ok(articles);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

        // GET services/articles/stores/5
        [Route("articles/stores/{id}")]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var articles = _articleAppService.GetArticles(id);

                if (articles == null)
                {
                    return NotFound();
                }

                return Ok(articles);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}