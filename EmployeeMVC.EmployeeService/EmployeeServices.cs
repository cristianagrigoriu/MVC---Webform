using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeMVC.Entities;

namespace EmployeeMVC.EmployeeService
{
    public class EmployeeServices
    {
        private List<Employee> employees;

        public EmployeeServices()
        {
            employees = new List<Employee>();
        }

        public void createEmployees()
        {
            employees.Add(new Employee {Name = "John Lennon", Id = 1, HomeCity = "Hamburg", Department = "Guitar", Company = "Beatles", Manager = null});
            employees.Add(new Employee{Name = "Paul McCartney", Id = 2, HomeCity = "Hamburg", Department = "Bass", Company = "Beatles", Manager = employees[0]});
            employees.Add(new Employee{Name = "Ringo Starr", Id = 3, HomeCity = "Liverpool", Department = "Drums", Company = "Beatles", Manager = null});
            employees.Add(new Employee{Name = "George Harrison", Id = 4, HomeCity = "Seattle", Department = "Guitar", Company = "Beatles", Manager = null});
            employees.Add(new Employee { Name = "NULL", Id = 0, HomeCity = "", Department = "", Company = "", Manager = null });
        }

        public List<Employee> getAll()
        {
            createEmployees();
            if (HttpContext.Current.Session["list"] == null)
            {
                HttpContext.Current.Session["list"] = employees;
            }
            return HttpContext.Current.Session["list"] as List<Employee>;
        }

        /*public IEnumerable<SelectListItem> getEmployeeNames()
        {
            IEnumerable<SelectList> selectList = SelectList();
        }*/
    }
}