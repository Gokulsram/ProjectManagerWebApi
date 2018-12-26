using NBench;
using System.Collections.Generic;
using System.Web;
using ProjectManagerBusinessLayer;
using ProjectManagerDataLayer;
using AutoMapper;
using System;

namespace ProjectManagerNBenchLoadTest
{
    public class NBenchProjectLoadTest
    {
        IProjectRepository projectRepository;
        IUsersRepository userRepository;
        ProjectBusiness projectBusiness;

        public NBenchProjectLoadTest()
        {
            projectRepository = new ProjectRepository();
            userRepository = new UsersRepository();
            projectBusiness = new ProjectBusiness(projectRepository, userRepository);
        }
        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {

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
            });

        }

        [PerfBenchmark(Description = "--------NBench Result for GetAllProjects_LoadTest----------",
                         NumberOfIterations = 2,
                         RunMode = RunMode.Throughput,
                         TestMode = TestMode.Measurement, SkipWarmups = false)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 1000)]
        public void GetAllProjects_LoadTest()
        {
            List<ProjectModel> projectModel = projectBusiness.GetAllProjects();
        }

        [PerfBenchmark(Description = "--------NBench Result for GetProjectById_LoadTest----------",
                                                      NumberOfIterations = 2,
                                                      RunMode = RunMode.Throughput,
                                                      TestMode = TestMode.Measurement, SkipWarmups = false)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 1000)]
        public void GetProjectById_LoadTest()
        {
            projectBusiness.GetProjectById(1);
        }

        [PerfBenchmark(Description = "--------NBench Result for AddProject_LoadTest----------",
                                                        NumberOfIterations = 2,
                                                        RunMode = RunMode.Throughput,
                                                        TestMode = TestMode.Measurement, SkipWarmups = false)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 1000)]
        public void AddProject_LoadTest()
        {
            ProjectModel project = new ProjectModel
            {
                ProjectName = "Addd Project for NBench",
                StartDate = DateTime.Now.Date,
                Priority = 15
            };

            projectBusiness.InsertProject(project);
        }

        [PerfBenchmark(Description = "--------NBench Result for UpdateProject_LoadTest----------",
                                                       NumberOfIterations = 2,
                                                       RunMode = RunMode.Throughput,
                                                       TestMode = TestMode.Measurement, SkipWarmups = false)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 1000)]
        public void UpdateProject_LoadTest()
        {
            ProjectModel project = new ProjectModel
            {
                ProjectName = "Update Project for NBench",
                StartDate = DateTime.Now.Date,
                Priority = 15,
                ProjectId = 9

            };


            projectBusiness.UpdateProject(project);
        }

        [PerfBenchmark(Description = "--------NBench Result for DeleteProject_LoadTest----------",
                                                      NumberOfIterations = 2,
                                                      RunMode = RunMode.Throughput,
                                                      TestMode = TestMode.Measurement, SkipWarmups = false)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 1000)]
        public void DeleteProject_LoadTest()
        {
            projectBusiness.DeleteProject(9);
        }



        [PerfCleanup]
        public void Cleanup()
        {
        }

    }
}
