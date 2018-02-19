using System;
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

    public class InventoryCategoryViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(45, ErrorMessage = "Name cannot be longer than 45 characters.")]
        [DataType(DataType.Text)]
        public int Name { get; set; }
    }

    public class InventoryViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int Category { get; set; }

        [Required]
        [MaxLength(45, ErrorMessage = "Description cannot be longer than 45 characters.")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required]
        public int Stock { get; set; }
    }

    public class InventoryChangeViewModel
    {
        [Required]
        public int OriginalId { get; set; }

        [Required]
        public int Id { get; set; }

        [Required]
        public int Category { get; set; }

        [Required]
        [MaxLength(45, ErrorMessage = "Description cannot be longer than 45 characters.")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public int ViewingCategory { get; set; }
    }
}