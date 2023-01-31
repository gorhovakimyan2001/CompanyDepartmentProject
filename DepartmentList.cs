using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDepartmentProject
{
    internal class DepartmentList: IEnumerator<Department>
    {
        private List<Department> list;
        
        public string path = "departments.txt";

        public DepartmentList()
        {
            list = new List<Department>();
        }

        public Department Current => throw new NotImplementedException();

        object IEnumerator.Current => throw new NotImplementedException();

        public void add(Department d)
        {
            if (d is null)
                throw new ArgumentException("Wrong argument");
            list.Add(d);
        }

        public bool contains(Department d)
        {
            foreach (Department dp in list)
            {
                if (d == dp)
                    return true;
            }

            return false;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public Department remove(Department d)
        {
            foreach (Department dep in list)
            {
                if (d == dep)
                {
                    list.Remove(d);
                    return dep;
                }
            }

            return null;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Department> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public bool saveToFile()
        {
            try
            {
                using (StreamWriter stw = new StreamWriter("departments.txt"))

                    foreach (Department d in list)
                        stw.WriteLine(d);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void loadFromFile()
        {
            list.Clear();

            using(StreamReader str = new StreamReader("departments.txt"))
            {
                string line;

                while((line = str.ReadLine()) != null)
                {
                    Department d = new Department(line);
                    list.Add(d);
                }
            }
        }

        public bool exist()
        {
            return File.Exists(path);
        }
    }
}
