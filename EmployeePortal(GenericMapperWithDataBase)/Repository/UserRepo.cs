using Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using Domain.Models;
using System.Data.SqlClient;
using Domain.StringLiterals;
using System.Data;

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
                Password = x.Password,
                IsStudent = x.IsStudent
            }).ToList();
        }
        /// <summary>
        /// Getting the user details as per the choice of the user.
        /// </summary>
        /// <param name="userRoleChoice"></param>
        /// <returns></returns>
        public List<UserModel> GetUserDetails(UserRoleChoice userRoleChoice)
        {
            SqlDataAdapter adapter;
            DataRow[] result;
            DataSet dataSet;
            DataTable userTable;
            using (SqlConnection connection = new SqlConnection(StringLiterals._connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    switch ((int)userRoleChoice)
                    {

                        case 1:
                            adapter = new SqlDataAdapter("SELECT * FROM USERINFO WHERE IsStudent='true'", connection);
                            dataSet = new DataSet();
                            adapter.Fill(dataSet, "User");
                            userTable = dataSet.Tables["User"];
                            result = userTable.Select();  
                            ConvertToList(result);
                            _usersList.Clear();
                            break;
                        case 2:
                            adapter = new SqlDataAdapter("SELECT * FROM USERINFO WHERE IsStudent='false'", connection);
                            dataSet = new DataSet();
                            adapter.Fill(dataSet, "User");
                            userTable = dataSet.Tables["User"];
                            result = userTable.Select();
                            ConvertToList(result);
                            _usersList.Clear();
                            break;
                        case 3:
                            adapter = new SqlDataAdapter("SELECT * FROM USERINFO", connection);
                            dataSet = new DataSet();
                            adapter.Fill(dataSet, "User");
                            userTable = dataSet.Tables["User"];
                            result = userTable.Select();
                            ConvertToList(result);
                            _usersList.Clear();
                            break;
                    }
                }
            }
            return _usersList;
        }
        /// <summary>
        /// this is used to insert data into list. 
        /// </summary>
        /// <param name="result"></param>
        private void ConvertToList(DataRow[] result)
        {
            foreach (DataRow row in result)
            {
                _usersList.Add(new UserModel { EmailAddress = row[3].ToString(), FirstName = row[1].ToString(), LastName = row[2].ToString() });
            }
        }
    }
}