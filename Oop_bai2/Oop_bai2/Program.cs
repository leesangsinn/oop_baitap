using Oop_bai2;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Oop_bai2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> list = new List<Person>();
            list.Add(new Customer("abc", "VN", 1000));
            list.Add(new Customer("bcd", "VN", 1300));
            list.Add(new Customer("sasasa", "VN", 1500));

            list.Add(new Employee("Ronaldo", "VN", 1200));
            list.Add(new Employee("Messi", "VN", 1700));
            list.Add(new Employee("KDB", "VN", 1900));

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Display highest salary customer and lowest salary employee");
                Console.WriteLine("3. Find person by name");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid option, please try again.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddEmployee(list);
                        break;
                    case 2:
                        DisplayHighestSalaryAndLowestBalance(list);
                        break;
                    case 3:
                        FindPersonByName(list);
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
            //Console.ReadLine();
        }

        // Hàm này tìm khách hàng có số dư cao nhất và nhân viên có lương thấp nhất.
        // Sau đó hiển thị thông tin của họ.
        public static void DisplayHighestSalaryAndLowestBalance(List<Person> list)
        {
            var maxBalanceCustomer = list.OfType<Customer>().OrderByDescending(c => c.Balance).FirstOrDefault();
            var minSalaryEmployee = list.OfType<Employee>().OrderBy(e => e.Salary).FirstOrDefault();

            if (maxBalanceCustomer != null)
            {
                maxBalanceCustomer.Display();
            }
            else
            {
                Console.WriteLine("No customers found.");
            }

            if (minSalaryEmployee != null)
            {
                minSalaryEmployee.Display();
            }
            else
            {
                Console.WriteLine("No employees found.");
            }
        }

        // Hàm này tìm kiếm một người theo tên và hiển thị thông tin của họ nếu tìm thấy.
        public static void FindPersonByName(List<Person> list)
        {
            Console.Write("Enter Person Name: ");
            var name = Console.ReadLine();

            foreach (var person in list)
            {
                if (person.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    person.Display();
                    return;
                }
            }
            Console.WriteLine("Person not found!");
        }

        // Hàm này cho phép người dùng thêm một nhân viên hoặc khách hàng mới vào danh sách.
        public static void AddEmployee(List<Person> list)
        {
            string type;
            Console.Write("Enter type (emp for Employee, cus for Customer): ");
            type = Console.ReadLine();

            while (type != "emp" && type != "cus")
            {
                Console.Write("Enter type (emp for Employee, cus for Customer): ");
                type = Console.ReadLine();
            }

            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            int salary = 0;
            int balance = 0;
            string address;

            try
            {
                Console.Write("Enter address: ");
                address = Console.ReadLine();

                if (type == "emp")
                {
                    Console.Write("Enter salary: ");
                    salary = int.Parse(Console.ReadLine());
                }
                else
                {
                    Console.Write("Enter balance: ");
                    balance = int.Parse(Console.ReadLine());
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid input, please try again.");
                return;
            }

            if (type == "cus")
            {
                list.Add(new Customer(name, address, balance));
            }
            else if (type == "emp")
            {
                list.Add(new Employee(name, address, salary));
            }
            else
            {
                Console.WriteLine("Invalid type.");
            }
            Console.WriteLine("Person added successfully.");
        }
    }
}
