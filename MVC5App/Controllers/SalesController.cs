using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MVC5App.Models;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MVC5App.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Sales()
        {
            var Sales = new SalesModel() { };

            return View(Sales);

        }
        public ActionResult GetSalesData(string categoryName, string beginDate, string endDate)
        {
            using (var sql = new Tools.OurSql())
            {
                List<SalesModel> salesDataList = new List<SalesModel>();
                var rdr = sql.Query("SELECT date_format(OnDate, '%b %d, %Y') as OnDate, " + categoryName + "Gross, " + categoryName + "Net " +
                                    "FROM Sales " +
                                    "WHERE OnDate >= '" + beginDate + "' AND OnDate <= '" + endDate + "';");
                while (rdr.Read())
                {
                    var salesData = new SalesModel() { dateString = rdr.GetString(0), gross = rdr.GetDecimal(1), net = rdr.GetDecimal(2) };
                    salesDataList.Add(salesData);
                }
                return Json(new { salesDataList }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult GetMonthlySalesData(string categoryName, string year)
        {
            List<SalesMonthModel> monthlySalesList = new List<SalesMonthModel>();
            Decimal yearGross = 0; ;
            Decimal yearNet = 0; ;
            using (var sql = new Tools.OurSql())
            {
                var rdr = sql.Query("SELECT date_format(OnDate, '%M %Y') AS Month, sum(" + categoryName + "Net) AS netMonthly, sum(" + categoryName + "Gross) AS grossMonthly " +
                                    "FROM Sales " +
                                    "WHERE YEAR(OnDate) >= '" + year + "' AND YEAR(OnDate) <= '" + year + "' " +
                                    "GROUP BY YEAR(OnDate), MONTH(OnDate)");

                while (rdr.Read())
                {
                    //split date into month and year
                    var monthYear = rdr.GetString(0).Split(' ');
                    var monthSales = new SalesMonthModel() { month = monthYear[0], monthlyNet = rdr.GetDecimal(1), monthlyGross = rdr.GetDecimal(2) };
                    yearNet += rdr.GetDecimal(1);
                    yearGross += rdr.GetDecimal(2);
                    monthlySalesList.Add(monthSales);
                }
            }
            var yearSales = new SalesYearModel() { yearlyGross = yearGross, yearlyNet = yearNet };


            return Json(new { monthlySalesList, yearSales }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetYearlySalesData(string categoryName)
        {
            List<SalesYearModel> yearlySalesList = new List<SalesYearModel>();
            using (var sql = new Tools.OurSql())
            {
                var rdr = sql.Query("SELECT date_format(OnDate, '%Y') AS YEAR, sum(" + categoryName + "Net) AS netYearly, sum(" + categoryName + "Gross) AS grossYearly " +
                                    "FROM Sales " +
                                    "GROUP BY YEAR(OnDate);");
                while (rdr.Read())
                {
                    var yearlySales = new SalesYearModel() { year = rdr.GetString(0), yearlyNet = rdr.GetDecimal(1), yearlyGross = rdr.GetDecimal(2) };
                    yearlySalesList.Add(yearlySales);
                }
            }


            return Json(new { yearlySalesList }, JsonRequestBehavior.AllowGet);
        }

        public void Update(string onDate, string columnName, Decimal newValue)
        {
            System.Diagnostics.Debug.WriteLine(onDate + "" + columnName + "val:" + newValue);
            var sql = new Tools.OurSql();
            sql.UpdateSales(columnName, onDate, newValue);


        }
    }
}