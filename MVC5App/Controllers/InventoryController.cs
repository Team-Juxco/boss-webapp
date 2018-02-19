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

        private void Insert(InventoryChangeViewModel model)
        {
            // insert a new value into the database
            using (var sql = new Tools.OurSql())
            {
                var values = new Dictionary<string, string>
                {
                    { "Id", model.Id + "" },
                    { "Category", model.Category + "" },
                    { "Description", model.Description },
                    { "Stock", model.Stock + "" }
                };
                sql.Insert("Inventory", values);
            }
        }

        private void Update(InventoryChangeViewModel model)
        {
            // update values in to the databse
            using (var sql = new Tools.OurSql())
            {
                var values = new Dictionary<string, string>
                {
                    { "Id", model.Id + "" },
                    { "Category", model.Category + "" },
                    { "Description", model.Description },
                    { "Stock", model.Stock + "" }
                };
                sql.Update("Inventory", "Id", model.OriginalId + "", values);
            }
        }

        [HttpPost]
        public ActionResult Index(InventoryChangeViewModel model)
        {
            ViewData["category"] = Request["category"];

            // check for parse errors
            if (Request.HttpMethod == "POST")
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        if (model.OriginalId == -1)
                        {
                            Insert(model);
                        }
                        else
                        {
                            Update(model);
                        }
                    }
                    catch (Exception ex)
                    {
                        ViewData["error"] = ex.Message;
                        return View("Error");
                    }

                    ViewData["category"] = Request["ViewingCategory"];
                }
                else
                {
                    // parsing failed, throw up an error message
                    string errorMessage = "";
                    foreach (var val in ModelState.Values)
                    {
                        foreach (var err in val.Errors)
                        {
                            errorMessage += err.ErrorMessage + "<br>";
                        }
                    }

                    ViewData["error"] = errorMessage;
                    return View("Error");
                }
            }

            if (ViewData["category"] == null) { ViewData["category"] = 0; }
            return View();
        }
    }
}