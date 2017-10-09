using IMS.Application.Stores.Dtos;
using IMS.Domain.Entities;

namespace IMS.Application.Stores.Mappers
{
    public static class StoreDtoMapper
    {
        public static StoreDto Map(Store source)
        {
            return new StoreDto
            {
                Id = source.Id,
                Name = source.Name,
                Address = source.Address
            };
        }
    }
}