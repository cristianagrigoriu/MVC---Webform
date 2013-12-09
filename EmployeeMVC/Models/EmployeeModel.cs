using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EmployeeMVC.Entities;
using EmployeeMVC.EmployeeService;
using System.Web.Mvc;

namespace EmployeeMVC.Models
{
    public class EmployeeModel
    {
        [Required]
        public virtual String Name { get; set; }
        public virtual long Id { get; set; }
        public virtual String HomeCity { get; set; }
        public virtual String Department { get; set; }
        public virtual String Company { get; set; }
        public virtual String ManagerName { get; set; }
        public virtual long ManagerId { get; set; }

        

        /*list to get the elements for the drop down list*/
        //IEnumerable<String> employeeNames = new IEnumerable<String>();

        public virtual List<Employee> ListEmployees { get; set; }


    }
}