using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDepartmentProject
{
    internal class EmployeeList: IEnumerator<Employee>
    {
        private List<Employee> eList;

        public string path = "employees.txt";

        public Employee Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public EmployeeList()
        {
            eList = new List<Employee>();
        }

        public void add(Employee e)
        {
            if (e == null)
                throw new ArgumentException("Wrong argument");
            eList.Add(e);
        }

        public Employee remove (Employee e)
        {
            foreach (Employee employee in eList)
            {
                if (e == employee)
                {
                    eList.Remove(e);
                    return employee;
                } 
            }

            return null;
        }

        public Employee findEmployeeByID(int id)
        {
            foreach (Employee employee in eList)
            {
                if (employee.ID == id)
                    return employee;
            }
            return null;
        }

        public int size() { return eList.Count; }

        public Employee this[int index]
        { 
            get { return eList[index]; }

            set { eList[index] = value; }
        }

        public int GreatestID()
        {
            if(eList.Count == 0)
                return 999;
            else
                return eList[eList.Count - 1].ID;
        }

        public IEnumerator<Employee> GetEnumerator()
        {
            return eList.GetEnumerator();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool saveToFile()
        {
            try
            {
                using (StreamWriter stw = new StreamWriter("employees.txt"))

                    foreach (Employee d in eList)
                        stw.WriteLine(d.makeString());
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void loadFromFile()
        {
            eList.Clear();

            using (StreamReader str = new StreamReader("employees.txt"))
            {
                string line;

                while ((line = str.ReadLine()) != null)
                {
                    Employee e = Employee.Parse(line);
                    eList.Add(e);
                }
            }
        }
    }
}
