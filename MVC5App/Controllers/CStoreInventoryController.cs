using MVC5App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5App.Controllers
{
    public class CStoreInventoryController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewData["sort"] = Request["sort"];
            if (ViewData["sort"] == null) { ViewData["sort"] = "category"; }
            return View();
        }

        private void Insert(CStoreInventoryChangeViewModel model)
        {
            // insert a new value into the database
            using (var sql = new Tools.OurSql())
            {
                var values = new Dictionary<string, string>
                {
                    { "Id", model.Id + "" },
                    { "Category", model.Category + "" },
                    { "Description", model.Description },
                    { "Stock", model.Stock + "" },
                    { "SalePrice", model.SalePrice + "" },
                    { "ListPrice", model.ListPrice + "" }
                };
                sql.Insert("CStoreInventory", values);
            }
        }

        private void Update(CStoreInventoryChangeViewModel model)
        {
            // update values in to the databse
            using (var sql = new Tools.OurSql())
            {
                var values = new Dictionary<string, string>
                {
                    { "Id", model.Id + "" },
                    { "Category", model.Category + "" },
                    { "Description", model.Description },
                    { "Stock", model.Stock + "" },
                    { "SalePrice", model.SalePrice + "" },
                    { "ListPrice", model.ListPrice + "" }
                };
                sql.Update("CStoreInventory", "Id", model.OriginalId + "", values);
            }
        }

        [HttpPost]
        public ActionResult Index(CStoreInventoryChangeViewModel model)
        {
            ViewData["sort"] = Request["sort"];

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

            if (ViewData["sort"] == null) { ViewData["sort"] = "category"; }
            return View();
        }
    }
}