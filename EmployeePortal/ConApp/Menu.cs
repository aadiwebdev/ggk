using Business;
using Domain.Enums;
using Domain.Models;
using Domain.StringLiterals;
using System;
using System.Collections.Generic;
using System.Security;


namespace ConApp
{
    class Menu
    {
        UserBusiness userBusiness;
        public Menu()
        {
            authBusiness = new AuthenticationBusiness();
            userBusiness = new UserBusiness();
        }
        AuthenticationBusiness authBusiness;

        /// <summary>
        /// For displaying user details
        /// </summary>
        /// <param name="userRoleChoice"></param>
        /// <returns></returns>
        public List<UserModel> DisplayUsers(UserRoleChoice userRoleChoice)
        {
            return userBusiness.GetUserDetails(userRoleChoice);
        }
        /// <summary>
        /// It is used to register user
        /// </summary>
        /// <param name="registrationModel"></param>
        /// <returns></returns>
        public string RegisterUser(RegistrationModel registrationModel)
        {
            if (authBusiness.RegisterUser(registrationModel).Equals(StringLiterals._success))
            {
                return StringLiterals._success;
            }
            return authBusiness.RegisterUser(registrationModel);
        }
        ./// <summary>
        ///It is used to validate the user credentails
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public string ValidateLogin(LoginModel loginModel)
        {
            if (authBusiness.ValidateLogin(loginModel).Equals(StringLiterals._success))
            {
                return StringLiterals._success;
            }
            return authBusiness.ValidateLogin(loginModel);
        }
        /// <summary>
        /// It is used to mask the password at console
        /// </summary>
        /// <returns></returns>
        public SecureString GetPassword()
        {
            var pwd = new SecureString();
            while (true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length > 0)
                    {
                        pwd.RemoveAt(pwd.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else if (i.KeyChar != '\u0000') // KeyChar == '\u0000' if the key pressed does not correspond to a printable character, e.g. F1, Pause-Break, etc
                {
                    pwd.AppendChar(i.KeyChar);
                    Console.Write("*");
                }
            }
            return pwd;
        }

    }
}
