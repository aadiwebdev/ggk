using System;
using System.Collections.Generic;
 using BusinessLayer;
namespace Presentation
{
    public  class Program
    {
       public static void Main(string [] args)
        {

            int choice,empId,empService,empDetails;
            string empName, empDesignation;
            string [] empList,empDetailsList;
            Controller controller = new Controller();
            while(true)
            {
                  Console.WriteLine("Welcome to GGk Portal...");
                  Console.WriteLine("Enter 1.For Registering new employee");
                  Console.WriteLine("Enter 2.For Displaying all the employees");
                  Console.WriteLine("Enter 3.For Displaying the details of particular employee");
           Console.WriteLine("Enter Your choice....");
                  choice = int.Parse(Console.ReadLine());
          
            switch (choice)
            {
                case 1 :
                    Console.WriteLine("Enter Employee Id : ");
                    empId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter Employee Name is :");
                    empName = Console.ReadLine();
                    Console.WriteLine("Enter Employee Designation : ");
                    empDesignation = Console.ReadLine();
                    Console.WriteLine("Enter Employee Service/Experience : ");
                    empService = int.Parse(Console.ReadLine());
                    controller.AddEmployee(empId,empName,empDesignation,empService);
                    break;

                case 2:
                    Console.WriteLine("The Following are the employees of GGK..");
                    empList = controller.ShowEmployees();
                    for(int index=0;index<empList.Length && empList[index]!=null;index++)
                    {
                        Console.WriteLine(empList[index]);
                    }
                    break;
                case 3:
                   Console.WriteLine("Enter the Employee Id to get Employee details..");
                    empDetails =int.Parse(Console.ReadLine());
                    empDetailsList = controller.FindById(empDetails);
                    Console.WriteLine("The Employee Id is : "+empDetailsList[0]);
                    Console.WriteLine("The Employee Name is : "+empDetailsList[1]);
                    Console.WriteLine("The Employee Designation is : "+empDetailsList[2]);
                    Console.WriteLine("The Employee Service/Experience is : "+empDetailsList[3]);
                    break;
            default:
                           return ;    
            }
        }
        }
    }
}

