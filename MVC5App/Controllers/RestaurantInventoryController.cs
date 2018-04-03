using MVC5App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5App.Controllers
{
    public class RestaurantInventoryController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewData["sort"] = Request["sort"];
            if (ViewData["sort"] == null) { ViewData["sort"] = "item"; }
            return View();
        }

        private void Insert(RestaurantInventoryViewModel model)
        {
            // insert a new value into the database
            using (var sql = new Tools.OurSql())
            {
                var values = new Dictionary<string, string>
                {
                    { "Item", model.Item + "" },
                    { "Cost", model.Cost + "" },
                    { "SoldFor", model.SoldFor + "" },
                    { "AmountSold", model.AmountSold + "" }
                };
                sql.Insert("RestaurantInventory", values);
            }
        }

        private void Update(RestaurantInventoryViewModel model)
        {
            // update values in to the databse
            using (var sql = new Tools.OurSql())
            {
                var values = new Dictionary<string, string>
                {
                    { "Id", model.Id + "" },
                    { "Item", model.Item + "" },
                    { "Cost", model.Cost + "" },
                    { "SoldFor", model.SoldFor + "" },
                    { "AmountSold", model.AmountSold + "" }
                };
                sql.Update("RestaurantInventory", "Id", model.Id + "", values);
            }
        }

        [HttpPost]
        public ActionResult Index(RestaurantInventoryViewModel model)
        {
            ViewData["sort"] = Request["sort"];

            // check for parse errors
            if (Request.HttpMethod == "POST")
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        if (model.Id == -1)
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

            if (ViewData["sort"] == null) { ViewData["sort"] = "item"; }
            return View();
        }
    }
}