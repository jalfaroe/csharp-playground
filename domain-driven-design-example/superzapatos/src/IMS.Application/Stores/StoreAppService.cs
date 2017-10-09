using IMS.Application.Stores.Dtos;
using IMS.Application.Stores.Mappers;
using IMS.Domain.Repositories;

namespace IMS.Application.Stores
{
    public class StoreAppService : IStoreAppService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreAppService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public GetStoresOutput GetAllStores()
        {
            var stores = _storeRepository.GetAll();
            var output = GetStoresOutputMapper.Map(stores);
            output.Success = true;

            return output;
        }

        public GetStoresOutput GetStore(GetStoresInput input)
        {
            var store = _storeRepository.GetById(input.Id);
            var output = GetStoresOutputMapper.Map(store);
            output.Success = true;

            return output;
        }

        public void CreateStore(StoreDto input)
        {
            var store = StoreMapper.Map(input);
            _storeRepository.Add(store);
        }

        public void UpdateStore(StoreDto input)
        {
            var store = StoreMapper.Map(input);
            _storeRepository.Update(store);
        }

        public void DeleteStore(DeleteStoreInput input)
        {
            _storeRepository.Delete(input.Id);
        }
    }
}