using ePaila.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class eTVController : BaseController
    {
        public eTVController(ePaila.Data.ePailaEntities db) : base(db)
        {

        }
        // GET: eTV
        public ActionResult Index()
        {
            eTVViewModel model = new eTVViewModel();
            return View(model);
        }
    }
}