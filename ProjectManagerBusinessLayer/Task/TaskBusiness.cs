using AutoMapper;
using ProjectManagerDataLayer;
using System.Collections.Generic;

namespace ProjectManagerBusinessLayer
{
    public class TaskBusiness : ITaskBusiness
    {
        ITaskRepository _taskRepository;
        IUsersRepository _usersRepository;

        public TaskBusiness(ITaskRepository taskRepository, IUsersRepository usersRepository)
        {
            _taskRepository = taskRepository;
            _usersRepository = usersRepository;
        }

        public bool AddParentTask(ParentTaskModel parentTaskModel)
        {
            ParentTask task = Mapper.Map<ParentTask>(parentTaskModel);
            ParentTask parentTask = Mapper.Map<ParentTask>(parentTaskModel);
            _taskRepository.InsertParentTask(parentTask);
            return true;
        }

        public bool DeleteTask(int intTaskId)
        {
            return _taskRepository.DeleteTask(intTaskId);
        }

        public List<TaskModel> GetAllTasks()
        {
            List<usp_GetAllTasks_Result> task = _taskRepository.GetAllTasks();
            List<TaskModel> taskModel = Mapper.Map<List<TaskModel>>(task);
            return taskModel;
        }

        public List<ParentTaskModel> GetParentTask()
        {
            List<ParentTask> task = _taskRepository.GetParentTask();
            List<ParentTaskModel> taskModel = Mapper.Map<List<ParentTaskModel>>(task);
            return taskModel;
        }

        public TaskModel GetTaskById(int intTaskId)
        {
            usp_GetAllTasks_Result task = _taskRepository.GetAllTasks().Find(p => p.Task_ID == intTaskId);
            TaskModel taskModel = Mapper.Map<TaskModel>(task);
            return taskModel;
        }

        public bool InsertTask(TaskModel taskModel)
        {
            Task task = Mapper.Map<Task>(taskModel);
            int intTaskId = _taskRepository.InsertTask(task);

            if (taskModel.UserId > 0 && intTaskId > 0)
            {
                return _usersRepository.UpdateUserTaskId(intTaskId, taskModel.UserId);
            }
            return true;
        }
        public bool EndTask(int intTaskId)
        {
            return _taskRepository.EndTask(intTaskId);
        }
        public bool UpdateTask(TaskModel taskModel)
        {
            Task task = Mapper.Map<Task>(taskModel);
            int intTaskId = _taskRepository.UpdateTask(task);
            if (taskModel.UserId > 0 && intTaskId > 0)
            {
                return _usersRepository.UpdateUserTaskId(intTaskId, taskModel.UserId);
            }
            return true;
        }
    }
}
