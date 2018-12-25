using AutoMapper;
using ProjectManagerDataLayer;
using System.Collections.Generic;

namespace ProjectManagerBusinessLayer
{
    public class ProjectBusiness : IProjectBusiness
    {
        IProjectRepository _projectRepository;
        IUsersRepository _usersRepository;

        public ProjectBusiness(IProjectRepository projectRepository, IUsersRepository usersRepository)
        {
            _projectRepository = projectRepository;
            _usersRepository = usersRepository;
        }
        public bool DeleteProject(int intProjectId)
        {
            return _projectRepository.DeleteProject(intProjectId);
        }

        public List<ProjectModel> GetAllProjects()
        {
            List<usp_GetAllProjects_Result> project = _projectRepository.GetAllProject();
            List<ProjectModel> projectModel = Mapper.Map<List<ProjectModel>>(project);
            return projectModel;
        }

        public ProjectModel GetProjectById(int intProjectId)
        {
            Project user = _projectRepository.GetProjectById(intProjectId);
            ProjectModel userModel = Mapper.Map<ProjectModel>(user);
            return userModel;
        }

        public bool InsertProject(ProjectModel project)
        {
            Project users = Mapper.Map<Project>(project);

            int intProjectId = _projectRepository.InsertProject(users);

            if (project.UserId > 0 && intProjectId > 0)
            {
                return _usersRepository.UpdateUserProjectId(intProjectId, project.UserId);
            }
            return true;
        }

        public bool UpdateProject(ProjectModel project)
        {
            Project users = Mapper.Map<Project>(project);
            int intProjectId = _projectRepository.UpdateProject(users);
            if (project.UserId > 0 && intProjectId > 0)
            {
                return _usersRepository.UpdateUserProjectId(intProjectId, project.UserId);
            }
            return true;
        }
    }
}
