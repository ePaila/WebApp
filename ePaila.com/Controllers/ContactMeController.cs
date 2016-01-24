using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ePaila.ViewModel;
using ePaila.Utility;
using ePaila.Data.Repo;

namespace ePaila.com.Controllers
{
    public class ContactMeController : BaseController
    {
        ContactUsRepository _contactUsRepo;
        public ContactMeController(ePaila.Data.ePailaEntities db) : base(db)
        {
            _contactUsRepo = new ContactUsRepository(db);
        }

        // GET: ContactMe
        public ActionResult Index()
        {
            ContactMeViewModel model = new ContactMeViewModel();
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(string name, string email, string message)
        {
            ContactMeViewModel model = new ContactMeViewModel();
            model.Name = name;
            model.Email = email;
            model.Message = message;
            _contactUsRepo.Insert(name, email, message);
            ViewBag.Msg = "Sent";
            return View(model);
        }
    }
}