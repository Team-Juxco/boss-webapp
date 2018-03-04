using MySql.Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5App.Models
{
    public class SalesModel
    {
        public string categoryName { get; set; }
        public DateTime OnDate { get; set; }
        public string dateString { get; set; }
        public Decimal net { get; set; }
        public Decimal gross { get; set; }
    }

    public class SalesMonthModel
    {
        public string categoryName { get; set; }
        public string month { get; set; }
        public Decimal monthlyGross { get; set; }
        public Decimal monthlyNet { get; set; }
    }
    public class SalesYearModel
    {
        public string categoryName { get; set; }
        public string year { get; set; }
        public Decimal yearlyNet { get; set; }
        public Decimal yearlyGross { get; set; }
    }


}