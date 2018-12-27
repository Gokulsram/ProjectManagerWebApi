using Moq;
using NUnit.Framework;
using ProjectManagerBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagerWebApi.Tests
{
    [TestFixture]
    public class TaskControllerTest
    {
        Mock<ITaskBusiness> mock = new Mock<ITaskBusiness>();

        [SetUp]
        public void Setup()
        {

        }

        [Test, Order(1)]
        public void GetAllTaskTest()
        {
            mock.Setup(setup => setup.GetAllTasks()).Returns(new List<TaskModel> { new TaskModel { TaskId = 100, TaskName = "Task Control Get Task", Priority = 1, StartDate = DateTime.Now.Date } });
            TaskController taskController = new TaskController(mock.Object);

            IEnumerable<TaskModel> resultSet = taskController.Get();

            Assert.IsNotNull(resultSet);
            Assert.AreEqual(1, resultSet.Count());
            Assert.AreEqual("Task Control Get Task", resultSet.ElementAt(0).TaskName);
        }

        [Test, Order(2)]
        public void GetAllParentTasks_Test()
        {
            mock.Setup(setup => setup.GetParentTask()).Returns(new List<ParentTaskModel> { new ParentTaskModel { ParentTaskId = 100, ParentTask = "Parent Task Test" } });
            TaskController taskController = new TaskController(mock.Object);

            IEnumerable<ParentTaskModel> resultSet = taskController.GetParentTask();

            Assert.IsNotNull(resultSet);
            Assert.AreEqual(1, resultSet.Count());
            Assert.AreEqual("Parent Task Test", resultSet.ElementAt(0).ParentTask);
        }

        [Test, Order(5)]
        public void GetTaskById_Test()
        {
            mock.Setup(setup => setup.GetTaskById(100)).Returns(new TaskModel { TaskId = 100, TaskName = "Task Control Get Task By Id", Priority = 100, StartDate = DateTime.Now.Date });
            TaskController taskController = new TaskController(mock.Object);

            TaskModel resultSet = taskController.Get(100);

            Assert.AreEqual("Task Control Get Task By Id", resultSet.TaskName);
        }

        [Test, Order(3)]
        public void AddTask_Test()
        {
            mock.Setup(setup => setup.InsertTask(It.IsAny<TaskModel>())).Returns(true);
            TaskController taskController = new TaskController(mock.Object);

            bool isResult = taskController.Post(new TaskModel());

            Assert.AreEqual(true, isResult);
        }

        [Test, Order(4)]
        public void EditTask_Test()
        {
            mock.Setup(setup => setup.UpdateTask(new TaskModel { TaskId = 100, TaskName = "Update Task Edit", Priority = 1, StartDate = DateTime.Now.Date })).Returns(true);
            TaskController taskController = new TaskController(mock.Object);

            bool isResult = taskController.Post(new TaskModel { TaskId = 100, TaskName = "Update Task Edit - Edit", Priority = 99, StartDate = DateTime.Now.Date });
            Assert.AreEqual(true, isResult);

        }

        [Test, Order(6)]
        public void EndTask_Test()
        {
            mock.Setup(setup => setup.EndTask(100)).Returns(true);
            TaskController taskController = new TaskController(mock.Object);
            bool isResult = taskController.EndTask(100);
            Assert.AreEqual(true, isResult);
        }

        [Test, Order(7)]
        public void DeleteTask_Test()
        {
            mock.Setup(setup => setup.DeleteTask(100)).Returns(true);
            TaskController taskController = new TaskController(mock.Object);
            bool isResult = taskController.Delete(100);
            Assert.AreEqual(true, isResult);
        }


        [Test, Order(8)]
        public void AddParentTask_Test()
        {
            mock.Setup(setup => setup.AddParentTask(It.IsAny<ParentTaskModel>())).Returns(true);
            TaskController taskController = new TaskController(mock.Object);

            bool isResult = taskController.Post(new ParentTaskModel());

            Assert.AreEqual(true, isResult);
        }


    }
}
