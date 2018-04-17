using MVC5App.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5App.Controllers
{
    public class ReportingController : Controller
    {
        // GET: Reporting
        public ActionResult Index()
        {
            var sql = new Tools.OurSql();
            List<FuelSalesViewModel> data = new List<FuelSalesViewModel>();
            var rdr = sql.Query("SELECT OnDate, Dollars " + "FROM FuelSales ") ;
            while (rdr.Read())
            {
                data.Add(new FuelSalesViewModel { OnDate = rdr.GetDateTime(0), Dollars = rdr.GetDecimal(1) });
            }
            return View(data);
        }
        public void ExportToExcel()
        {
            var sql = new Tools.OurSql();
            List<FuelSalesViewModel> data = new List<FuelSalesViewModel>();
            var rdr = sql.Query("SELECT OnDate, Dollars " + "FROM FuelSales ");
            while (rdr.Read()) { 
                
                data.Add(new FuelSalesViewModel {OnDate = rdr.GetDateTime(0),Dollars = rdr.GetDecimal(1) });
            }
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
            ws.Cells["A1"].Value = "Date";
            ws.Cells["B1"].Value = "Dollars";
            int rowstart = 2;
            foreach(var item in data)
            {
                ws.Cells[String.Format("A{0}", rowstart)].Value = item.OnDate.ToString();
                ws.Cells[String.Format("B{0}", rowstart)].Value = item.Dollars;
                rowstart++;

            }
            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();

        }
    }
}