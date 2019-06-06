using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int SupplierID { get; set; }
        [Required]
        public int ReOrderLabel { get; set; }
        public bool Active { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public int UpdatedBy { get; set; }

        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }

    }
}