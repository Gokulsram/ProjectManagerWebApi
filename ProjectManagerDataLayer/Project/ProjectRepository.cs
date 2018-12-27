using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerDataLayer
{
    public class ProjectRepository : IProjectRepository
    {
        private ProjectManagerEntities _dbProjectManager;
        private static SqlProviderServices instance = SqlProviderServices.Instance;

        public ProjectRepository()
        {
            _dbProjectManager = new ProjectManagerEntities();
        }
        public bool DeleteProject(int intProjectId)
        {
            try
            {
                Project project = _dbProjectManager.Projects.Where(a => a.Project_ID == intProjectId).FirstOrDefault();
                _dbProjectManager.Projects.Remove(project);
                _dbProjectManager.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<usp_GetAllProjects_Result> GetAllProject()
        {
            List<usp_GetAllProjects_Result> project = new List<usp_GetAllProjects_Result>();
            try
            {
                project = _dbProjectManager.usp_GetAllProjects().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return project;
        }

        public Project GetProjectById(int intProjectId)
        {
            Project project = new Project();
            try
            {
                project = _dbProjectManager.Projects.Where(a => a.Project_ID == intProjectId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return project;
        }

        public int InsertProject(Project project)
        {
            try
            {
                _dbProjectManager.Projects.Add(project);
                _dbProjectManager.SaveChanges();
                return project.Project_ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int UpdateProject(Project project)
        {
            try
            {
                Project projectUpdate = _dbProjectManager.Projects.Where(a => a.Project_ID == project.Project_ID).FirstOrDefault();
                projectUpdate.StartDate = project.StartDate;
                projectUpdate.EndDate = project.EndDate;
                projectUpdate.Priority = project.Priority;
                projectUpdate.Project1 = project.Project1;
                _dbProjectManager.Entry(projectUpdate).State = System.Data.Entity.EntityState.Modified;
                _dbProjectManager.SaveChanges();
                return projectUpdate.Project_ID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
