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
        public String Name { get; set; }
        public long Id { get; set; }
        public String HomeCity { get; set; }
        public String Department { get; set; }
        public String Company { get; set; }
        public String ManagerName { get; set; }
        public long ManagerId { get; set; }

        /*list to get the elements for the drop down list*/
        //IEnumerable<String> employeeNames = new IEnumerable<String>();

        public List<Employee> ListEmployees { get; set; }


    }
}