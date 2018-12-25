using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerBusinessLayer
{
   public interface IProjectBusiness
    {
        List<ProjectModel> GetAllProjects();
        
        ProjectModel GetProjectById(int intProjectId);
        bool InsertProject(ProjectModel user);
        bool UpdateProject(ProjectModel user);
        bool DeleteProject(int intProjectId);
    }
}
