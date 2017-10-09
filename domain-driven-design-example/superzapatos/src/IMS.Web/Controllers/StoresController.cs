using System.Linq;
using System.Net;
using System.Web.Mvc;
using IMS.Application.Stores;
using IMS.Application.Stores.Dtos;

namespace IMS.Web.Controllers
{
    public class StoresController : Controller
    {
        private readonly IStoreAppService _storeAppService;

        public StoresController(IStoreAppService storeAppService)
        {
            _storeAppService = storeAppService;
        }

        // GET: Stores
        public ActionResult Index()
        {
            var output = _storeAppService.GetAllStores();

            return View(output.Stores);
        }

        // GET: Stores/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var input = new GetStoresInput {Id = id.Value};
            var output = _storeAppService.GetStore(input);

            if (!output.Stores.Any())
            {
                return HttpNotFound();
            }

            return View(output.Stores.First());
        }

        // GET: Stores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address")] StoreDto store)
        {
            if (ModelState.IsValid)
            {
                _storeAppService.CreateStore(store);

                return RedirectToAction("Index");
            }

            return View(store);
        }

        // GET: Stores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var input = new GetStoresInput {Id = id.Value};
            var output = _storeAppService.GetStore(input);

            if (!output.Stores.Any())
            {
                return HttpNotFound();
            }

            return View(output.Stores.First());
        }

        // POST: Stores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address")] StoreDto store)
        {
            if (ModelState.IsValid)
            {
                _storeAppService.UpdateStore(store);

                return RedirectToAction("Index");
            }

            return View(store);
        }

        // GET: Stores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var input = new GetStoresInput {Id = id.Value};
            var output = _storeAppService.GetStore(input);

            if (!output.Stores.Any())
            {
                return HttpNotFound();
            }

            return View(output.Stores.First());
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var deleteStoreInput = new DeleteStoreInput {Id = id};
            _storeAppService.DeleteStore(deleteStoreInput);

            return RedirectToAction("Index");
        }
    }
}