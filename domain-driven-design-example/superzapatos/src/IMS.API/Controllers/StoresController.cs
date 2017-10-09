using System;
using System.Web.Http;
using IMS.Application.Stores;

namespace IMS.API.Controllers
{
    public class StoresController : ApiController
    {
        private readonly IStoreAppService _storeAppService;

        public StoresController(IStoreAppService storeAppService)
        {
            _storeAppService = storeAppService;
        }

        // GET services/stores
        public IHttpActionResult Get()
        {
            try
            {
                var stores = _storeAppService.GetAllStores();

                return Ok(stores);
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }
    }
}