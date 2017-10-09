using IMS.Application.Articles.Dtos;

namespace IMS.Application.Articles
{
    public interface IArticleAppService
    {
        GetArticlesOutput GetAllArticles();
        GetArticlesOutput GetArticles(int storeId);
        GetArticlesOutput GetArticle(GetArticleInput input);
        void CreateArticle(ArticleDto input);
        void UpdateArticle(ArticleDto input);
        void DeleteArticle(DeleteArticleInput input);
    }
}