using MVC5App.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using Tools;

namespace MVC5App.Controllers
{
    public class FuelSalesController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return Page(null);
        }

        [HttpPost]
        public ActionResult Index(FuelSalesViewModel model)
        {
            return Page(model);
        }

        public ActionResult Page(FuelSalesViewModel model)
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
                        { "Dollars", model.Dollars.ToString() }
                    };
                        sql.Replace("FuelSales", values);
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

            // determine if we are viewing the dashboard or a single month
            // single month's url looks like [normal url]/2018-02/
            ViewData["yearMonth"] = DateHelper.YearMonthFromUrl(Request, 3);
            if (ViewData["yearMonth"] != null)
            {
                return View("FuelSalesMonth", model);
            }
            else
            {
                return View("FuelSales", model);
            }
        }
    }
}