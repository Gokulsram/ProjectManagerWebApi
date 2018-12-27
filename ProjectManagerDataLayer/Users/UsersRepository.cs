using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;

namespace ProjectManagerDataLayer
{
    public class UsersRepository : IUsersRepository
    {
        private ProjectManagerEntities _dbProjectManager;
        private static SqlProviderServices instance = SqlProviderServices.Instance;

        public UsersRepository()
        {
            _dbProjectManager = new ProjectManagerEntities();
        }
        public bool DeleteUser(int intUserId)
        {
            try
            {
                User user = _dbProjectManager.Users.Where(a => a.User_ID == intUserId).FirstOrDefault();
                _dbProjectManager.Users.Remove(user);
                _dbProjectManager.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            try
            {
                users = _dbProjectManager.Users.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return users;
        }

        public User GetUserById(int intUserId)
        {
            User user = new User();
            try
            {
                user = _dbProjectManager.Users.Where(a => a.User_ID == intUserId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return user;
        }

        public bool InsertUser(User user)
        {
            try
            {
                _dbProjectManager.Users.Add(user);
                _dbProjectManager.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateUser(User user)
        {
            try
            {
                User userUpdate = _dbProjectManager.Users.Where(a => a.User_ID == user.User_ID).FirstOrDefault();
                userUpdate.FirstName = user.FirstName;
                userUpdate.LastName = user.LastName;
                userUpdate.Employee_ID = user.Employee_ID;
                userUpdate.Task_ID = user.Task_ID;
                userUpdate.Project_ID = user.Project_ID;
                _dbProjectManager.Entry(userUpdate).State = System.Data.Entity.EntityState.Modified;
                _dbProjectManager.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateUserProjectId(int intProjectId, int intUserId)
        {
            try
            {
                User userUpdate = _dbProjectManager.Users.Where(a => a.Project_ID == intProjectId).FirstOrDefault();
                if (userUpdate != null)
                {
                    userUpdate.Project_ID = null;
                    _dbProjectManager.Entry(userUpdate).State = System.Data.Entity.EntityState.Modified;
                    _dbProjectManager.SaveChanges();
                }
                userUpdate = _dbProjectManager.Users.Where(a => a.User_ID == intUserId).FirstOrDefault();
                userUpdate.Project_ID = intProjectId;
                _dbProjectManager.Entry(userUpdate).State = System.Data.Entity.EntityState.Modified;
                _dbProjectManager.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UpdateUserTaskId(int intTaskId, int intUserId, int intProjectId)
        {
            try
            {
                User userUpdate = _dbProjectManager.Users.Where(a => a.Project_ID == intProjectId).FirstOrDefault();
                if (userUpdate != null)
                {
                    userUpdate.Task_ID = null;
                    _dbProjectManager.Entry(userUpdate).State = System.Data.Entity.EntityState.Modified;
                    _dbProjectManager.SaveChanges();
                }
                userUpdate = _dbProjectManager.Users.Where(a => a.Task_ID == intTaskId).FirstOrDefault();
                if (userUpdate != null)
                {
                    userUpdate.Task_ID = null;
                    _dbProjectManager.Entry(userUpdate).State = System.Data.Entity.EntityState.Modified;
                    _dbProjectManager.SaveChanges();
                }
                userUpdate = _dbProjectManager.Users.Where(a => a.User_ID == intUserId).FirstOrDefault();
                userUpdate.Task_ID = intTaskId;
                _dbProjectManager.Entry(userUpdate).State = System.Data.Entity.EntityState.Modified;
                _dbProjectManager.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
