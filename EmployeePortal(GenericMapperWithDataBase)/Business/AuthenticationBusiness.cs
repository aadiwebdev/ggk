﻿using Domain.Models;
using Domain.StringLiterals;
using Repository;


namespace Business
{
    public class AuthenticationBusiness
    {
        AuthenticationRepo authRepo;
        public AuthenticationBusiness()
        {
            authRepo = new AuthenticationRepo();

        }
        /// <summary>
        /// It is used to validate user credencials
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        public string ValidateLogin(LoginModel loginModel)
        {
            if (Validations.ValidateEmailAddress(loginModel.EmailAddress).Equals(StringLiterals._success))
            {
                if (Validations.ValidatePassword(loginModel.Password).Equals(StringLiterals._success))
                {
                    return authRepo.ValidateLogin(loginModel).ToString();
                }
                return Validations.ValidatePassword(loginModel.Password);
            }
            return Validations.ValidateEmailAddress(loginModel.EmailAddress);
        }
        /// <summary>
        /// It is used to register the user
        /// </summary>
        /// <param name="registrationModel"></param>
        /// <returns></returns>
        public string RegisterUser(RegistrationModel registrationModel)
        {
            if (Validations.ValidateEmailAddress(registrationModel.EmailAddress).Equals(StringLiterals._success))
            {
                if (Validations.ValidatePassword(registrationModel.Password).Equals(StringLiterals._success))
                {
                    return authRepo.RegisterUser(registrationModel).ToString();
                }
                return Validations.ValidatePassword(registrationModel.Password);
            }
            return Validations.ValidateEmailAddress(registrationModel.EmailAddress);

        }
    }
}
