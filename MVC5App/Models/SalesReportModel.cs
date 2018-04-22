using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5App.Models
{
    public class SalesReportModel
    {
        public DateTime OnDate { get; set; }
        public Decimal FountainNet {get; set;}
        public Decimal FountainGross { get; set; }
        public Decimal BeerWineNet { get; set; }
        public Decimal BeerWineGross{ get; set; }
        public Decimal SuppliesNet { get; set; }
        public Decimal SuppliesGross { get; set; }
        public Decimal CigPackNet { get; set; }
        public Decimal CigPackGross { get; set; }
        public Decimal CigCartonNet { get; set; }
        public Decimal CigCartonGross { get; set; }
        public Decimal LottoNet { get; set; }
        public Decimal LotoGross { get; set; }
        public Decimal PropaneNet { get; set; }
        public Decimal PropaneGross { get; set; }
        public Decimal PackBeverageNet { get; set; }
        public Decimal PackBeverageGross { get; set; }
        public Decimal CofeeNet { get; set; }
        public Decimal CofeeGross { get; set; }
        public Decimal PhoneCardNet { get; set; }
        public Decimal PhoneCardGross { get; set; }

    }
}