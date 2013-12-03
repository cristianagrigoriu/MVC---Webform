using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//using EmployeeMVC.Entities;

namespace EmployeeMVC.Entities
{
    public class Employee
    {
        public String Name { get; set; }
        public long Id { get; set; }
        public String HomeCity { get; set; }
        public String Department { get; set; }
        public String Company { get; set; }
        public Employee Manager { get; set; }

        /*public Employee(String _name, long _id, String _homeCity, String _department, String _company, EmployeeModel _mgr)
        {
            Name = _name;
            Id = _id;
            HomeCity = _homeCity;
            Department = _department;
            Company = _company;
            Manager = _mgr;
        }

        public Employee() { }*/
    }
}