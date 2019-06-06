using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        [Required]
        public int ItemID { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public int UpdateBy { get; set; }

        public virtual Item Item { get; set; }

    }
}