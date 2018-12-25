using System.Collections.Generic;

namespace ProjectManagerBusinessLayer
{
    public interface IUsersBusiness
    {
        List<UsersModel> GetAllUsers();
        UsersModel GetUserById(int intUserId);
        bool InsertUser(UsersModel user);
        bool UpdateUser(UsersModel user);        
        bool DeleteUser(int intUserId);

    }
}
