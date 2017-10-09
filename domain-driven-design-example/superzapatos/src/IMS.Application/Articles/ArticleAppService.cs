using IMS.Application.Articles.Dtos;
using IMS.Application.Articles.Mappers;
using IMS.Domain.Repositories;

namespace IMS.Application.Articles
{
    public class ArticleAppService : IArticleAppService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleAppService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public GetArticlesOutput GetAllArticles()
        {
            var articles = _articleRepository.GetAll();
            var output = GetArticlesOutputMapper.Map(articles);
            output.Success = true;

            return output;
        }

        public GetArticlesOutput GetArticles(int storeId)
        {
            var articles = _articleRepository.GetByStoreId(storeId);
            var output = GetArticlesOutputMapper.Map(articles);
            output.Success = true;

            return output;
        }

        public GetArticlesOutput GetArticle(GetArticleInput input)
        {
            var article = _articleRepository.GetById(input.Id);
            var output = GetArticlesOutputMapper.Map(article);
            output.Success = true;

            return output;
        }

        public void CreateArticle(ArticleDto input)
        {
            var article = ArticleMapper.Map(input);
            _articleRepository.Add(article);
        }

        public void UpdateArticle(ArticleDto input)
        {
            var article = ArticleMapper.Map(input);
            _articleRepository.Update(article);
        }

        public void DeleteArticle(DeleteArticleInput input)
        {
            _articleRepository.Delete(input.Id);
        }
    }
}