using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace MVC5App.Models
{
    public class AuditViewModel
    {
        [Required]
        public int logID { get; set; }
        [Required]
        public string tableName { get; set; }
        [Required]
        public string databaseAction { get; set; }
        //[Required]
        [DataType(DataType.Date)]
        public DateTime onDate { get; set; }
        public string previousValue { get; set; }
        public string updatedValue { get; set; }

        public AuditViewModel(int id, string table, string action, DateTime date, string prevValue, string updatedValue)
        {
            this.logID = id;
            this.tableName = table;
            this.databaseAction = action;
            this.onDate = date;
            this.previousValue = prevValue;
            this.updatedValue = updatedValue;
        }
     

    }
}