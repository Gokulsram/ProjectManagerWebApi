using NBench;
using System.Collections.Generic;
using System.Web;
using ProjectManagerBusinessLayer;
using ProjectManagerDataLayer;
using AutoMapper;
using System;

namespace ProjectManagerNBenchLoadTest
{
    public class NBenchUserLoadTest
    {
        IUsersRepository userRepository;
        UserBusiness userBusiness;

        public NBenchUserLoadTest()
        {
            userRepository = new UsersRepository();
            userBusiness = new UserBusiness(userRepository);
        }
        [PerfSetup]
        public void Setup(BenchmarkContext context)
        {
            Mapper.Reset();
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

            });

        }


        [PerfBenchmark(Description = "--------NBench Result for AddUser_LoadTest----------",
                                                        NumberOfIterations = 2,
                                                        RunMode = RunMode.Throughput,
                                                        TestMode = TestMode.Measurement, SkipWarmups = false)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 1000)]
        public void AddUser_LoadTest()
        {
            UsersModel task = new UsersModel
            {
                FirstName = "First Name Test by NBench",
                LastName = "Last Name Test by NBench",
                EmployeeId = 15
            };

            userBusiness.InsertUser(task);
        }

        [PerfBenchmark(Description = "--------NBench Result for UpdateUser_LoadTest----------",
                                                       NumberOfIterations = 2,
                                                       RunMode = RunMode.Throughput,
                                                       TestMode = TestMode.Measurement, SkipWarmups = false)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 1000)]
        public void UpdateUser_LoadTest()
        {
            UsersModel user = new UsersModel
            {
                FirstName = "First Name Test - Edit by NBench",
                LastName = "Last Name Test -Edit  by NBench",
                EmployeeId = 15,
                UserId = 1
            };

            userBusiness.UpdateUser(user);
        }

        [PerfBenchmark(Description = "--------NBench Result for GetAllUsers_LoadTest----------",
                        NumberOfIterations = 2,
                        RunMode = RunMode.Throughput,
                        TestMode = TestMode.Measurement, SkipWarmups = false)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 1000)]
        public void GetAllUsers_LoadTest()
        {
            List<UsersModel> tasks = userBusiness.GetAllUsers();
        }

        [PerfBenchmark(Description = "--------NBench Result for GetUserById_LoadTest----------",
                                                      NumberOfIterations = 2,
                                                      RunMode = RunMode.Throughput,
                                                      TestMode = TestMode.Measurement, SkipWarmups = false)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 1000)]
        public void GetUserById_LoadTest()
        {
            userBusiness.GetUserById(1);
        }

        [PerfBenchmark(Description = "--------NBench Result for DeleteUser_LoadTest----------",
                                                      NumberOfIterations = 1,
                                                      RunMode = RunMode.Throughput,
                                                      TestMode = TestMode.Measurement, SkipWarmups = false)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 1000)]
        public void DeleteUser_LoadTest()
        {
            userBusiness.DeleteUser(2);
        }

        [PerfCleanup]
        public void Cleanup()
        {
        }

    }
}
