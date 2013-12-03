using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EmployeeMVC.Entities;
using EmployeeMVC.EmployeeService;

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
        public EmployeeModel Manager { get; set; }

    }
}