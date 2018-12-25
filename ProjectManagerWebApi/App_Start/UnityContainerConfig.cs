using ProjectManagerBusinessLayer;
using ProjectManagerDataLayer;
using System.Web.Http;
using Unity;

namespace ProjectManagerWebApi
{
    public class UnityContainerConfig
    {
        public static void RegisterUnitContainers(HttpConfiguration httpconfiguration)
        {
            var container = new UnityContainer();

            container.RegisterType<IUsersRepository, UsersRepository>();
            container.RegisterType<IUsersBusiness, UserBusiness>();
            container.Resolve<UserBusiness>();

            container.RegisterType<IProjectRepository, ProjectRepository>();
            container.RegisterType<IProjectBusiness, ProjectBusiness>();
            container.Resolve<ProjectBusiness>();

            container.RegisterType<ITaskRepository, TaskRepository>();
            container.RegisterType<ITaskBusiness, TaskBusiness>();
            container.Resolve<TaskBusiness>();

            httpconfiguration.DependencyResolver = new UnityContainerHelper(container);
        }
    }
}