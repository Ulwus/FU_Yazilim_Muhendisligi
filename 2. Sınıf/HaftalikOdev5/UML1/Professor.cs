using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaftalikOdev5.UML1
{
    public class Professor : Person
    {
        public int Salary { get; set; }
        private int StaffNumber { get; set; }
        protected int YearsOfService { get; set; }
        public int NumberOfClasses { get; set; }
        public List<Student> SupervisedStudents { get; set; } = new List<Student>();
    }
}
