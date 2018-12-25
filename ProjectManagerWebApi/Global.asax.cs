using AutoMapper;
using ProjectManagerBusinessLayer;
using ProjectManagerDataLayer;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjectManagerWebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            if (Request.Headers.AllKeys.Contains("Origin") && Request.HttpMethod == "OPTIONS")
            {
                Response.Flush();
            }
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configure(UnityContainerConfig.RegisterUnitContainers);
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            json.SerializerSettings.DateFormatString = "MM/dd/yyyy";

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UsersModel, User>()
                    .ForMember(vm => vm.User_ID, map => map.MapFrom(m => m.UserId))
                  .ForMember(vm => vm.FirstName, map => map.MapFrom(m => m.FirstName))
                  .ForMember(vm => vm.LastName, map => map.MapFrom(m => m.LastName))
                  .ForMember(vm => vm.Employee_ID, map => map.MapFrom(m => m.EmployeeId))
                  .ForMember(vm => vm.Task_ID, map => map.MapFrom(m => m.TaskId))
                  .ForMember(vm => vm.Project_ID, map => map.MapFrom(m => m.ProjectId));

                cfg.CreateMap<User, UsersModel>()
                    .ForMember(vm => vm.UserId, map => map.MapFrom(m => m.User_ID))
                  .ForMember(vm => vm.FirstName, map => map.MapFrom(m => m.FirstName))
                  .ForMember(vm => vm.LastName, map => map.MapFrom(m => m.LastName))
                  .ForMember(vm => vm.EmployeeId, map => map.MapFrom(m => m.Employee_ID))
                  .ForMember(vm => vm.TaskId, map => map.MapFrom(m => m.Task_ID))
                  .ForMember(vm => vm.ProjectId, map => map.MapFrom(m => m.Project_ID));

                cfg.CreateMap<ProjectModel, usp_GetAllProjects_Result>()
                 .ForMember(vm => vm.Project_ID, map => map.MapFrom(m => m.ProjectId))
                   .ForMember(vm => vm.Project, map => map.MapFrom(m => m.ProjectName))
                 .ForMember(vm => vm.StartDate, map => map.MapFrom(m => m.StartDate))
                 .ForMember(vm => vm.EndDate, map => map.MapFrom(m => m.EndDate))
                 .ForMember(vm => vm.Priority, map => map.MapFrom(m => m.Priority))
                .ForMember(vm => vm.TasksCount, map => map.MapFrom(m => m.TasksCount))
                 .ForMember(vm => vm.CompletedTask, map => map.MapFrom(m => m.CompletedTask))
                .ForMember(vm => vm.UserId, map => map.MapFrom(m => m.UserId))
                .ForMember(vm => vm.UserName, map => map.MapFrom(m => m.UserName));

                cfg.CreateMap<usp_GetAllProjects_Result, ProjectModel>()
                    .ForMember(vm => vm.ProjectId, map => map.MapFrom(m => m.Project_ID))
                  .ForMember(vm => vm.ProjectName, map => map.MapFrom(m => m.Project))
                  .ForMember(vm => vm.EndDate, map => map.MapFrom(m => m.StartDate))
                  .ForMember(vm => vm.EndDate, map => map.MapFrom(m => m.EndDate))
                  .ForMember(vm => vm.Priority, map => map.MapFrom(m => m.Priority))
                     .ForMember(vm => vm.TasksCount, map => map.MapFrom(m => m.TasksCount))
                 .ForMember(vm => vm.CompletedTask, map => map.MapFrom(m => m.CompletedTask))
                .ForMember(vm => vm.UserId, map => map.MapFrom(m => m.UserId))
                .ForMember(vm => vm.UserName, map => map.MapFrom(m => m.UserName));

                cfg.CreateMap<ProjectModel, Project>()
              .ForMember(vm => vm.Project_ID, map => map.MapFrom(m => m.ProjectId))
                .ForMember(vm => vm.Project1, map => map.MapFrom(m => m.ProjectName))
              .ForMember(vm => vm.StartDate, map => map.MapFrom(m => m.StartDate))
              .ForMember(vm => vm.EndDate, map => map.MapFrom(m => m.EndDate))
              .ForMember(vm => vm.Priority, map => map.MapFrom(m => m.Priority));

                cfg.CreateMap<Project, ProjectModel>()
                    .ForMember(vm => vm.ProjectId, map => map.MapFrom(m => m.Project_ID))
                  .ForMember(vm => vm.ProjectName, map => map.MapFrom(m => m.Project1))
                  .ForMember(vm => vm.EndDate, map => map.MapFrom(m => m.StartDate))
                  .ForMember(vm => vm.EndDate, map => map.MapFrom(m => m.EndDate))
                  .ForMember(vm => vm.Priority, map => map.MapFrom(m => m.Priority));

                cfg.CreateMap<TaskModel, Task>()
                      .ForMember(vm => vm.Task_ID, map => map.MapFrom(m => m.TaskId))
                  .ForMember(vm => vm.Parent_ID, map => map.MapFrom(m => m.ParentTaskId))
                  .ForMember(vm => vm.Project_ID, map => map.MapFrom(m => m.ProjectId))
                  .ForMember(vm => vm.Task1, map => map.MapFrom(m => m.TaskName))
                  .ForMember(vm => vm.Start_Date, map => map.MapFrom(m => m.StartDate))
                  .ForMember(vm => vm.End_Date, map => map.MapFrom(m => m.EndDate))
                  .ForMember(vm => vm.Priority, map => map.MapFrom(m => m.Priority))
                  .ForMember(vm => vm.Status, map => map.MapFrom(m => m.Status))
                  .ForMember(vm => vm.Project, map => map.Ignore());

                cfg.CreateMap<Task, TaskModel>()
                      .ForMember(vm => vm.TaskId, map => map.MapFrom(m => m.Task_ID))
                  .ForMember(vm => vm.ParentTaskId, map => map.MapFrom(m => m.Parent_ID))
                  .ForMember(vm => vm.ProjectId, map => map.MapFrom(m => m.Project_ID))
                  .ForMember(vm => vm.TaskName, map => map.MapFrom(m => m.Task1))
                  .ForMember(vm => vm.StartDate, map => map.MapFrom(m => m.Start_Date))
                  .ForMember(vm => vm.EndDate, map => map.MapFrom(m => m.End_Date))
                  .ForMember(vm => vm.Priority, map => map.MapFrom(m => m.Priority))
                  .ForMember(vm => vm.Status, map => map.MapFrom(m => m.Status));

                cfg.CreateMap<TaskModel, usp_GetAllTasks_Result>()
                .ForMember(vm => vm.Task_ID, map => map.MapFrom(m => m.TaskId))
                .ForMember(vm => vm.Parent_ID, map => map.MapFrom(m => m.ParentTaskId))
                .ForMember(vm => vm.Project_ID, map => map.MapFrom(m => m.ProjectId))
                .ForMember(vm => vm.Task, map => map.MapFrom(m => m.TaskName))
                .ForMember(vm => vm.Start_Date, map => map.MapFrom(m => m.StartDate))
                .ForMember(vm => vm.End_Date, map => map.MapFrom(m => m.EndDate))
                .ForMember(vm => vm.Priority, map => map.MapFrom(m => m.Priority))
                .ForMember(vm => vm.Status, map => map.MapFrom(m => m.Status))
                .ForMember(vm => vm.Parent_Task, map => map.MapFrom(m => m.ParentTask))
                .ForMember(vm => vm.User_ID, map => map.MapFrom(m => m.UserId))
                .ForMember(vm => vm.UserName, map => map.MapFrom(m => m.UserName));

                cfg.CreateMap<usp_GetAllTasks_Result, TaskModel>()
                          .ForMember(vm => vm.TaskId, map => map.MapFrom(m => m.Task_ID))
                .ForMember(vm => vm.ParentTaskId, map => map.MapFrom(m => m.Parent_ID))
                .ForMember(vm => vm.ProjectId, map => map.MapFrom(m => m.Project_ID))
                .ForMember(vm => vm.TaskName, map => map.MapFrom(m => m.Task))
                .ForMember(vm => vm.StartDate, map => map.MapFrom(m => m.Start_Date))
                .ForMember(vm => vm.EndDate, map => map.MapFrom(m => m.End_Date))
                .ForMember(vm => vm.Priority, map => map.MapFrom(m => m.Priority))
                .ForMember(vm => vm.Status, map => map.MapFrom(m => m.Status))
                .ForMember(vm => vm.ParentTask, map => map.MapFrom(m => m.Parent_Task))
                .ForMember(vm => vm.UserId, map => map.MapFrom(m => m.User_ID))
                .ForMember(vm => vm.UserName, map => map.MapFrom(m => m.UserName));

                cfg.CreateMap<ParentTaskModel, ParentTask>()
                         .ForMember(vm => vm.Parent_ID, map => map.MapFrom(m => m.ParentTaskId))
                  .ForMember(vm => vm.Parent_Task, map => map.MapFrom(m => m.ParentTask));

                cfg.CreateMap<ParentTask, ParentTaskModel>()
                         .ForMember(vm => vm.ParentTaskId, map => map.MapFrom(m => m.Parent_ID))
                  .ForMember(vm => vm.ParentTask, map => map.MapFrom(m => m.Parent_Task));

            });
        }
    }
}
