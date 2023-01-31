using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CompanyDepartmentProject
{
    
    public class Department 
    {
        public string Name { get; set; }

        public Department(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object? obj)
        {
            Department temp = obj as  Department;

            if (temp == null)
                return false;
            return Name == temp.Name;
        }

        public static bool operator ==(Department a, Department b)
        {
            return a.Name == b.Name;
        }

        public static bool operator !=(Department a, Department b)
        {
            return a.Name != b.Name;
        }
    }
}
