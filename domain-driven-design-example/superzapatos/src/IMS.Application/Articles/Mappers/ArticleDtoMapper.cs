using IMS.Application.Articles.Dtos;
using IMS.Application.Stores.Mappers;
using IMS.Domain.Entities;

namespace IMS.Application.Articles.Mappers
{
    public static class ArticleDtoMapper
    {
        public static ArticleDto Map(Article source)
        {
            return new ArticleDto
            {
                Id = source.Id,
                Name = source.Name,
                Description = source.Description,
                Price = source.Price,
                StoreId = source.StoreId,
                TotalInShelf = source.TotalInShelf,
                TotalInVault = source.TotalInVault,
                Store = StoreDtoMapper.Map(source.Store)
            };
        }
    }
}