using System;
using System.Collections.Generic;
using Business;
namespace Presentation
{
    public class Program 
    {
        enum choice { Register=1,Display,Search };
        public static void Main(string[] args)
        {

            int userChoice, empId, empService, empDetails;
            string empName =string.Empty, empDesignation = string.Empty;
            string[] empList, empDetailsList;
            Controller controller = new Controller();
            while (true)
            {
                Console.WriteLine("\nWelcome to GGk Portal...");
                Console.WriteLine("\nEnter 1.For Registering new employee");
                Console.WriteLine("\nEnter 2.For Displaying all the employees");
                Console.WriteLine("\nEnter 3.For Displaying the details of particular employee");
                Console.WriteLine("\nEnter Your choice....");
                userChoice = int.Parse(Console.ReadLine());

                switch (userChoice)
                {
                    case (int)choice.Register:
                        Console.WriteLine("Enter Employee Id : ");
                        empId = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Employee Name is :");
                        empName = Console.ReadLine();
                        Console.WriteLine("Enter Employee Designation : ");
                        empDesignation = Console.ReadLine();
                        Console.WriteLine("Enter Employee Service/Experience : ");
                        empService = int.Parse(Console.ReadLine());
                        controller.AddEmployee(empId, empName, empDesignation, empService);
                        break;

                    case (int)choice.Display:
                        Console.WriteLine("The Following are the employees of GGK..\n");
                        empList = controller.ShowEmployees();
                        for (int index = 0; index < empList.Length && (empList[index] != null); index++)
                        {
                            Console.WriteLine(empList[index]);
                        }
                        break;
                    case (int)choice.Search:
                        Console.WriteLine("\nEnter the Employee Id to get Employee details..");
                        empDetails = int.Parse(Console.ReadLine());
                        empDetailsList = controller.FindById(empDetails);
                        Console.WriteLine("\nThe Employee Id is : " + empDetailsList[0]);
                        Console.WriteLine("\nThe Employee Name is : " + empDetailsList[1]);
                        Console.WriteLine("\nThe Employee Designation is : " + empDetailsList[2]);
                        Console.WriteLine("\nThe Employee Service/Experience is : " + empDetailsList[3]);
                        break;

                    default:
                        return;
                }
            }
        }
    }
}

