using NBench;
using System.Collections.Generic;
using ProjectManagerBusinessLayer;
using ProjectManagerDataLayer;
using AutoMapper;
using System;
using System.Web;

[assembly: PreApplicationStartMethod(typeof(ProjectManagerNBenchLoadTest.NBenchTaskLoadTest), "Start")]
namespace ProjectManagerNBenchLoadTest
{
    public class NBenchTaskLoadTest
    {
        ITaskRepository taskRepository;
        IUsersRepository userRepository;
        TaskBusiness taskBusiness;
        public NBenchTaskLoadTest()
        {
            taskRepository = new TaskRepository();
            userRepository = new UsersRepository();
            taskBusiness = new TaskBusiness(taskRepository, userRepository);
        }
        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {

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


        [PerfBenchmark(Description = "--------NBench Result for AddTask_LoadTest----------",
                                                        NumberOfIterations = 2,
                                                        RunMode = RunMode.Throughput,
                                                        TestMode = TestMode.Measurement, SkipWarmups = false)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 1000)]
        public void AddTask_LoadTest()
        {
            TaskModel task = new TaskModel
            {
                TaskName = "Test Task by NBench",
                StartDate = DateTime.Now.Date,
                Priority = 15
            };

            taskBusiness.InsertTask(task);
        }

        [PerfBenchmark(Description = "--------NBench Result for UpdateTask_LoadTest----------",
                                                       NumberOfIterations = 2,
                                                       RunMode = RunMode.Throughput,
                                                       TestMode = TestMode.Measurement, SkipWarmups = false)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 1000)]
        public void UpdateTask_LoadTest()
        {
            TaskModel task = new TaskModel
            {
                TaskName = "Test Task by NBench - Edit",
                StartDate = DateTime.Now.Date,
                Priority = 15,
                TaskId = 1

            };


            taskBusiness.UpdateTask(task);
        }


        [PerfBenchmark(Description = "--------NBench Result for GetAllParentTask_LoadTest----------",
                                                      NumberOfIterations = 2,
                                                      RunMode = RunMode.Throughput,
                                                      TestMode = TestMode.Measurement, SkipWarmups = false)]

        [ElapsedTimeAssertion(MaxTimeMilliseconds = 1000)]

        public void GetAllParentTask_LoadTest()
        {
            List<ParentTaskModel> parentTasks;
            parentTasks = taskBusiness.GetParentTask();
        }

        [PerfBenchmark(Description = "--------NBench Result for GetTasks_LoadTest----------",
                        NumberOfIterations = 2,
                        RunMode = RunMode.Throughput,
                        TestMode = TestMode.Measurement, SkipWarmups = false)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 1000)]
        public void GetTasks_LoadTest()
        {
            List<TaskModel> tasks;
            tasks = taskBusiness.GetAllTasks();
        }

        [PerfBenchmark(Description = "--------NBench Result for GetTaskById_LoadTest----------",
                                                      NumberOfIterations = 2,
                                                      RunMode = RunMode.Throughput,
                                                      TestMode = TestMode.Measurement, SkipWarmups = false)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 1000)]
        public void GetTaskById_LoadTest()
        {
            taskBusiness.GetTaskById(1);
        }

        [PerfBenchmark(Description = "--------NBench Result for DeleteTask_LoadTest----------",
                                                      NumberOfIterations = 2,
                                                      RunMode = RunMode.Throughput,
                                                      TestMode = TestMode.Measurement, SkipWarmups = false)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 1000)]
        public void DeleteTask_LoadTest()
        {
            taskBusiness.DeleteTask(960);
        }

        [PerfBenchmark(Description = "--------NBench Result for EndTask----------",
                                                     NumberOfIterations = 2,
                                                     RunMode = RunMode.Throughput,
                                                     TestMode = TestMode.Measurement, SkipWarmups = false)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 1000)]
        public void EndTask_LoadTest()
        {
            taskBusiness.EndTask(960);
        }

        [PerfCleanup]
        public void Cleanup()
        {
        }
    }
}
