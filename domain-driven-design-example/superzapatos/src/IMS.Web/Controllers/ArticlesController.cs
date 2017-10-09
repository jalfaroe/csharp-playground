using System.Linq;
using System.Net;
using System.Web.Mvc;
using IMS.Application.Articles;
using IMS.Application.Articles.Dtos;
using IMS.Application.Stores;

namespace IMS.Web.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly IArticleAppService _articleAppService;
        private readonly IStoreAppService _storeAppService;

        public ArticlesController(IArticleAppService articleAppService, IStoreAppService storeAppService)
        {
            _articleAppService = articleAppService;
            _storeAppService = storeAppService;
        }

        // GET: Articles
        public ActionResult Index()
        {
            var output = _articleAppService.GetAllArticles();

            return View(output.Articles);
        }

        // GET: Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var input = new GetArticleInput {Id = id.Value};
            var output = _articleAppService.GetArticle(input);

            if (!output.Articles.Any())
            {
                return HttpNotFound();
            }

            return View(output.Articles.First());
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            var storesOutput = _storeAppService.GetAllStores();
            ViewBag.StoreId = new SelectList(storesOutput.Stores, "Id", "Name");

            return View();
        }

        // POST: Articles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "Id,Name,Description,Price,TotalInShelf,TotalInVault,StoreId")] ArticleDto article)
        {
            if (ModelState.IsValid)
            {
                _articleAppService.CreateArticle(article);

                return RedirectToAction("Index");
            }

            var storesOutput = _storeAppService.GetAllStores();
            ViewBag.StoreId = new SelectList(storesOutput.Stores, "Id", "Name", article.StoreId);

            return View(article);
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var input = new GetArticleInput {Id = id.Value};
            var output = _articleAppService.GetArticle(input);

            if (!output.Articles.Any())
            {
                return HttpNotFound();
            }

            var storesOutput = _storeAppService.GetAllStores();
            ViewBag.StoreId = new SelectList(storesOutput.Stores, "Id", "Name", output.Articles.First().StoreId);

            return View(output.Articles.First());
        }

        // POST: Articles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Id,Name,Description,Price,TotalInShelf,TotalInVault,StoreId")] ArticleDto article)
        {
            if (ModelState.IsValid)
            {
                _articleAppService.UpdateArticle(article);

                return RedirectToAction("Index");
            }

            var storesOutput = _storeAppService.GetAllStores();
            ViewBag.StoreId = new SelectList(storesOutput.Stores, "Id", "Name", article.StoreId);

            return View(article);
        }

        // GET: Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var input = new GetArticleInput {Id = id.Value};
            var output = _articleAppService.GetArticle(input);

            if (!output.Articles.Any())
            {
                return HttpNotFound();
            }

            return View(output.Articles.First());
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var deleteArticleInput = new DeleteArticleInput {Id = id};
            _articleAppService.DeleteArticle(deleteArticleInput);

            return RedirectToAction("Index");
        }
    }
}