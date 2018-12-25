using ProjectManagerBusinessLayer;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Routing;

namespace ProjectManagerWebApi
{
    public class ProjectController : ApiController
    {
        IProjectBusiness _projectBusiness;
        public ProjectController(IProjectBusiness projectBusiness)
        {
            _projectBusiness = projectBusiness;
        }

        [Route("api/GetAllProjects")]
        public IEnumerable<ProjectModel> Get()
        {
            return _projectBusiness.GetAllProjects();
        }

        [Route("api/GetProjectById")]
        public ProjectModel Get(int intProjectId)
        {
            return _projectBusiness.GetProjectById(intProjectId);
        }

        [Route("api/AddProject")]
        public bool Post([FromBody]ProjectModel project)
        {
            return _projectBusiness.InsertProject(project);
        }

        [Route("api/EditProject")]
        public bool Put([FromBody]ProjectModel project)
        {
            return _projectBusiness.UpdateProject(project);
        }

        [Route("api/DeleteProject")]
        public bool Delete(int intProjectId)
        {
            return _projectBusiness.DeleteProject(intProjectId);
        }
    }
}

