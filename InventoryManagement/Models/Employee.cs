using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InventoryManagement.Models
{
    public class Employee
    {   
        public int EmployeeID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public bool Active { get; set; }
        public DateTime UpdateDateTime { get; set; }
        public int UpdatedBy { get; set; }
        public int DepartmentID { get; set; }
        public string RegisterId { get; set; }
        

        public virtual Department Department { get; set; }
        

    }
}