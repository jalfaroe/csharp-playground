using IMS.Application.Stores.Dtos;

namespace IMS.Application.Stores
{
    public interface IStoreAppService
    {
        GetStoresOutput GetAllStores();

        GetStoresOutput GetStore(GetStoresInput input);

        void CreateStore(StoreDto input);

        void UpdateStore(StoreDto input);

        void DeleteStore(DeleteStoreInput input);
    }
}