using System;
using System.Collections.Generic;

#nullable disable

namespace BankWebAPI.DataModel
{
    public partial class Student
    {
        public Student()
        {
            Employees = new HashSet<Employee>();
        }

        public int Did { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
