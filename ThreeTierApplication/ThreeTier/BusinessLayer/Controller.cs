using System;
using System.Collections.Generic;
using DataAccessLayer; 

namespace BusinessLayer
{
    public class Controller
    {
        /// <summary>
        /// adding employee to database.
        /// </summary>
        /// <param name="empId"></param>
        /// <param name="empName"></param>
        /// <param name="empDesignation"></param>
        /// <param name="empService"></param>
        public void AddEmployee(int empId,string empName,string empDesignation,int empService)
        {
            Employee emp = new Employee(empId,empName,empDesignation,empService);
            Data.Save(emp);
        }
        /// <summary>
        /// Retrieving employees from database
        /// </summary>
        /// <returns></returns>
        public string [] ShowEmployees()
        {
            string [] employeeString = new string[1000];
            List<Employee> employeeList =Data.Fetch();
            for(int index =0;index<employeeList.Count;index++)
                    {
                       employeeString[index]=employeeList[index].EmployeeName;                    
                    }
            return employeeString ;
        }
        /// <summary>
        /// Finding employee through employee Id
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public string [] FindById(int empId)
        {
            string [] employeeDetails = new string[5];
             Employee employeeItem =Data.FindById(empId);
                       employeeDetails[0]=employeeItem.EmployeeId.ToString();
                       employeeDetails[1]=employeeItem.EmployeeName;                    
                       employeeDetails[2]=employeeItem.EmployeeDesignation;                    
                       employeeDetails[3]=employeeItem.EmployeeService.ToString();                  
            return employeeDetails;
        }
        
        public static void Main()
        {
         Console.WriteLine("liii");
        } 
    }
}
        

