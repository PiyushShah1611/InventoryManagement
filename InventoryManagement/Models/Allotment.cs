using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{
    public class Allotment
    {
        public int AllotmentID { get; set; }
        public int EmployeeID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public int UpdatedBy { get; set; }

        public virtual Item Item { get; set; }
        public virtual Employee Employee { get; set; }
    }
}