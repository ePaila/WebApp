using ePaila.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ePaila.com.Controllers
{
    public class AboutMeController : BaseController
    {
        //ArticleRepository _articleRepo;

        public AboutMeController(ePaila.Data.ePailaEntities db) : base(db)
        {
           // _articleRepo = new ArticleRepository(db);
        }

        // GET: AboutMe
        public ActionResult Index()
        {
            AboutMeViewModel model = new AboutMeViewModel();
            return View(model);
        }
    }
}