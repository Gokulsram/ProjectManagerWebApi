using ProjectManagerBusinessLayer;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Routing;

namespace ProjectManagerWebApi
{
    
    public class UsersController : ApiController
    {
        IUsersBusiness _usersBusiness;
        public UsersController(IUsersBusiness usersBusiness)
        {
            _usersBusiness = usersBusiness;
        }
    
        [Route("api/GetAllUsers")]
        public IEnumerable<UsersModel> Get()
        {
            return _usersBusiness.GetAllUsers();
        }

        [Route("api/GetUserById")]
        public UsersModel Get(int intUserId)
        {
            return _usersBusiness.GetUserById(intUserId);
        }

        [Route("api/AddUser")]
        public bool Post([FromBody]UsersModel user)
        {
            return _usersBusiness.InsertUser(user);
        }

        [Route("api/EditUser")]
        public bool Put([FromBody]UsersModel user)
        {
            return _usersBusiness.UpdateUser(user);
        }

        [Route("api/DeleteUser")]
        public bool Delete(int intUserId)
        {
            return _usersBusiness.DeleteUser(intUserId);
        }

    }
}
