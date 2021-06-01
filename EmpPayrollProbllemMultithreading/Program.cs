using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpPayrollProbllemMultithreading
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome To Employee Payroll Problem Using MultiThreading");
            EmployeeRepository repository = new EmployeeRepository();
            repository.DataBaseConnection(); // database connection using the sql connection string

            Console.ReadLine();
        }
    }

}