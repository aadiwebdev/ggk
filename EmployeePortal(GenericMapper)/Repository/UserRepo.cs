using Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using Domain.Models;


namespace Repository
{
    public class UserRepo
    {
        private static List<UserModel> _usersList = new List<UserModel>();
        public UserRepo()
        {
            _usersList = DataSource._userList.Select(x => new UserModel()
                                                     {
                                                       FirstName = x.FirstName,
                                                       LastName = x.LastName,
                                                       EmailAddress = x.EmailAddress,
                                                       Password =x.Password,
                                                       IsStudent =x.IsStudent
                                                     }).ToList();
        }
        public List<UserModel> GetUserDetails(UserRoleChoice userRoleChoice)
        {
            switch ((int)userRoleChoice)
            {
                case 1:
                    _usersList = (List<UserModel>)DataSource._userList.Where(m => m.IsStudent == "true");
                    break;
                case 2:
                    _usersList = (List<UserModel>)DataSource._userList.Where(m => m.IsStudent == "false");
                    break;
            }
            return _usersList;
        }
    }
}