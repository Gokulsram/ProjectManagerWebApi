using AutoMapper;
using ProjectManagerDataLayer;
using System.Collections.Generic;

namespace ProjectManagerBusinessLayer
{
    public class UserBusiness : IUsersBusiness
    {
         IUsersRepository _userRepository;
        public UserBusiness(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public bool DeleteUser(int intUserId)
        {
            return _userRepository.DeleteUser(intUserId);
        }

        public List<UsersModel> GetAllUsers()
        {
            List<User> user = _userRepository.GetAllUsers();
            List<UsersModel> userModel = Mapper.Map<List<UsersModel>>(user);
            return userModel;
        }

        public UsersModel GetUserById(int intUserId)
        {
            User user = _userRepository.GetUserById(intUserId);
            UsersModel userModel = Mapper.Map<UsersModel>(user);
            return userModel;
        }

        public bool InsertUser(UsersModel user)
        {
            User users = Mapper.Map<User>(user);
            return _userRepository.InsertUser(users);
        }

        public bool UpdateUser(UsersModel user)
        {
            User users = Mapper.Map<User>(user);
            return _userRepository.UpdateUser(users);
        }
    }
}
