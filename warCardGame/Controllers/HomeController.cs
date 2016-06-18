using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using warCardGame.Models;

namespace warCardGame.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new WarViewModel());
        }
    }
}