using Domain.Enums;
using Domain.Models;
using Domain.StringLiterals;
using System;
using System.Collections.Generic;

namespace ConApp
{
public class  Program
{

        public static void Main()
        {
            RegistrationModel registrationModel = null;
            LoginModel loginModel = null;
            Menu menu = new Menu();
            string message=string.Empty;

            while (true)
            {
                Console.WriteLine("\nWelcome to GGK Technologies!!!!!!!!!!");
                Console.WriteLine("\n1.User Login\n");
                Console.WriteLine("\n2.User Registration\n");
                Console.WriteLine("\n3.Get User Details\n");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case (int)UserSelectionChoice.Login :
                                                            loginModel = menu.ReadLoginData();
                                                            message = menu.ValidateLogin(loginModel);
                                                            if (!message.Equals(StringLiterals._success))
                                                              {
                                                                 Console.WriteLine("\n"+message);
                                                               }
                                                            else
                                                              {
                                                                Console.WriteLine("\n" + StringLiterals._loginSuccess);
                                                              }
                                                            break;
                    case (int)UserSelectionChoice.Register:

                                                             registrationModel = menu.ReadRegisterData();
                                                             message = menu.RegisterUser(registrationModel);
                                                             if (!message.Equals(StringLiterals._success))
                                                              {
                                                                 Console.WriteLine("\n" + message);
                                                              }
                                                             else
                                                              { 
                                                                 Console.WriteLine("\n" + StringLiterals._registrationSuccess);
                                                              }
                                                             break;

                  case (int)UserSelectionChoice.GetUserDetails:

                                                             Console.WriteLine("\nEnter Choice 1 =>Users 2=>Others 3=>All");
                                                             int userChoice = int.Parse(Console.ReadLine());
                                                             List<UserModel> usersList = menu.DisplayUsers((UserRoleChoice)userChoice);
                                                             foreach(var users in usersList)
                                                              {
                                                                Console.WriteLine("\nThe employee name is :" + users.FirstName + users.LastName);
                                                                Console.WriteLine("\nThe Employee email address is :" + users.EmailAddress);
                                                              }
                                                             break;
                }
            }
        } 
}


}