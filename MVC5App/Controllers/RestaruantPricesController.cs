using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5App.Models;

namespace MVC5App.Controllers
{
    public class RestaruantPricesController : Controller
    {
        // GET: RestaruantPrices
        public ActionResult RestaurantPrices()
        {
            var RestaurantPrices = new RestaruantPricesModels() { };

            return View(RestaurantPrices);
        }

        public ActionResult GetPrices()
        {
            using (var sql = new Tools.OurSql())
            {
                List<RestaruantPricesModels> priceList = new List<RestaruantPricesModels>();
                var rdr = sql.Query("");
                while (rdr.Read())
                {
                    var priceData = new RestaruantPricesModels()
                    {
                        FoodName = rdr.GetString(0),
                        FoodCategory = rdr.GetString(1),
                        FoodId = rdr.GetDecimal(2),
                        CostPrice = rdr.GetDecimal(3),
                        ListPrice = rdr.GetDecimal(4)
                    };
                    priceList.Add(priceData);
                }
                return Json(new { priceList }, JsonRequestBehavior.AllowGet);
            }

        }

        public void Update(string foodName, string foodCategory, Decimal foodId, Decimal costPrice, Decimal listPrice)
        {

        }

        public void Insert(string foodName, string foodCategory, Decimal foodId, Decimal costPrice, Decimal listPrice)
        {

        }
    }
}