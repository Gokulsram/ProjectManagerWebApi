using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagerDataLayer
{
    public interface IProjectRepository
    {
        List<usp_GetAllProjects_Result> GetAllProject();
        Project GetProjectById(int intProjectId);
        int InsertProject(Project project);
        int UpdateProject(Project Project);
        bool DeleteProject(int intProjectId);
    }
}
