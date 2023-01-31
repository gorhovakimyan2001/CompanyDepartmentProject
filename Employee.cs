using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDepartmentProject
{
    internal class Employee
    {
        public String Name { get; set; }
        public String Surname { get; set; }
        public Department Departament { get; set; }
        public int ID { get; }

        public EmployeeList list;

        public Employee() : this("", "", null, null) { }
        
        public Employee(string name, String surname, Department dep, EmployeeList l)
        {
            list = l;
            Name = name;
            Surname = surname;
            Departament = dep;
            ID = l.GreatestID() + 1;
        }

        public Employee(string name, string surname, Department departament, int id)
        {
            Name = name;
            Surname = surname;
            Departament = departament;
            ID = id;
        }

        public override string ToString()
        {
            return "Name: " + Name +
                Environment.NewLine + "Surname: " + Surname + 
                Environment.NewLine + "ID: " + ID +
                Environment.NewLine + "Department: " + Departament;
        }

        public string makeString()
        {
            return Name + " " + Surname + " " + Departament + " " + ID;
        }

        public static Employee Parse(string s)
        {
            string[] arr = s.Split(" ");
            string name = arr[0];
            string surname = arr[1];
            Department d = new Department(arr[2]);
            int id = int.Parse(arr[4]);

            return new Employee(name, surname, d, id);
            
        }

        public override bool Equals(object? obj)
        {
            Employee e = obj as Employee;

            if (e is null)
                return false;

            return Name == e.Name && Surname == e.Surname && Departament == e.Departament && this.ID == e.ID ;
        }
        public static bool operator == (Employee e1, Employee e2)
        {
            if (e1 is null || e2 is null)
                return false;
            return e1.Name == e2.Name && e1.Surname == e2.Surname && e1.Departament == e2.Departament && e1.ID == e2.ID;  
        }

        public static bool operator != (Employee e1, Employee e2)
        {
            if (e1 is null || e2 is null)
                return false;
            return e1.Name != e2.Name || e1.Surname != e2.Surname || e1.Departament != e2.Departament || e1.ID != e2.ID;
        }

    }
}
