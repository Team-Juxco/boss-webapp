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
        public int LogID { get; set; }
        [Required]
        public string TableName { get; set; }
        [Required]
        public string DatabaseAction { get; set; }
        //[Required]
        [DataType(DataType.Date)]
        public DateTime OnDate { get; set; }
        public string PreviousValue { get; set; }
        public string UpdatedValue { get; set; }

        public AuditViewModel(int id, string table, string action, DateTime date, string prevValue, string updatedValue)
        {
            this.LogID = id;
            this.TableName = table;
            this.DatabaseAction = action;
            this.OnDate = date;
            this.PreviousValue = prevValue;
            this.UpdatedValue = updatedValue;
        }
     

    }
}