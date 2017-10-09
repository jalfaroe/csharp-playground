using IMS.Application.Articles.Dtos;
using IMS.Domain.Entities;

namespace IMS.Application.Articles.Mappers
{
    public static class ArticleMapper
    {
        public static Article Map(ArticleDto source)
        {
            return new Article
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description,
                Price = source.Price,
                StoreId = source.StoreId,
                TotalInShelf = source.TotalInShelf,
                TotalInVault = source.TotalInVault
            };
        }
    }
}