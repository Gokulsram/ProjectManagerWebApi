using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerDataLayer
{
    public class TaskRepository : ITaskRepository
    {
        private ProjectManagerEntities _dbTaskManager;
        private static SqlProviderServices instance = SqlProviderServices.Instance;
        private const string STATUS = "Completed";
        public TaskRepository()
        {
            _dbTaskManager = new ProjectManagerEntities();
        }

        public bool DeleteTask(int intTaskId)
        {
            try
            {
                Task task = _dbTaskManager.Tasks.Where(a => a.Task_ID == intTaskId).FirstOrDefault();
                if (task != null)
                {
                    _dbTaskManager.Tasks.Remove(task);
                    _dbTaskManager.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EndTask(int intTaskId)
        {
            try
            {
                Task task = _dbTaskManager.Tasks.Where(a => a.Task_ID == intTaskId).FirstOrDefault();
                if (task != null)
                {
                    task.Status = STATUS;
                    _dbTaskManager.Entry(task).State = System.Data.Entity.EntityState.Modified;
                    _dbTaskManager.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<usp_GetAllTasks_Result> GetAllTasks()
        {
            List<usp_GetAllTasks_Result> task = new List<usp_GetAllTasks_Result>();
            try
            {
                task = _dbTaskManager.usp_GetAllTasks().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return task;
        }

        public Task GetTaskById(int intTaskId)
        {
            Task project = new Task();
            try
            {
                project = _dbTaskManager.Tasks.Where(a => a.Task_ID == intTaskId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return project;
        }

        public int InsertTask(Task task)
        {
            try
            {
                _dbTaskManager.Tasks.Add(task);
                _dbTaskManager.SaveChanges();
                return task.Task_ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int InsertParentTask(ParentTask task)
        {
            try
            {
                _dbTaskManager.ParentTasks.Add(task);
                _dbTaskManager.SaveChanges();
                return task.Parent_ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateTask(Task task)
        {
            try
            {
                Task taskUpdate = _dbTaskManager.Tasks.Where(a => a.Task_ID == task.Task_ID).FirstOrDefault();
                if (taskUpdate != null)
                {
                    taskUpdate.Parent_ID = task.Parent_ID;
                    taskUpdate.Project_ID = task.Project_ID;
                    taskUpdate.Task1 = task.Task1;
                    taskUpdate.Start_Date = task.Start_Date;
                    taskUpdate.End_Date = task.End_Date;
                    taskUpdate.Priority = task.Priority;
                    taskUpdate.Status = task.Status;
                    _dbTaskManager.Entry(taskUpdate).State = System.Data.Entity.EntityState.Modified;
                    _dbTaskManager.SaveChanges();
                    return taskUpdate.Task_ID;
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ParentTask> GetParentTask()
        {
            List<ParentTask> task = new List<ParentTask>();
            try
            {
                task = _dbTaskManager.ParentTasks.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return task;
        }
    }
}
