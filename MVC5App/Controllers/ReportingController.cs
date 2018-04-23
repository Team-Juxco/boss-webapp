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
            return View();
        }
        public ActionResult BusinessExpensesReport()
        {
            var sql = new Tools.OurSql();
            List<BusinessExpViewModel> data = new List<BusinessExpViewModel>();
            var rdr = sql.Query("SELECT *" + "FROM BusinessExpenses");
            while (rdr.Read())
            {
                data.Add(new BusinessExpViewModel { InvoiceNum = rdr.GetInt32(0), VendorId= rdr.GetInt32(1), OnDate = rdr.GetString(2),
                    DueDate = rdr.GetString(3), AccountNum = rdr.GetInt32(4),Amount = rdr.GetInt32(5) });
            }
            return View(data);
        }
        public ActionResult RestaurantInventoryReport()
        {
            var sql = new Tools.OurSql();
            List<RestaurantInventoryViewModel> data = new List<RestaurantInventoryViewModel>();
            var rdr = sql.Query("SELECT *" + "FROM RestaurantInventory ");
            while (rdr.Read())
            {
                data.Add(new RestaurantInventoryViewModel { Id = rdr.GetInt32(0), Item = rdr.GetString(1),Cost = rdr.GetDecimal(2),SoldFor = rdr.GetDecimal(3),AmountSold = rdr.GetInt32(4) });
            }
            return View(data);
        }
        public ActionResult CStoreInventoryReport()
        {
            var sql = new Tools.OurSql();
            Dictionary<int,string> catagory = new Dictionary<int,string>();
            List<CStoreInventoryReportModel> data = new List<CStoreInventoryReportModel>();
            var rdr = sql.Query("SELECT * " + "FROM CStoreInventoryCategory ");
            while (rdr.Read())
            {
                catagory.Add(rdr.GetInt32(0), rdr.GetString(1));
            }
            rdr.Close();
            rdr = sql.Query("SELECT * " + "FROM CStoreInventory ");
            while (rdr.Read())
            {
                string temp = "";
                catagory.TryGetValue(rdr.GetInt32(1),out temp);
                data.Add(new CStoreInventoryReportModel
                { Id = rdr.GetInt32(0), Category = temp, Description = rdr.GetString(2),
                    Stock = rdr.GetInt32(3), SalePrice = rdr.GetDecimal(5), ListPrice = rdr.GetDecimal(6) });
            }
            return View(data);
        }
        public ActionResult StoreSalesReport()
        {
            var sql = new Tools.OurSql();
            List<SalesReportModel> data = new List<SalesReportModel>();
            var rdr = sql.Query("SELECT * " + "FROM Sales ");
            while (rdr.Read())
            {
                data.Add(new SalesReportModel { OnDate = rdr.GetDateTime(0), FountainNet = rdr.GetDecimal(1),
                    FountainGross = rdr.GetDecimal(2),
                    BeerWineNet = rdr.GetDecimal(3),
                    BeerWineGross = rdr.GetDecimal(4),
                    SuppliesNet = rdr.GetDecimal(5),
                    SuppliesGross = rdr.GetDecimal(6),
                    CigPackNet = rdr.GetDecimal(7),
                    CigPackGross = rdr.GetDecimal(8),
                    CigCartonNet = rdr.GetDecimal(9),
                    CigCartonGross = rdr.GetDecimal(10),
                    LottoNet = rdr.GetDecimal(11),
                    LotoGross = rdr.GetDecimal(12),
                    PropaneNet = rdr.GetDecimal(13),
                    PropaneGross= rdr.GetDecimal(14),
                    PackBeverageNet = rdr.GetDecimal(15),
                    PackBeverageGross = rdr.GetDecimal(16),
                    CofeeNet = rdr.GetDecimal(17),
                    CofeeGross = rdr.GetDecimal(18),
                    PhoneCardNet = rdr.GetDecimal(19),
                    PhoneCardGross = rdr.GetDecimal(20)
                });
            }
            return View(data);
        }
        public ActionResult FuelSalesReport()
        {
            var sql = new Tools.OurSql();
            List<FuelSalesViewModel> data = new List<FuelSalesViewModel>();
            var rdr = sql.Query("SELECT OnDate, Dollars " + "FROM FuelSales ");
            while (rdr.Read())
            {
                data.Add(new FuelSalesViewModel { OnDate = rdr.GetDateTime(0), Dollars = rdr.GetDecimal(1) });
            }
            return View(data);
        }
        public ActionResult FuelInventoryReport()
        {
            var sql = new Tools.OurSql();
            List<FuelInventoryViewModel> data = new List<FuelInventoryViewModel>();
            var rdr = sql.Query("SELECT OnDate, FuelAmount " + "FROM FuelInventoryA ");
            while (rdr.Read()) { 
            
                data.Add(new FuelInventoryViewModel { OnDate = rdr.GetDateTime(0), FuelAmount = rdr.GetDecimal(1) });
            }
            rdr.Close();
            rdr = sql.Query("SELECT OnDate, FuelAmount " + "FROM FuelInventoryB ");
            while (rdr.Read())
            { 
                data.Add(new FuelInventoryViewModel { OnDate = rdr.GetDateTime(0), FuelAmount = rdr.GetDecimal(1) });
            }
            return View(data);
        }
        public void ExportFuelSalesToExcel()
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
        public void ExportFuelInventoryToExcel()
        {
            var sql = new Tools.OurSql();
            List<FuelInventoryViewModel> data = new List<FuelInventoryViewModel>();
            var rdr = sql.Query("SELECT OnDate, FuelAmount " + "FROM FuelInventoryA ");
            while (rdr.Read())
            { 
                data.Add(new FuelInventoryViewModel { OnDate = rdr.GetDateTime(0), FuelAmount = rdr.GetDecimal(1) });
            }
            rdr.Close();
            rdr = sql.Query("SELECT OnDate, FuelAmount " + "FROM FuelInventoryB ");
            while (rdr.Read())
            {
                data.Add(new FuelInventoryViewModel { OnDate = rdr.GetDateTime(0), FuelAmount = rdr.GetDecimal(1) });
            }
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
            ws.Cells["A1"].Value = "Date";
            ws.Cells["B1"].Value = "FuelAmount";
            int rowstart = 2;
            foreach (var item in data)
            {
                ws.Cells[String.Format("A{0}", rowstart)].Value = item.OnDate.ToString();
                ws.Cells[String.Format("B{0}", rowstart)].Value = item.FuelAmount;
                rowstart++;

            }
            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();

        }
        public void ExportStoreSalesToExcel()
        {
            var sql = new Tools.OurSql();
            List<SalesReportModel> data = new List<SalesReportModel>();
            var rdr = sql.Query("SELECT * " + "FROM Sales ");
            while (rdr.Read())
            {
                data.Add(new SalesReportModel
                {
                    OnDate = rdr.GetDateTime(0),
                    FountainNet = rdr.GetDecimal(1),
                    FountainGross = rdr.GetDecimal(2),
                    BeerWineNet = rdr.GetDecimal(3),
                    BeerWineGross = rdr.GetDecimal(4),
                    SuppliesNet = rdr.GetDecimal(5),
                    SuppliesGross = rdr.GetDecimal(6),
                    CigPackNet = rdr.GetDecimal(7),
                    CigPackGross = rdr.GetDecimal(8),
                    CigCartonNet = rdr.GetDecimal(9),
                    CigCartonGross = rdr.GetDecimal(10),
                    LottoNet = rdr.GetDecimal(11),
                    LotoGross = rdr.GetDecimal(12),
                    PropaneNet = rdr.GetDecimal(13),
                    PropaneGross = rdr.GetDecimal(14),
                    PackBeverageNet = rdr.GetDecimal(15),
                    PackBeverageGross = rdr.GetDecimal(16),
                    CofeeNet = rdr.GetDecimal(17),
                    CofeeGross = rdr.GetDecimal(18),
                    PhoneCardNet = rdr.GetDecimal(19),
                    PhoneCardGross = rdr.GetDecimal(20)
                });
                
            }
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
            ws.Cells["A1"].Value = "Date";
            ws.Cells["B1"].Value = "FountainNet";
            ws.Cells["C1"].Value = "FountainGross";
            ws.Cells["D1"].Value = "BeerWineNet";
            ws.Cells["E1"].Value = "BeerWineGross";
            ws.Cells["F1"].Value = "SuppliesNet";
            ws.Cells["G1"].Value = "SuppliesGross";
            ws.Cells["H1"].Value = "CigPcakNet";
            ws.Cells["I1"].Value = "CigPackGross";
            ws.Cells["J1"].Value = "CigCartonNet";
            ws.Cells["K1"].Value = "CigCartonGross";
            ws.Cells["L1"].Value = "LottoNet";
            ws.Cells["M1"].Value = "LotoGross";
            ws.Cells["N1"].Value = "PropaneNet";
            ws.Cells["O1"].Value = "PropaneGross";
            ws.Cells["P1"].Value = "PackBeverageNet";
            ws.Cells["Q1"].Value = "PackBeverageGross";
            ws.Cells["R1"].Value = "CofeeNet";
            ws.Cells["S1"].Value = "CofeeGross";
            ws.Cells["T1"].Value = "PhoneCardNet";
            ws.Cells["U1"].Value = "PhoneCardGross";
            int rowstart = 2;
            foreach (var item in data)
            {
                ws.Cells[String.Format("A{0}", rowstart)].Value = item.OnDate.ToString();
                ws.Cells[String.Format("B{0}", rowstart)].Value = item.FountainNet;
                ws.Cells[String.Format("C{0}", rowstart)].Value = item.FountainGross;
                ws.Cells[String.Format("D{0}", rowstart)].Value = item.BeerWineNet;
                ws.Cells[String.Format("E{0}", rowstart)].Value = item.BeerWineGross;
                ws.Cells[String.Format("F{0}", rowstart)].Value = item.SuppliesNet;
                ws.Cells[String.Format("G{0}", rowstart)].Value = item.SuppliesGross;
                ws.Cells[String.Format("H{0}", rowstart)].Value = item.CigPackNet;
                ws.Cells[String.Format("I{0}", rowstart)].Value = item.CigPackGross;
                ws.Cells[String.Format("J{0}", rowstart)].Value = item.CigCartonNet;
                ws.Cells[String.Format("K{0}", rowstart)].Value = item.CigCartonGross;
                ws.Cells[String.Format("L{0}", rowstart)].Value = item.LottoNet;
                ws.Cells[String.Format("M{0}", rowstart)].Value = item.LotoGross;
                ws.Cells[String.Format("N{0}", rowstart)].Value = item.PropaneNet;
                ws.Cells[String.Format("O{0}", rowstart)].Value = item.PropaneGross;
                ws.Cells[String.Format("P{0}", rowstart)].Value = item.PackBeverageNet;
                ws.Cells[String.Format("Q{0}", rowstart)].Value = item.PackBeverageGross;
                ws.Cells[String.Format("R{0}", rowstart)].Value = item.CofeeNet;
                ws.Cells[String.Format("S{0}", rowstart)].Value = item.CofeeGross;
                ws.Cells[String.Format("T{0}", rowstart)].Value = item.PhoneCardNet;
                ws.Cells[String.Format("U{0}", rowstart)].Value = item.PhoneCardGross;
                rowstart++;

            }
            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "SalesReport.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();
        }
        public void ExportCstoreSalesToExcel()
        {
            var sql = new Tools.OurSql();
            Dictionary<int, string> catagory = new Dictionary<int, string>();
            List<CStoreInventoryReportModel> data = new List<CStoreInventoryReportModel>();
            var rdr = sql.Query("SELECT * " + "FROM CStoreInventoryCategory ");
            while (rdr.Read())
            {
                catagory.Add(rdr.GetInt32(0), rdr.GetString(1));
            }
            rdr.Close();
            rdr = sql.Query("SELECT * " + "FROM CStoreInventory ");
            while (rdr.Read())
            {
                string temp = "";
                catagory.TryGetValue(rdr.GetInt32(1), out temp);
                data.Add(new CStoreInventoryReportModel
                {
                    Id = rdr.GetInt32(0),
                    Category = temp,
                    Description = rdr.GetString(2),
                    Stock = rdr.GetInt32(3),
                    SalePrice = rdr.GetDecimal(5),
                    ListPrice = rdr.GetDecimal(6)
                });
            }
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
            ws.Cells["A1"].Value = "ID";
            ws.Cells["B1"].Value = "Category";
            ws.Cells["C1"].Value = "Description";
            ws.Cells["D1"].Value = "Stock";
            ws.Cells["E1"].Value = "Sale Price";
            ws.Cells["F1"].Value = "List Price";
            int rowstart = 2;
            foreach (var item in data)
            {
                ws.Cells[String.Format("A{0}", rowstart)].Value = item.Id;
                ws.Cells[String.Format("B{0}", rowstart)].Value = item.Category;
                ws.Cells[String.Format("C{0}", rowstart)].Value = item.Description.ToString();
                ws.Cells[String.Format("D{0}", rowstart)].Value = item.Stock;
                ws.Cells[String.Format("E{0}", rowstart)].Value = item.SalePrice;
                ws.Cells[String.Format("F{0}", rowstart)].Value = item.ListPrice;
                rowstart++;

            }
            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();
        }
        public void ExportRestaurantInventoryToExcel()
        {
            var sql = new Tools.OurSql();
            List<RestaurantInventoryViewModel> data = new List<RestaurantInventoryViewModel>();
            var rdr = sql.Query("SELECT *" + "FROM RestaurantInventory ");
            while (rdr.Read())
            {
                data.Add(new RestaurantInventoryViewModel { Id = rdr.GetInt32(0), Item = rdr.GetString(1), Cost = rdr.GetDecimal(2), SoldFor = rdr.GetDecimal(3), AmountSold = rdr.GetInt32(4) });
            }
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
            ws.Cells["A1"].Value = "Id";
            ws.Cells["B1"].Value = "Item";
            ws.Cells["C1"].Value = "Cost";
            ws.Cells["D1"].Value = "SoldFor";
            ws.Cells["E1"].Value = "AmountSold";
            int rowstart = 2;
            foreach (var item in data)
            {
                ws.Cells[String.Format("A{0}", rowstart)].Value = item.Id;
                ws.Cells[String.Format("B{0}", rowstart)].Value = item.Item;
                ws.Cells[String.Format("C{0}", rowstart)].Value = item.Cost;
                ws.Cells[String.Format("D{0}", rowstart)].Value = item.SoldFor;
                ws.Cells[String.Format("E{0}", rowstart)].Value = item.AmountSold;
                rowstart++;

            }
            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment: filename=" + "ExcelReport.xlsx");
            Response.BinaryWrite(pck.GetAsByteArray());
            Response.End();
        }
        public void ExportBusinessExpensesToExcel()
        {
            var sql = new Tools.OurSql();
            List<BusinessExpViewModel> data = new List<BusinessExpViewModel>();
            var rdr = sql.Query("SELECT *" + "FROM BusinessExpenses");
            while (rdr.Read())
            {
                data.Add(new BusinessExpViewModel
                {
                    InvoiceNum = rdr.GetInt32(0),
                    VendorId = rdr.GetInt32(1),
                    OnDate = rdr.GetString(2),
                    DueDate = rdr.GetString(3),
                    AccountNum = rdr.GetInt32(4),
                    Amount = rdr.GetInt32(5)
                });
            }
            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");
            ws.Cells["A1"].Value = "InvoiceNum";
            ws.Cells["B1"].Value = "VendorID";
            ws.Cells["C1"].Value = "OnDate";
            ws.Cells["D1"].Value = "DueDate";
            ws.Cells["E1"].Value = "AccountNum";
            ws.Cells["F1"].Value = "Amount";
            int rowstart = 2;
            foreach (var item in data)
            {
                ws.Cells[String.Format("A{0}", rowstart)].Value = item.InvoiceNum;
                ws.Cells[String.Format("B{0}", rowstart)].Value = item.VendorId;
                ws.Cells[String.Format("C{0}", rowstart)].Value = item.OnDate;
                ws.Cells[String.Format("D{0}", rowstart)].Value = item.DueDate;
                ws.Cells[String.Format("E{0}", rowstart)].Value = item.AccountNum;
                ws.Cells[String.Format("F{0}", rowstart)].Value = item.Amount;
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