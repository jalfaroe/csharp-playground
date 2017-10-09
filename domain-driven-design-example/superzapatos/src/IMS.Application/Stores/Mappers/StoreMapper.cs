using IMS.Application.Stores.Dtos;
using IMS.Domain.Entities;

namespace IMS.Application.Stores.Mappers
{
    public static class StoreMapper
    {
        public static Store Map(StoreDto source)
        {
            return new Store
            {
                Id = source.Id,
                Address = source.Address,
                Name = source.Name
            };
        }
    }
}