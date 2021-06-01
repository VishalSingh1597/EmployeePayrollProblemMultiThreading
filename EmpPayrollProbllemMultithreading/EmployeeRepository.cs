using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EmpPayrollProbllemMultithreading

{
    public class EmployeeRepository
    {  //UC:- Ability to create a payroll service database and have C# program connect to database.
 

        public static string connectionString = @"Data Source=LAPTOP-FNHEQJH9;Initial Catalog=payroll-Service;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; //Specifying the connection string from the sql server connection.


        SqlConnection connection = new SqlConnection(connectionString); // Establishing the connection using the Sqlconnection.  

        public bool DataBaseConnection()
        {
            try
            {
                connection.Open(); // open connection
                using (connection)  //using SqlConnection
                {
                    Console.WriteLine($"Connection is created Successful "); //print msg

                }
                connection.Close(); //close connection
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return true;
        }
        // UC1:- Ability to add multiple employee to payroll DB.

        public bool AddEmployeeListToDataBase(List<EmployeeModel> employeeList)
        {
            foreach (var employee in employeeList)
            {
                Console.WriteLine("Employeee being added :", employee.EmployeeName);
                bool flag = AddEmployeeToDataBase(employee);
                Console.WriteLine("Employee Added :", employee.EmployeeName);
                if (flag == false)
                    return false;
            }
            return true;
        }



        //UC2:- Ability to add multiple employee to payroll DB using Threads so as to get a better response
         

        public void AddEmployeeListToEmployeePayrollDataBaseWithThread(List<EmployeeModel> employeelList)
        {

            employeelList.ForEach(employeeData => //For each employeeData present in list new thread is created and all threads run according to the time slot assigned by the thread scheduler.
            {
                Task thread = new Task(() =>
                {
                    Console.WriteLine("Employee Being added" + employeeData.EmployeeName); // Printing the current thread id being utilised
                    Console.WriteLine("Current thread id: " + Thread.CurrentThread.ManagedThreadId); // Calling the method to add the data to the address book database
                    this.AddEmployeeToDataBase(employeeData);
                    Console.WriteLine("Employee added:" + employeeData.EmployeeName); // Indicating mesasage to end of data addition
                });
                thread.Start();
            });
        }
        public bool AddEmployeeToDataBase(EmployeeModel model)
        {
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("dbo.SqlProcedureName", this.connection);   //Creating a stored Procedure for adding employees into database

                    command.CommandType = CommandType.StoredProcedure; //Command type is a class to set as stored procedure
                                                                       // Adding values from employeemodel to stored procedure 

                    command.Parameters.AddWithValue("@EmployeeName", model.EmployeeName);
                    command.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                    command.Parameters.AddWithValue("@Address", model.Address);
                    command.Parameters.AddWithValue("@Department", model.Department);
                    command.Parameters.AddWithValue("@Gender", model.Gender);
                    command.Parameters.AddWithValue("@BasicPay", model.BasicPay);
                    command.Parameters.AddWithValue("@Deductions", model.Deductions);
                    command.Parameters.AddWithValue("@TaxablePay", model.TaxablePay);
                    command.Parameters.AddWithValue("@Tax", model.Tax);
                    command.Parameters.AddWithValue("@NetPay", model.NetPay);
                    command.Parameters.AddWithValue("@StartDate", model.StartDate);
                    command.Parameters.AddWithValue("@City", model.City);
                    command.Parameters.AddWithValue("@Country", model.Country);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();

                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connection.Close();
            }

        }

    }
}