using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5App.Models;

namespace MVC5App.Controllers
{
    public class BusinessExpController : Controller
    {
        [HttpGet]
        public ActionResult BusinessExp()
        {
            var BusinessExp = new BusinessExpViewModel() { };
            return View(BusinessExp);
        }

        public ActionResult GetBusinessExp(string beginDate, string endDate)
        {
            using (var sql = new Tools.OurSql())
            {
                List<BusinessExpViewModel> expDataList = new List<BusinessExpViewModel>();
                var rdr = sql.Query("SELECT InvoiceNum, BusinessExpenses.VendorId, OnDate, DueDate, AccountNum, Amount , IFNULL(Name,''), IFNULL(Contact,''), IFNULL(Street,''), " +
                                    "IFNULL(City,''), IFNULL(State,''), IFNULL(Zip,0), IFNULL(Phone,0), IFNULL(Email,''), IFNULL(TaxId,0) " +
                                    "FROM BusinessExpenses " +
                                    "LEFT JOIN VendorInfo on BusinessExpenses.VendorId = VendorInfo.VendorId " +
                                    "WHERE OnDate >= '" + beginDate + "' AND OnDate <= '" + endDate + "'" +
                                    "ORDER BY InvoiceNum desc;");
                while (rdr.Read())
                {
                    var expData = new BusinessExpViewModel()
                    {
                        InvoiceNum = rdr.GetInt32(0),
                        VendorId = rdr.GetInt32(1),
                        OnDate = rdr.GetString(2),
                        DueDate = rdr.GetString(3),
                        AccountNum = rdr.GetInt32(4),
                        Amount = rdr.GetDecimal(5),
                        VendorInfo = "Tax ID: " + rdr.GetInt32(14).ToString() + "\n" +
                        rdr.GetString(6) + "\n" + rdr.GetString(7) + "\n" +
                        rdr.GetString(8) + " " + rdr.GetString(9) + ", " + rdr.GetString(10) + " " + rdr.GetInt32(11).ToString() + "\n" +
                        rdr.GetInt32(12).ToString() + "\n" + rdr.GetString(13)
                    };
                    if (rdr.GetString(6) == "" || rdr.GetString(7)== "" || rdr.GetInt32(12) == 0)
                    {
                        expData.VendorInfo = "Vendor info not available"; 
                    }
                    expDataList.Add(expData);
                }
                return Json(new { expDataList }, JsonRequestBehavior.AllowGet);
            }
        }
        public void Insert(BusinessExpViewModel model)
        {
            // insert a new value into the database
            using (var sql = new Tools.OurSql())
            {
                var values = new Dictionary<string, string>
                {
                    { "VendorId", model.VendorId + "" },
                    { "OnDate", model.OnDate + ""},
                    { "DueDate", model.DueDate + "" },
                    { "AccountNum", model.AccountNum + "" },
                    { "Amount", model.Amount + "" }
                };
                sql.Insert("BusinessExpenses", values);
            }
        }

        public void Update(string InvoiceNum, string newValue, string colName)
        {
            // update values in to the databse
            using (var sql = new Tools.OurSql())
            {
                var values = new Dictionary<string, string>();
                values.Add(colName, newValue );
                

                sql.Update("BusinessExpenses", "InvoiceNum", InvoiceNum + "", values);
            }

            
        }

        
    }
}