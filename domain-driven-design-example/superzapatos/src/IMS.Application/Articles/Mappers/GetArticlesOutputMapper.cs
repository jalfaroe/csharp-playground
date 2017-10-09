using System.Collections.Generic;
using System.Linq;
using IMS.Application.Articles.Dtos;
using IMS.Domain.Entities;

namespace IMS.Application.Articles.Mappers
{
    public static class GetArticlesOutputMapper
    {
        public static GetArticlesOutput Map(IEnumerable<Article> source)
        {
            var result = new GetArticlesOutput
            {
                Articles = source == null ? new List<ArticleDto>() : source.Select(ArticleDtoMapper.Map).ToList()
            };

            return result;
        }

        public static GetArticlesOutput Map(Article source)
        {
            var result = new GetArticlesOutput
            {
                Articles = source == null ? new List<ArticleDto>() : new List<ArticleDto> {ArticleDtoMapper.Map(source)}
            };

            return result;
        }
    }
}