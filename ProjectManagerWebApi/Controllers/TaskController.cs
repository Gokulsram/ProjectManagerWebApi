using ProjectManagerBusinessLayer;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Routing;

namespace ProjectManagerWebApi
{
    public class TaskController : ApiController
    {
        ITaskBusiness _taskBusiness;

        public TaskController(ITaskBusiness taskBusiness)
        {
            _taskBusiness = taskBusiness;
        }

        [Route("api/GetAllTask")]
        public IEnumerable<TaskModel> Get()
        {
            return _taskBusiness.GetAllTasks();
        }

        [Route("api/GetParentTask")]
        public IEnumerable<ParentTaskModel> GetParentTask()
        {
            return _taskBusiness.GetParentTask();
        }


        [Route("api/GetTaskById")]
        public TaskModel Get(int intTasktId)
        {
            return _taskBusiness.GetTaskById(intTasktId);
        }

        [Route("api/AddTask")]
        public bool Post([FromBody]TaskModel taskModel)
        {
            return _taskBusiness.InsertTask(taskModel);
        }

        [Route("api/AddParentTask")]
        public bool Post([FromBody]ParentTaskModel taskModel)
        {
            return _taskBusiness.AddParentTask(taskModel);
        }

        [Route("api/EditTask")]
        public bool Put([FromBody]TaskModel taskModel)
        {
            return _taskBusiness.UpdateTask(taskModel);
        }

        [Route("api/EndTask")]
        public bool EndTask(int intTaskId)
        {
            return _taskBusiness.EndTask(intTaskId);
        }

        [Route("api/DeleteTask")]
        public bool Delete(int intTaskId)
        {
            return _taskBusiness.DeleteTask(intTaskId);
        }
    }
}
