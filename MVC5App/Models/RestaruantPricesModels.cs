using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5App.Models
{
    public class RestaruantPricesModels
    {
        public string FoodName { get; set; }
        public string FoodCategory { get; set; }
        public Decimal FoodId { get; set; }
        public Decimal CostPrice { get; set; }
        public Decimal ListPrice { get; set; }
    }
}