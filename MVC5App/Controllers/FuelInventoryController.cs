using MVC5App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tools;

namespace MVC5App.Controllers
{
    public class FuelInventoryController : Controller
    {
        [HttpGet]
        public ActionResult A() { return Page("A", null); }

        [HttpPost]
        public ActionResult A(FuelInventoryViewModel model) { return Page("A", model); }

        [HttpGet]
        public ActionResult B() { return Page("B", null); }

        [HttpPost]
        public ActionResult B(FuelInventoryViewModel model) { return Page("B", model); }

        public ActionResult Page(string tank, FuelInventoryViewModel model)
        {
            // check for parse errors
            if (Request.HttpMethod == "POST")
            {
                if (ModelState.IsValid)
                {
                    // parsing worked, apply the post values to the databse
                    using (var sql = new Tools.OurSql())
                    {
                        var values = new Dictionary<string, string>
                    {
                        { "OnDate", model.OnDate.ToString("yyyy-MM-dd") },
                        { "FuelAmount", model.FuelAmount.ToString() }
                    };
                        sql.Replace("FuelInventory" + tank, values);
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
            }

            ViewData["tank"] = tank;
            // determine if we are viewing the dashboard or a single month
            // single month's url looks like [normal url]/2018-02/
            ViewData["yearMonth"] = DateHelper.YearMonthFromUrl(Request, 3);
            if (ViewData["yearMonth"] != null)
            {
                return View("FuelInventoryMonth", model);
            }
            else
            {
                return View("FuelInventory", model);
            }
        }

    }
}