using System;
using System.Collections.Generic;

#nullable disable

namespace BankWebAPI.DataModel
{
    public partial class Employee
    {
        public Employee()
        {
            InverseMgr = new HashSet<Employee>();
        }

        public int Eid { get; set; }
        public string Empname { get; set; }
        public double? Salary { get; set; }
        public DateTime? Doj { get; set; }
        public string City { get; set; }
        public int? Deptid { get; set; }
        public int? Mgrid { get; set; }

        public virtual Student Dept { get; set; }
        public virtual Employee Mgr { get; set; }
        public virtual ICollection<Employee> InverseMgr { get; set; }
    }
}
