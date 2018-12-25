using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerBusinessLayer
{
    public interface ITaskBusiness
    {
        List<TaskModel> GetAllTasks();
        List<ParentTaskModel> GetParentTask();
        TaskModel GetTaskById(int intTaskId);
        bool AddParentTask(ParentTaskModel parentTaskModel);
        bool InsertTask(TaskModel taskModel);
        bool UpdateTask(TaskModel taskModel);
        bool DeleteTask(int intTaskId);
        bool EndTask(int intTaskId);
    }
}
