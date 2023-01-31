using System;
using System.Net.Http.Headers;
using System.IO;

namespace CompanyDepartmentProject
{
    internal class Program
    {
        static void Main(string[] args)
        {

            EmployeeList employeesList = new EmployeeList();
            DepartmentList departments = new DepartmentList();
            bool closeFlag = true;
            Console.WriteLine(departments.exist());
            departments.loadFromFile();
            employeesList.loadFromFile();

            do
            {
            goToMenu:
                foreach (Menu item in Enum.GetValues<Menu>())
                {
                    Console.WriteLine($"{(int)item} {item}");
                }

                Console.WriteLine();
                string menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":

                        Console.Write("Name -> ");
                        string name = Console.ReadLine();

                        Console.Write("Surname -> ");
                        string surname = Console.ReadLine();

                        Console.Write("Department -> ");
                        string department = Console.ReadLine();
                        Department dp = new Department(department);

                        Console.WriteLine();

                        Console.Write("Save? Yes or No: ");
                        String aproveToAdd = Console.ReadLine();
                        Console.WriteLine();

                        if (aproveToAdd.ToLower() == "yes")
                        {
                            Employee e = new Employee(name, surname, dp, employeesList);
                            employeesList.add(e);

                            if (!departments.contains(dp))
                                departments.add(dp);
                        }
                        break;

                    case "2":

                    newID:
                        int id;
                        do
                        {
                            Console.Write("Enter ID number -> ");
                        }
                        while (!int.TryParse(Console.ReadLine(), out id));

                        Employee re = employeesList.findEmployeeByID(id);

                        if (re == null)
                        {
                            Console.WriteLine("Wrong ID number!!!");
                            Console.WriteLine();
                            Console.Write("Try again press 1 ----- go to Menu press any key: ");
                            Console.WriteLine();

                            string again = Console.ReadLine();

                            if (again == "1")
                            {
                                goto newID;
                            }
                            else
                                goto goToMenu;
                        }
                        else
                            Console.WriteLine(re);
                        employeesList.remove(re);
                        Console.WriteLine();

                        break;
                    case "3":

                        foreach (FindMneu item in Enum.GetValues<FindMneu>())
                        {
                            Console.WriteLine($"{(int)item} {item}");
                        }
                        Console.WriteLine();

                        string findMenuChoice = Console.ReadLine();

                        switch (findMenuChoice)
                        {
                            case "1":
                                int findID;
                                do
                                {
                                    Console.Write("Enter ID number -> ");
                                }
                                while (!int.TryParse(Console.ReadLine(), out findID));

                                Employee temp1 = employeesList.findEmployeeByID(findID);

                                if (temp1 == null)
                                    Console.WriteLine("Wrong ID number!!!");
                                else
                                    Console.WriteLine(temp1);
                                Console.WriteLine();

                                break;
                            case "2":

                                string findName = Console.ReadLine();
                                bool flagName = false;
                                Console.WriteLine();

                                foreach (Employee e in employeesList)
                                {
                                    if (e.Name.ToLower() == findName.ToLower())
                                    {
                                        flagName = true;
                                        Console.WriteLine(e);
                                        Console.WriteLine();
                                    }

                                    Console.WriteLine();
                                }
                                if (flagName == false)
                                    Console.WriteLine("Wrong Name!!!");
                                Console.WriteLine();

                                break;
                            case "3":

                                string findSurname = Console.ReadLine();
                                bool flagSurname = false;
                                Console.WriteLine();

                                foreach (Employee e in employeesList)
                                {
                                    if (e.Surname.ToLower() == findSurname.ToLower())
                                    {
                                        Console.WriteLine(e);
                                        Console.WriteLine();
                                        flagSurname = true;

                                    }

                                }
                                if (flagSurname == false)
                                    Console.WriteLine("Wrong Surname!!!");

                                Console.WriteLine();
                                break;
                            case "4":
                                string findDepartment = Console.ReadLine();
                                bool flagDepartment = false;
                                Console.WriteLine();

                                foreach (Employee e in employeesList)
                                {
                                    if (e.Departament.Name.ToLower() == findDepartment.ToLower())
                                    {
                                        flagDepartment = true;
                                        Console.WriteLine(e);
                                        Console.WriteLine();
                                    }

                                    Console.WriteLine();
                                }
                                if (flagDepartment == false)
                                    Console.WriteLine("We don't have Department with that name!!!");
                                Console.WriteLine();
                                break;
                            default:
                                Console.WriteLine("Wrong input!!!");
                                break;
                        }
                        break;
                    case "4":
                        employeesList.showEmployee();
                        Console.WriteLine();
                        break;
                    case "5":
                        departments.showDepartment();
                        Console.WriteLine();
                        break;
                    case "6":
                        closeFlag = false;
                        departments.saveToFile();
                        employeesList.saveToFile();
                        break;
                    default:
                        break;

                }

            } while (closeFlag);
        }
    }
}