using Domain;
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
            LoginModel loginModel;
            RegistrationModel registrationModel;
            Menu menu = new Menu(); ;
             string firstName, lastName, emailAddress, password, confirmPassword,userLoginEmail,userLoginPassword;
             string isStudent,message=string.Empty;
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
                        Console.WriteLine("\nEnter Email address..\n");
                        userLoginEmail = Console.ReadLine();
                        Console.WriteLine("\nEnter Password..\n");
                        userLoginPassword = menu.GetPassword().ToPlainString();
                        loginModel = new LoginModel(userLoginEmail, userLoginPassword);
                        message = menu.ValidateLogin(loginModel);
                        if (!message.Equals(StringLiterals._success))
                        {
                            Console.WriteLine(message);
                        }
                        else
                        {
                            Console.WriteLine(StringLiterals._loginSuccess);
                        }
                        break;
                    case (int)UserSelectionChoice.Register:
                        Console.WriteLine("\nEnter First Name");
                        firstName = Console.ReadLine();
                        Console.WriteLine("\nEnter Last Name");
                        lastName = Console.ReadLine();
                        Console.WriteLine("\nEnter Email Address");
                        emailAddress = Console.ReadLine();
                        Console.WriteLine("\nEnter Password");
                        password = menu.GetPassword().ToPlainString();
                        Console.WriteLine("\nEnter ConfirmPassword");
                        confirmPassword = menu.GetPassword().ToPlainString();
                        Console.WriteLine("\nAre you a Student or Not.");
                        isStudent = Console.ReadLine().ToLower();
                        registrationModel = new RegistrationModel(firstName,lastName,emailAddress,password,confirmPassword,isStudent);
                        message = menu.RegisterUser(registrationModel);
                        if (!message.Equals(StringLiterals._success))
                        {
                            Console.WriteLine(message);
                        }
                        else
                        {
                            Console.WriteLine(StringLiterals._registrationSuccess);
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