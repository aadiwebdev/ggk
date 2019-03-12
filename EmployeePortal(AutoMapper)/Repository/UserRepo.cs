using Domain.Enums;
using Domain.Interfaces;
using Domain.StringLiterals;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class UserRepo
    {
        /// <summary>
        /// Retrieve User details from the repository
        /// </summary>
        /// <param name="userRoleChoice"></param>
        /// <returns></returns>
        public List<Model> GetUserDetails(UserRoleChoice userRoleChoice)
        {
            List<Model> usersList=null;
            switch ((int)userRoleChoice)
            {
                case (int)UserRoleChoice.User :
                        usersList = (List<Model>)DataSource._userList.Where(m => m.IsStudent==StringLiterals._yes).ToList<Model>();
                         break;
                case (int)UserRoleChoice.Other :
                        usersList = (List<Model>)DataSource._userList.Where(m => m.IsStudent==StringLiterals._no).ToList<Model>();
                    break;
                case (int)UserRoleChoice.All:
                    usersList = DataSource._userList;
                    break;
            }
            return usersList;
        }
    }
}
