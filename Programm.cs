using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VHODNO
{
    class Program
    {
        static void Main(string[] args)
        {
            //Reads current employees from a txt file
            List<Employee> employees = new List<Employee>();
            using (StreamReader sr = new StreamReader("Users.txt"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] token = line.Split().ToArray();
                    Employee employee = new Employee();
                    employee.FirstName = token[0];
                    employee.MiddleName = token[1];
                    employee.LastName = token[2];
                    employee.Address = token[3];
                    employee.WorkNumber = int.Parse(token[4]);
                    employee.Salary = double.Parse(token[5]);

                    employees.Add(employee);
                }
            }

            Console.WriteLine("Welcome!");
        TryAgain:
            Console.Write("What user are you (Standard/Admin)? ");
            string user = Console.ReadLine();
            Console.WriteLine();


            if (user == "Standard")
            {
                Console.WriteLine("Available commands: ");
                Console.WriteLine("1. View users");
                Console.WriteLine("2. Sort users");
                Console.WriteLine("3. Exit");
                Console.WriteLine();
                Console.Write("What would you like to do ? ");
                int command = int.Parse(Console.ReadLine());
                Console.WriteLine();

                while (command != 3)
                {
                    if (command == 1)
                    {
                        ViewUsersStandard(employees);
                    }
                    else if (command == 2)
                    {
                        Console.WriteLine("1. First Name");
                        Console.WriteLine("2. Last Name");
                        Console.WriteLine("3. Address");
                        Console.WriteLine("4. Salary");
                    Negga:
                        Console.Write("Sort by ");
                        string option = Console.ReadLine();

                        if (option == "First Name")
                        {
                            employees = employees.OrderBy(f => f.FirstName).ToList();
                        }
                        else if (option == "Last Name")
                        {
                            employees = employees.OrderBy(l => l.LastName).ToList();
                        }
                        else if (option == "Address")
                        {
                            employees = employees.OrderBy(a => a.Address).ToList();
                        }
                        else if (option == "Salary")
                        {
                            employees = employees.OrderBy(s => s.Salary).ToList();
                        }
                        else
                        {
                            Console.WriteLine("Wrong option. Please try again.");
                            goto Negga;
                        }
                    }
                    else if (command == 3)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong command. Please try again. ");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Available commands: ");
                    Console.WriteLine("1. View users");
                    Console.WriteLine("2. Sort users");
                    Console.WriteLine("3. Exit");
                    Console.WriteLine();
                    Console.Write("What would you like to do next? ");
                    command = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                }
            }
            else if (user == "Admin")
            {
                Console.WriteLine("Available commands: ");
                Console.WriteLine("1. Add users");
                Console.WriteLine("2. Remove users");
                Console.WriteLine("3. View users");
                Console.WriteLine("4. Sort users");
                Console.WriteLine("5. Exit");
                Console.WriteLine();
                Console.Write("What would you like to do ? ");
                int command = int.Parse(Console.ReadLine());
                Console.WriteLine();

                while (command != 5)
                {
                    if (command == 1)
                    {
                        AddUsers(employees);
                    }
                    else if (command == 2)
                    {
                        RemoveUsers(employees);
                    }
                    else if (command == 3)
                    {
                        ViewUsersAdmin(employees);
                    }
                    else if (command == 4)
                    {
                        Console.WriteLine("1. First Name");
                        Console.WriteLine("2. Last Name");
                        Console.WriteLine("3. Address");
                        Console.WriteLine("4. Salary");
                        Negga:
                        Console.Write("Sort by ");
                        string option = Console.ReadLine();

                        if(option == "First Name")
                        {
                            employees = employees.OrderBy(f => f.FirstName).ToList();
                        } 
                        else if(option == "Last Name")
                        {
                            employees = employees.OrderBy(l => l.LastName).ToList();
                        }
                        else if(option == "Address")
                        {
                            employees = employees.OrderBy(a => a.Address).ToList();
                        }
                        else if(option == "Salary")
                        {
                            employees = employees.OrderBy(s => s.Salary).ToList();
                        }
                        else
                        {
                            Console.WriteLine("Wrong option. Please try again.");
                            goto Negga;
                        }
                    }
                    else if (command == 5)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong command. Please try again. ");
                        goto Nigga;
                    }
                    Nigga:
                    Console.WriteLine();
                    Console.WriteLine("Available commands: ?");
                    Console.WriteLine("1. Add users");
                    Console.WriteLine("2. Remove users");
                    Console.WriteLine("3. View users");
                    Console.WriteLine("4. Sort users");
                    Console.WriteLine("5. Exit");
                    Console.WriteLine();
                    Console.Write("What would you like to do next? ");
                    command = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Non existent user. Please try again.");
                Console.WriteLine();
                goto TryAgain;
            }
        }

        static void AddUsers(List<Employee> employees)
        {
            Console.Write("How many users would you like to add? ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();
            for (int i = 1; i <= n; i++)
            {
                Employee employee = new Employee();
                Console.WriteLine($"Please enter information about your {i} employee (Name/Middle Name/Last Name/Address/Work Number/Salary)");
                string[] employeeReader = Console.ReadLine().Split('/').ToArray();
                Console.WriteLine();

                employee.FirstName = employeeReader[0];
                employee.MiddleName = employeeReader[1];
                employee.LastName = employeeReader[2];
                employee.Address = employeeReader[3];
                employee.WorkNumber = int.Parse(employeeReader[4]);
                employee.Salary = double.Parse(employeeReader[5]);

                employees.Add(employee);

                using (StreamWriter users = new StreamWriter("Users.txt", true))
                {
                     users.WriteLine($"{employee.FirstName} {employee.MiddleName} {employee.LastName} {employee.Address} {employee.WorkNumber} {employee.Salary}");
                }
            }

            Console.WriteLine("Users successfully added!");
            Console.WriteLine();
        }
        static void RemoveUsers(List<Employee> employees)
        {
            Console.WriteLine("Current Users: ");
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.PrintEmployeeAdmin());
            }
            Console.WriteLine();

            Console.Write("How many users would you like to remove? ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Please enter information about the {i} employee you would like to fire.");
                string employeeToFire = Console.ReadLine();

                string[] readText = File.ReadAllLines("Users.txt");
                File.WriteAllText("Users.txt", String.Empty);

                using (StreamWriter sw = new StreamWriter("Users.txt", true))
                {
                    foreach (var line in readText)
                    {
                        if (!line.Equals(employeeToFire))
                        {
                            sw.WriteLine(line);
                        }
                    }
                }
            }

            employees.Clear();
            using (StreamReader sr = new StreamReader("Users.txt"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] token = line.Split().ToArray();
                    Employee employee = new Employee();
                    employee.FirstName = token[0];
                    employee.MiddleName = token[1];
                    employee.LastName = token[2];
                    employee.Address = token[3];
                    employee.WorkNumber = int.Parse(token[4]);
                    employee.Salary = double.Parse(token[5]);

                    employees.Add(employee);
                }
            }
        }
        static void ViewUsersAdmin(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.PrintEmployeeAdmin());
            }
        }
        static void ViewUsersStandard(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                Console.WriteLine(employee.PrintEmployeeStandard());
            }
        }
    }
}