using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5App.Models
{
    public class BusinessExpViewModel
    {
        [Required]
        public int InvoiceNum { get; set; }

        [Required]
        public int VendorId { get; set; }
        
        [Required]
        public String OnDate { get; set; }

        [Required]
        public String DueDate { get; set; }

        [Required]
        public int AccountNum { get; set; }

        [Required]
        public Decimal Amount { get; set; }

        public String VendorInfo { get; set; }

        
    }
}

