using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using EmpPayrollProbllemMultithreading;

namespace EmpPayrollProblem_MultiThreadingMSTest
{
    // TC1 :- To test for addition of multiple data to the list without using the multi-thread
    [TestClass]
    public class UnitTest1
    {
        // Creating an instance of the employee payroll class  so as to invoke the adding methods for records.
        public static EmployeeModel employeemodel = new EmployeeModel();
        public static EmployeeRepository employeeRepository = new EmployeeRepository();

        [TestMethod]
        public void GivenListOfEmployeesWhenAddedToList_ShouldMatchTheEntriesWithoutThreading()
        {
            //Arrange
            List<EmployeeModel> employeeList = new List<EmployeeModel>();
            employeeList.Add(new EmployeeModel(employeeName: "Himanshu", startDate: new System.DateTime(2019, 08, 01), phoneNumber: 4567876543, address: "Bangalore", department: "HR", gender: "M", basicPay: 50000, deductions: 2000, taxablePay: 48000, tax: 1000, netPay: 47000));
            employeeList.Add(new EmployeeModel(employeeName: "Omprakash", startDate: new System.DateTime(2020, 01, 01), phoneNumber: 4563784678, address: "Chennai", department: "HR", gender: "M", basicPay: 50000, deductions: 2000, taxablePay: 48000, tax: 1000, netPay: 47000));
            employeeList.Add(new EmployeeModel(employeeName: "Priyesh", startDate: new System.DateTime(2020, 02, 01), phoneNumber: 7865678765, address: "Mumbai", department: "Sales", gender: "M", basicPay: 60000, deductions: 2000, taxablePay: 58000, tax: 1000, netPay: 57000));
            employeeList.Add(new EmployeeModel(employeeName: "Chandan", startDate: new System.DateTime(2019, 02, 01), phoneNumber: 3456765434, address: "Delhi", department: "Marketing", gender: "M", basicPay: 60000, deductions: 2000, taxablePay: 58000, tax: 1000, netPay: 57000));
            employeeList.Add(new EmployeeModel(employeeName: "Ekta", startDate: new System.DateTime(2020, 04, 12), phoneNumber: 4567898754, address: "Bangalore", department: "Sales", gender: "F", basicPay: 60000, deductions: 2000, taxablePay: 58000, tax: 1000, netPay: 57000));
            bool expected = true;
            Stopwatch stopwatch = new Stopwatch();

            //Act
            stopwatch.Start();
            bool actual = employeemodel.AddEmployeeListToDataBase(employeeList);
            stopwatch.Stop();
            Console.WriteLine("Elapsed time: " + stopwatch.ElapsedMilliseconds);

            //Assert
            Assert.AreEqual(expected, actual);
        }
        // TC2:- To test for addition of multiple data to the list using the multi-threading concept
        [TestMethod]
        public void GivenEmployeeList_AddEmployeeListToDatabaseUsingThreads()
        {
            //Arrange
            List<EmployeeModel> employeeList = new List<EmployeeModel>();
            employeeList.Add(new EmployeeModel(employeeName: "Himanshu", startDate: new System.DateTime(2019, 08, 01), phoneNumber: 4567876543, address: "Bangalore", department: "HR", gender: "M", basicPay: 50000, deductions: 2000, taxablePay: 48000, tax: 1000, netPay: 47000));
            employeeList.Add(new EmployeeModel(employeeName: "Omprakash", startDate: new System.DateTime(2020, 01, 01), phoneNumber: 4563784678, address: "Chennai", department: "HR", gender: "M", basicPay: 50000, deductions: 2000, taxablePay: 48000, tax: 1000, netPay: 47000));
            employeeList.Add(new EmployeeModel(employeeName: "Priyesh", startDate: new System.DateTime(2020, 02, 01), phoneNumber: 7865678765, address: "Mumbai", department: "Sales", gender: "M", basicPay: 60000, deductions: 2000, taxablePay: 58000, tax: 1000, netPay: 57000));
            employeeList.Add(new EmployeeModel(employeeName: "Chandan", startDate: new System.DateTime(2019, 02, 01), phoneNumber: 3456765434, address: "Delhi", department: "Marketing", gender: "M", basicPay: 60000, deductions: 2000, taxablePay: 58000, tax: 1000, netPay: 57000));
            employeeList.Add(new EmployeeModel(employeeName: "Ekta", startDate: new System.DateTime(2020, 04, 12), phoneNumber: 4567898754, address: "Bangalore", department: "Sales", gender: "F", basicPay: 60000, deductions: 2000, taxablePay: 58000, tax: 1000, netPay: 57000));
            Stopwatch stopwatch = new Stopwatch();

            //Act
            stopwatch.Start();
            employeeRepository.AddEmployeeListToEmployeePayrollDataBaseWithThread(employeeList);
            stopwatch.Stop();
            Console.WriteLine("Elapsed time using the threads: " + stopwatch.ElapsedMilliseconds);
        }

        // TC3:- To test for addition of multiple data to the list using the multi-threading concept with thread synchronization

        [TestMethod]
        public void AddingMultipleDataWithSynchronizedThreads_GettingTimeOfExecution()
        {
            //Arrange
            List<EmployeeModel> employeeList = new List<EmployeeModel>();
            employeeList.Add(new EmployeeModel(employeeName: "Himanshu", startDate: new System.DateTime(2019, 08, 01), phoneNumber: 4567876543, address: "Bangalore", department: "HR", gender: "M", basicPay: 50000, deductions: 2000, taxablePay: 48000, tax: 1000, netPay: 47000));
            employeeList.Add(new EmployeeModel(employeeName: "Omprakash", startDate: new System.DateTime(2020, 01, 01), phoneNumber: 4563784678, address: "Chennai", department: "HR", gender: "M", basicPay: 50000, deductions: 2000, taxablePay: 48000, tax: 1000, netPay: 47000));
            employeeList.Add(new EmployeeModel(employeeName: "Priyesh", startDate: new System.DateTime(2020, 02, 01), phoneNumber: 7865678765, address: "Mumbai", department: "Sales", gender: "M", basicPay: 60000, deductions: 2000, taxablePay: 58000, tax: 1000, netPay: 57000));
            employeeList.Add(new EmployeeModel(employeeName: "Chandan", startDate: new System.DateTime(2019, 02, 01), phoneNumber: 3456765434, address: "Delhi", department: "Marketing", gender: "M", basicPay: 60000, deductions: 2000, taxablePay: 58000, tax: 1000, netPay: 57000));
            employeeList.Add(new EmployeeModel(employeeName: "Ekta", startDate: new System.DateTime(2020, 04, 12), phoneNumber: 4567898754, address: "Bangalore", department: "Sales", gender: "F", basicPay: 60000, deductions: 2000, taxablePay: 58000, tax: 1000, netPay: 57000));
            Stopwatch stopwatch = new Stopwatch();

            //Act
            stopwatch.Start();
            employeeRepository.AddEmployeeListToDataBaseWithThreadSynchronization(employeeList);
            stopwatch.Stop();
            Console.WriteLine("Elapsed time using the threads: " + stopwatch.ElapsedMilliseconds);
        }
    }

}