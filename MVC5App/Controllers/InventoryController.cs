using MVC5App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5App.Controllers
{
    public class InventoryController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewData["category"] = Request["category"];
            if (ViewData["category"] == null) { ViewData["category"] = 0; }
            return View();
        }
    }
}