using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace CRUD_Test.Model
{
    public class EmployeeJson
    {
        public int id { get; set; }
        public string employee_name { get; set; }
        public string employee_salary { get; set; }
        public string employee_age { get; set; }
        public string profile_image { get; set; }
    }
}
