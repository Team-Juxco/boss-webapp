﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5App.Models
{
    public class FuelInventoryViewModel
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime OnDate { get; set; }

        [Required]
        public Decimal FuelAmount { get; set; }

    }
}