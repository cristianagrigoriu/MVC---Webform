using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeMVC.Entities;
using System.Data.SqlClient;
using SessionFactoryHelper;
using NHibernate;
using NHibernate.Linq;

namespace EmployeeMVC.EmployeeService
{
    public class EmployeeServices
    {
        //private List<Employee> employees;

        //public EmployeeServices()
        //{
        //    employees = new List<Employee>();
        //}

        ///*public void createEmployees()
        //{
        //    employees.Add(new Employee {FirstName = "John", LastName =  "Lennon", Id = 1, HomeCity = "Hamburg", Department = "Guitar", Company = "Beatles", Manager = null});
        //    employees.Add(new Employee{Name = "Paul McCartney", Id = 2, HomeCity = "Hamburg", Department = "Bass", Company = "Beatles", Manager = employees[0]});
        //    employees.Add(new Employee{Name = "Ringo Starr", Id = 3, HomeCity = "Liverpool", Department = "Drums", Company = "Beatles", Manager = null});
        //    employees.Add(new Employee{Name = "George Harrison", Id = 4, HomeCity = "Seattle", Department = "Guitar", Company = "Beatles", Manager = null});
        //    employees.Add(new Employee {Name = "NULL", Id = 0, HomeCity = "", Department = "", Company = "", Manager = null});
        //}*/

        public List<Employee> getAllNHibernate()
        {
            using (ISession Session = NHibernateHelper.OpenSession())
            {
                return Session.Query<Employee>().ToList();
            }
        }

        //public List<Employee> getAllFromDB()
        //{
        //    /*instantiate the connection*/
        //    SqlConnection conn = new SqlConnection("Data Source=HP\\Cristioara;Initial Catalog=MyEmployees;Integrated Security=SSPI");
            
        //    SqlDataReader rdr = null;

        //    List<int> mgrId = new List<int>();

        //     try
        //    {
        //        /*open the connection*/
        //        conn.Open();

        //        /*get result of stored procedure*/
        //        SqlCommand cmd = new SqlCommand("GetEmployees", conn);

        //        /*use the connection*/
        //        /*get query results*/
        //        rdr = cmd.ExecuteReader();

        //        while (rdr.Read())
        //        {
        //            //Console.WriteLine(rdr["name"]);
        //            var newEmployee = new Employee();
        //            newEmployee.Name = (String)rdr["name"];
        //            newEmployee.Id = (int)rdr["emp_id"];
        //            newEmployee.HomeCity = (String)rdr["city_name"];
        //            newEmployee.Department = (String)rdr["dept_name"];
        //            newEmployee.Company = rdr["comp_name"] == DBNull.Value ? "NULL" : (String)(rdr["comp_name"]);

        //            newEmployee.Manager = null;
        //            int mgr_id = rdr["mgr_id"] == DBNull.Value ? 0 : (int)(rdr["mgr_id"]);

        //            mgrId.Add(mgr_id);

        //            employees.Add(newEmployee);
        //        }
        //    }
        //    finally
        //    {
        //        // close the reader
        //        if (rdr != null)
        //        {
        //            rdr.Close();
        //        }

        //        /*close the connection*/
        //        if (conn != null)
        //        {
        //            conn.Close();
        //        }
        //    }

        //    /*set the managers for each employee*/
        //    for (int count = 0; count < employees.Count; count ++) {
        //        employees.ElementAt(count).Manager = employees.Find(x => x.Id == mgrId.ElementAt(count)) ?? null;
        //    }

        //     return employees;
        //}

        ///*public List<Employee> getAll()
        //{
        //    //createEmployees();
        //    if (HttpContext.Current.Session["list"] == null)
        //    {
        //        HttpContext.Current.Session["list"] = employees;
        //    }
        //    return HttpContext.Current.Session["list"] as List<Employee>;
        //}*/

        ///*public IEnumerable<SelectListItem> getEmployeeNames()
        //{
        //    IEnumerable<SelectList> selectList = SelectList();
        //}*/
    }
}