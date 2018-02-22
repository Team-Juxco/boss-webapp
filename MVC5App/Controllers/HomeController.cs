using MVC5App.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using Tools;

namespace MVC5App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult FuelInventory()
        {
            ViewBag.Message = "Your fuel page.";

            // determine if we are viewing the dashboard or a single month
            // single month's url looks like [normal url]/2018-02/
            ViewData["yearMonth"] = DateHelper.YearMonthFromUrl(Request, 3);
            if (ViewData["yearMonth"] != null)
            {
                return View("FuelInventoryMonth");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult FuelInventory(FuelInventoryViewModel model)
        {
            // check for parse errors
            if (Request.HttpMethod == "POST" && ModelState.IsValid)
            {
                // parsing worked, apply the post values to the databse
                using (var sql = new Tools.OurSql())
                {
                    var values = new Dictionary<string, string>
                    {
                        { "OnDate", model.OnDate.ToString("yyyy-MM-dd") },
                        { "FuelAmount", model.FuelAmount.ToString() }
                    };
                    sql.Replace("FuelInventory", values);
                }
            }
            else
            {
                // parsing failed, throw up an error message
                string errorMessage = "Error:<br>";
                foreach (var val in ModelState.Values)
                {
                    foreach (var err in val.Errors)
                    {
                        errorMessage += err.ErrorMessage + "<br>";
                    }
                }
                return Content(errorMessage);
            }

            // determine if we are viewing the dashboard or a single month
            // single month's url looks like [normal url]/2018-02/
            ViewData["yearMonth"] = DateHelper.YearMonthFromUrl(Request, 3);
            if (ViewData["yearMonth"] != null)
            {
                return View("FuelInventoryMonth", model);
            }
            else
            {
                return View(model);
            }
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}