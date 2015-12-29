using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ePaila.ViewModel;
namespace ePaila.com.Controllers
{
    public class ContactMeController : BaseController
    {
        public ContactMeController(ePaila.Data.ePailaEntities db) : base(db)
        {

        }

        // GET: ContactMe
        public ActionResult Index()
        {
            ContactMeViewModel model = new ContactMeViewModel();
            return View(model);
        }
    }
}