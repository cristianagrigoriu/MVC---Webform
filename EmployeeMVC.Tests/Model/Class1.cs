using EmployeeMVC.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeMVC.Tests
{
    [TestFixture]
    public class AddEmployee
    {
        [Test]
        public void AddOneEmployee() 
        {
            //arrange
            City newCity = new City { Id = 1, Name = "Hamburg" };
            Company newComp = new Company { Id = 1, City = newCity,  Name = "Beatles"};
            Department newDept = new Department { Id = 1, Company =  newComp, Name = "Guitar", Manager = null};

            List<Employee> employees= new List<Employee>();
            var initialCount = employees.Count();


            //act
            employees.Add(new Employee { 
                FirstName = "John", 
                LastName = "Lennon", 
                Id = 1, 
                HomeCity = newCity, 
                Department = newDept, 
                Company = newComp, 
                Manager = null });

            var finalCount = employees.Count;

            //assert
            Assert.AreEqual(initialCount + 1, finalCount);
        }


    }
}
