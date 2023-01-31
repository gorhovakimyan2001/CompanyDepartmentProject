using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDepartmentProject
{
    internal static class ExtentionShow
    {
        public static void showEmployee(this EmployeeList list)
        {
            foreach (Employee e in list)
            {
                Console.WriteLine(e); 
                Console.WriteLine();
            }
        }

        public static void showDepartment(this DepartmentList list)
        {
            int i = 1;
            Console.WriteLine("Departments:");
            Console.WriteLine();
            foreach (Department d in list)
            {
                Console.WriteLine($"{i}. " + d);
                i++;
            }
        }

    }
}
