using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeMVC.Models;
using EmployeeMVC.EmployeeService;
using EmployeeMVC.Entities;

namespace EmployeeMVC.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            var model = new EmployeeModel();

            List<Employee> currentList = HttpContext.Session["list"] as List<Employee>;
            Employee newEmployee = new Employee { Name = model.Name, Id = model.Id, HomeCity = model.HomeCity, Department = model.Department, Company = model.Company, Manager = null };

            currentList.Add(newEmployee);

            ViewBag.ListEmployees = currentList;

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel model)
        {
            List<Employee> currentList = HttpContext.Session["list"] as List<Employee>;
            Employee newEmployee = new Employee{Name = model.Name, Id = model.Id, HomeCity = model.HomeCity, Department = model.Department, Company = model.Company, Manager = null};

            currentList.Add(newEmployee);

            ViewBag.ListEmployees = currentList;

            return RedirectToAction("ViewList");
        }

        public ActionResult ViewList()
        {
            
            //List<EmployeeModel> employees = new List<EmployeeModel>();
            //IEnumerable<EmployeeModel> employees = new List<EmployeeModel>();
            //employees.Add(new EmployeeModel("Ana", 43, "Iasi", "None", "Tolstoi", null));

            EmployeeServices myEmployees = new EmployeeServices();

            List<Employee> list = myEmployees.getAll();
            List<EmployeeModel> listModel = new List<EmployeeModel>();

            foreach (var item in list)
            {
                var empModel = new EmployeeModel();
                empModel.Name = item.Name;
                empModel.Id = item.Id;
                empModel.HomeCity = item.HomeCity;
                empModel.Department = item.Department;
                empModel.Company = item.Company;
                listModel.Add(empModel);
            }

            return View(listModel);
        }

    }
}
