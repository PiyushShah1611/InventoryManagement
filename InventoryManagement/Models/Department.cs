using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public int UpdatedBy { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}