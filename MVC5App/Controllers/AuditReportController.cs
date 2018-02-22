using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5App.Models;

namespace MVC5App.Controllers
{
    public class AuditReportController : Controller
    {

        // GET: AuditReport - Specific table to queried 
        [Route("AuditReport/index/{table}")]
        public ActionResult Index(string table)
        {
            ViewData["table"] = table;
            return View("AuditReport");
        }

        // GET: AuditReport - All tables
        [Route("AuditReport/index/")]
        public ActionResult Index()
        {
            return View("AuditReport");
        }
    }
}