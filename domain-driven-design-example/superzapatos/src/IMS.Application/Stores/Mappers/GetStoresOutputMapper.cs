using System.Collections.Generic;
using System.Linq;
using IMS.Application.Stores.Dtos;
using IMS.Domain.Entities;

namespace IMS.Application.Stores.Mappers
{
    public static class GetStoresOutputMapper
    {
        public static GetStoresOutput Map(IEnumerable<Store> source)
        {
            var result = new GetStoresOutput
            {
                Stores = source == null ? new List<StoreDto>() : source.Select(StoreDtoMapper.Map).ToList()
            };

            return result;
        }

        public static GetStoresOutput Map(Store source)
        {
            var result = new GetStoresOutput
            {
                Stores = source == null ? new List<StoreDto>() : new List<StoreDto> {StoreDtoMapper.Map(source)}
            };

            return result;
        }
    }
}