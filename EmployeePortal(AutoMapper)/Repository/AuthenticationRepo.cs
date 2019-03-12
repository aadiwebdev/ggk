using Domain.Interfaces;
using Domain.StringLiterals;
using System.Linq;
using AutoMapper;
using Domain.Models;

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
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<RegistrationModel, UserModel>();
            });
            IMapper mapper = config.CreateMapper();
            if (!DataSource._userList.Any(m => m.EmailAddress == registrationModel.EmailAddress))
            {
                    Model model = mapper.Map<Model,Model>(registrationModel);   
                    DataSource._userList.Add(model);
                    return StringLiterals._success;
            }
            return StringLiterals._registrationFailed;
        }
    }
}