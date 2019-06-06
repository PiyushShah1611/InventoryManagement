using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool Active { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public int UpdatedBy { get; set; }

        public virtual ICollection<Item> Items { get; set; }
    }
}