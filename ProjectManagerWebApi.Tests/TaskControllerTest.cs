using AutoMapper;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using ProjectManagerBusinessLayer;
using ProjectManagerDataLayer;


namespace ProjectManagerWebApi.Tests
{
    [TestFixture]
    public class TaskControllerTest
    {
        UsersController contactsController;
        IEnumerable<UsersModel> taskModels;
        UsersRepository repository = new UsersRepository();

        [SetUp]
        public void Setup()
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

            UserBusiness business = new UserBusiness(repository);

        }

        [Test]
        public void GetAllTaskTest()
        {
            // System.IO.File.AppendAllText(@"C:\Gokul_FSE\Git\logs.txt", "Step 1 ");
            UserBusiness business = new UserBusiness(repository);
            contactsController = new UsersController(business);
            //Number of records
            taskModels = contactsController.Get();
            Assert.IsTrue(taskModels.Count() > 0);
        }
    }
}
