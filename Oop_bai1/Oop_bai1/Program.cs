using System;
using System.Collections.Generic;

namespace Oop_bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>
            {
                new FullTimeEmployee("Alice", 100),
                new FullTimeEmployee("Bob", 120),
                new PartTimeEmployee("Charlie", 80, 20),
                new PartTimeEmployee("Dave", 90, 25)
            };
            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add FullTimeEmployee");
                Console.WriteLine("2. Add PartTimeEmployee");
                Console.WriteLine("3. Display highest salary employees");
                Console.WriteLine("4. Search employee by name");
                Console.WriteLine("5. Exit");
                Console.Write("Your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddFullTimeEmployee(employees);
                        break;
                    case 2:
                        AddPartTimeEmployee(employees);
                        break;
                    case 3:
                        DisplayHighestSalaryEmployees(employees);
                        break;
                    case 4:
                        SearchEmployeeByName(employees);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private static void AddFullTimeEmployee(List<Employee> employees)
        {
            try
            {
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                Console.Write("Enter payment per hour: ");
                int paymentPerHour = int.Parse(Console.ReadLine());
                employees.Add(new FullTimeEmployee(name, paymentPerHour));
                Console.WriteLine("FullTimeEmployee added successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }

        private static void AddPartTimeEmployee(List<Employee> employees)
        {
            try
            {
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                Console.Write("Enter payment per hour: ");
                int paymentPerHour = int.Parse(Console.ReadLine());
                Console.Write("Enter working hours: ");
                int workingHours = int.Parse(Console.ReadLine());

                employees.Add(new PartTimeEmployee(name, paymentPerHour, workingHours));
                Console.WriteLine("PartTimeEmployee added successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }

        private static void DisplayHighestSalaryEmployees(List<Employee> employees)
        {
            FullTimeEmployee highestPaidFullTime = null;
            PartTimeEmployee highestPaidPartTime = null;

            foreach (var employee in employees)
            {
                if (employee is FullTimeEmployee fullTimeEmployee)
                {
                    if (highestPaidFullTime == null || fullTimeEmployee.CalculateSalary() > highestPaidFullTime.CalculateSalary())
                    {
                        highestPaidFullTime = fullTimeEmployee;
                    }
                }
                else if (employee is PartTimeEmployee partTimeEmployee)
                {
                    if (highestPaidPartTime == null || partTimeEmployee.CalculateSalary() > highestPaidPartTime.CalculateSalary())
                    {
                        highestPaidPartTime = partTimeEmployee;
                    }
                }
            }

            Console.WriteLine("Highest salary FullTimeEmployee: " + (highestPaidFullTime != null ? highestPaidFullTime.ToString() : "None"));
            Console.WriteLine("Highest salary PartTimeEmployee: " + (highestPaidPartTime != null ? highestPaidPartTime.ToString() : "None"));
        }

        private static void SearchEmployeeByName(List<Employee> employees)
        {
            Console.Write("Enter name to search: ");
            string name = Console.ReadLine();

            foreach (var employee in employees)
            {
                if (employee.GetName().Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(employee.ToString());
                    return;
                }
            }
            Console.WriteLine("Employee not found.");
        }
    }
}
