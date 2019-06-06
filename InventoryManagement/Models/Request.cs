using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{
    public class Request
    {
        public int RequestID { get; set; }
        [Required]
        public int EmployeeID { get; set; }
        [Required]
        public int ItemID { get; set; }
        [Required]
        public int Quantity { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public int UpdatedBy { get; set; }

        public virtual Item Item { get; set; }
        public virtual Employee Employee { get; set; }
    }
}