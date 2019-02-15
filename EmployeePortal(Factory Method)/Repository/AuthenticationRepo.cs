using Domain;
using Domain.Enums;
using Domain.Interfaces;
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
        public string ValidateLogin(Model loginModel)
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
        public string RegisterUser(Model registrationModel)
        {
            if (!DataSource._userList.Any(m => m.EmailAddress == registrationModel.EmailAddress))
            {
                Model model = ModelFactory.getModel(ModelSelection.User);
                {
                    model.FirstName = registrationModel.FirstName;
                    model.LastName = registrationModel.LastName;
                    model.EmailAddress = registrationModel.EmailAddress;
                    model.Password = registrationModel.Password;
                    model.ConfirmPassword = registrationModel.ConfirmPassword;
                    model.IsStudent = registrationModel.IsStudent;
                }
                DataSource._userList.Add(model);
                return StringLiterals._success;
            }
            return StringLiterals._registrationFailed;
        }
    }
}
