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
        [Route("Reporting/AuditReport/{table}")]
        public ActionResult Index(string table)
        {
            ViewData["table"] = table;
            return View("AuditReport");
        }

        // GET: AuditReport - All tables
        [Route("Reporting/AuditReport/")]
        public ActionResult Index()
        {
            return View("AuditReport");
        }
    }
}