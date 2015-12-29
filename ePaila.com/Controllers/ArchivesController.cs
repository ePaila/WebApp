using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ePaila.ViewModel;
using ePaila.Data.Repo;

namespace ePaila.com.Controllers
{
    public class ArchivesController : BaseController
    {
        ArticleRepository _articleRepo;
        public ArchivesController(ePaila.Data.ePailaEntities db) : base(db)
        {
            _articleRepo = new ArticleRepository(db);
        }

        // GET: Archives
        public ActionResult Index()
        {
            ArchivesViewModel model = new ArchivesViewModel();
            model.Articles = _articleRepo.GetAll();
            return View(model);
        }
    }
}