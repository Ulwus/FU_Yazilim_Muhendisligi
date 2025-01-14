using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaftalikOdev5.UML1
{
    public class Student : Person
    {
        public int StudentNumber { get; set; }
        public int AverageMark { get; set; }

        public bool IsEligibleToEnroll(string course)
        {
            // Implementation
            return true;
        }

        public int GetSeminarsTaken()
        {
            // Implementation
            return 0;
        }
    }
}
