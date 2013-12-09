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
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int Id { get; set; }
        public virtual City HomeCity { get; set; }
        public virtual Department Department { get; set; }
        public virtual Company Company { get; set; }
        public virtual Employee Manager { get; set; }


        public virtual IList<Skill> SkillsList { get; set; }
    }
}