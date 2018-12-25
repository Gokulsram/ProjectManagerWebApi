using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerDataLayer
{
   public interface ITaskRepository
    {
        List<usp_GetAllTasks_Result> GetAllTasks();
        List<ParentTask> GetParentTask();
        Task GetTaskById(int intTaskId);
        int InsertTask(Task task);
        int InsertParentTask(ParentTask task);
        int UpdateTask(Task task);
        bool DeleteTask(int intTaskId);
        bool EndTask(int intTaskId);
    }
}
