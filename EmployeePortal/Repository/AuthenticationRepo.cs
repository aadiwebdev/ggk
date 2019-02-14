using Domain.Models;
using Domain.StringLiterals;
using System;
using System.Linq;

namespace Repository
{
    public class AuthenticationRepo
    {
        /// <summary>
        /// It is used to validate login
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public string ValidateLogin(LoginModel loginModel)
        {
            if (DataSource._userList.Any(m => m.EmailAddress == loginModel.EmailAddress && m.Password == loginModel.Password))
            {
                return StringLiterals._success;
            }
            return StringLiterals._loginFailed;
        }
        /// <summary>
        /// It is used to register user.
        /// </summary>
        /// <param name="registrationModel"></param>
        /// <returns></returns>
        public string RegisterUser(RegistrationModel registrationModel)
        {
            if (!DataSource._userList.Any(m => m.EmailAddress == registrationModel.EmailAddress))
            {
                UserModel userModel = new UserModel()
                {
                    FirstName = registrationModel.FirstName,
                    LastName = registrationModel.LastName,
                    EmailAddress = registrationModel.EmailAddress,
                    Password = registrationModel.Password,
                    ConfirmPassword = registrationModel.ConfirmPassword,
                    IsStudent = registrationModel.IsStudent
                };
                DataSource._userList.Add(userModel);
                return StringLiterals._success;
            }
            return StringLiterals._registrationFailed;
        }
    }
}
