using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{
    public class WithDraw
    {   public int WithDrawID { get; set; }
        public int AllotmentID { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public int UpdatedBy { get; set; }

        public virtual Allotment Allotment { get; set; }

    }
}