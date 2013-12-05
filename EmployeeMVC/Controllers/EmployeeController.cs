using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeMVC.Models;
using PagedList;
using EmployeeMVC.EmployeeService;
using EmployeeMVC.Entities;

namespace EmployeeMVC.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/

        private EmployeeServices empService = new EmployeeServices();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            List<Employee> currentEmpList = empService.getAll();

            empService.getAllFromDB();

            //ViewBag.ListEmployees = currentEmpList;
            var model = new EmployeeModel();
            model.ListEmployees = currentEmpList;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel model)
        {
            List<Employee> currentEmpList = empService.getAll();

            Employee newEmployee = new Employee { Name = model.Name, Id = currentEmpList.Max(x => x.Id) + 1, HomeCity = model.HomeCity, Department = model.Department, Company = model.Company, Manager = currentEmpList.Find(x => x.Id == model.ManagerId) };

            currentEmpList.Add(newEmployee);

            model.ListEmployees = currentEmpList;

            return RedirectToAction("ViewList");
        }

        public ActionResult ViewList(int? page)
        {
            //List<Employee> currentEmpList = empService.getAll();
            List<EmployeeModel> listModel = new List<EmployeeModel>();

            List<Employee> currentEmpList = empService.getAllFromDB();

            /*Employee to EmployeeModel*/
            foreach (var item in currentEmpList)
            {
                if (item.Id != 0)
                {
                    var empModel = new EmployeeModel();
                    empModel.Name = item.Name;
                    empModel.Id = item.Id;
                    empModel.HomeCity = item.HomeCity;
                    empModel.Department = item.Department;
                    empModel.Company = item.Company;

                    /*we check if the employee has a manager and if its manager still exists in the list (we may have deleted it in the meantime)*/
                    if (item.Manager != null && currentEmpList.Find(x => x.Id == item.Manager.Id) != null)
                    {
                        long mgrId = item.Manager.Id;
                        Employee mgr = currentEmpList.Find(x => x.Id == mgrId);
                        empModel.ManagerName = mgr.Name;
                        empModel.ManagerId = mgr.Id;
                    }
                    listModel.Add(empModel);
                }
            }

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            return View(listModel.ToPagedList(pageNumber, pageSize));

            //return View(listModel);
        }

        public ActionResult Edit(long id)
        {
            List<Employee> currentEmpList = empService.getAll();
            
            Employee selectedEmployee = currentEmpList.Find(x => x.Id == id);

            var model = new EmployeeModel();
            model.ListEmployees = currentEmpList;

            /*to display current data on the selected employee*/
            model.Name = selectedEmployee.Name;
            model.HomeCity = selectedEmployee.HomeCity;
            model.Department = selectedEmployee.Department;
            model.Company = selectedEmployee.Company;
            if (selectedEmployee.Manager != null)
            {
                model.ManagerName = selectedEmployee.Manager.Name;
                model.ManagerId = selectedEmployee.Manager.Id;
            }
            return View(model);
    
        }

        [HttpPost]
        public ActionResult Edit(EmployeeModel model)
        {
            List<Employee> currentEmpList = empService.getAll();

            /*the old version of the contact*/
            Employee selectedEmployee = currentEmpList.Find(x => x.Id == model.Id);

            selectedEmployee.Name = model.Name;
            selectedEmployee.HomeCity = model.HomeCity;
            selectedEmployee.Department = model.HomeCity;
            selectedEmployee.Company = model.Company;
            if (model.ManagerId != 0)
            {
                Employee newManager = new Employee();
                selectedEmployee.Manager = newManager;
                selectedEmployee.Manager.Id = model.ManagerId;
            }
            else
            {
                selectedEmployee.Manager = null;
            }

            return RedirectToAction("ViewList");
        }

        public ActionResult Delete(long id)
        {
            List<Employee> currentEmpList = empService.getAll();

            Employee selectedEmployee = currentEmpList.Find(x => x.Id == id);

            currentEmpList.Remove(selectedEmployee);

            return RedirectToAction("ViewList");
        }

    }
}
