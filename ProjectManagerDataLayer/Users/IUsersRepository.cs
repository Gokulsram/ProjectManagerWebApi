using System.Collections.Generic;

namespace ProjectManagerDataLayer
{
    public interface IUsersRepository
    {
        List<User> GetAllUsers();
        User GetUserById(int intUserId);
        bool InsertUser(User user);
        bool UpdateUser(User user);
        bool UpdateUserProjectId(int intProjectId, int intUserId);
        bool UpdateUserTaskId(int intTaskId, int intUserId, int intProjectId);
        bool DeleteUser(int intUserId);
    }
}
