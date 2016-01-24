using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ePaila.Data.Repo;
using ePaila.ViewModel;

namespace ePaila.com.Controllers
{
    public class HomeController : BaseController
    {

        ArticleRepository _articleRepo;

        public HomeController(ePaila.Data.ePailaEntities db) : base(db)
        {
            _articleRepo = new ArticleRepository(db);
        }

        // GET: Home

        public ActionResult Index(int day = 0)
        {
            ArticleViewModel model = new ArticleViewModel();
            if (day == 0)
            {
                model.Articles = _articleRepo.Get();
                ViewBag.Title = "ePaila : Home";
            }
            else
            {
                DateTime dt = new DateTime(DateTime.Now.Year, DateTime.Now.Month, day);
                model.Articles = _articleRepo.Get(dt);
                ViewBag.Title = string.Format("ePaila : {0} {1}", DateTime.Now.ToString("MMM"), day);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Favorite(int id)
        {
            _articleRepo.Favorite(id,Utility.eIPAddress.GetIPAddress());
            return Json( _articleRepo.Favorite(id), JsonRequestBehavior.AllowGet);
        }   

        public ActionResult Details(int articleid)
        {
            ArticleDetailViewModel model = new ArticleDetailViewModel();
            model.Article = _articleRepo.Get(articleid);
            return View(model);
        }
    }
}