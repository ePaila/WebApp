﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class AboutMeController : BaseController
    {
        // GET: AboutMe
        public ActionResult Index()
        {
            return View();
        }
    }
}