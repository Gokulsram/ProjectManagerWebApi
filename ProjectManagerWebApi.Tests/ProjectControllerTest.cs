using Moq;
using NUnit.Framework;
using ProjectManagerBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagerWebApi.Tests
{
    [TestFixture]
    public class ProjectControllerTest
    {

        Mock<IProjectBusiness> mock = new Mock<IProjectBusiness>();

        [SetUp]
        public void Setup()
        {

        }

        [Test, Order(1)]
        public void GetAllProject_Test()
        {
            mock.Setup(setup => setup.GetAllProjects()).Returns(new List<ProjectModel>
            { new ProjectModel { ProjectId = 100, ProjectName= "Project Controller Get Method", Priority = 1, StartDate = DateTime.Now.Date } });
            ProjectController proejctController = new ProjectController(mock.Object);

            IEnumerable<ProjectModel> resultSet = proejctController.Get();

            Assert.IsNotNull(resultSet);
            Assert.AreEqual(1, resultSet.Count());
            Assert.AreEqual("Project Controller Get Method", resultSet.ElementAt(0).ProjectName);
        }

        [Test, Order(4)]
        public void GetProjectById_Test()
        {
            mock.Setup(setup => setup.GetProjectById(100)).Returns(new ProjectModel { ProjectId = 100, ProjectName = "Project Controller Get Project By Id", Priority = 100, StartDate = DateTime.Now.Date });
            ProjectController proejctController = new ProjectController(mock.Object);

            ProjectModel resultSet = proejctController.Get(100);

            Assert.AreEqual("Project Controller Get Project By Id", resultSet.ProjectName);
        }

        [Test, Order(2)]
        public void AddProject_Test()
        {
            mock.Setup(setup => setup.InsertProject(It.IsAny<ProjectModel>())).Returns(true);
            ProjectController proejctController = new ProjectController(mock.Object);

            bool isResult = proejctController.Post(new ProjectModel());

            Assert.AreEqual(true, isResult);
        }

        [Test, Order(3)]
        public void EditProject_Test()
        {
            mock.Setup(setup => setup.UpdateProject(new ProjectModel { ProjectId = 100, ProjectName = "Update Project Edit", Priority = 1, StartDate = DateTime.Now.Date })).Returns(true);
            ProjectController proejctController = new ProjectController(mock.Object);

            bool isResult = proejctController.Post(new ProjectModel { ProjectId = 100, ProjectName = "Update Project  -Edit", Priority = 99, StartDate = DateTime.Now.Date });
            Assert.AreEqual(true, isResult);

        }

        [Test, Order(5)]
        public void DeleteProject_Test()
        {
            mock.Setup(setup => setup.DeleteProject(100)).Returns(true);
            ProjectController proejctController = new ProjectController(mock.Object);
            bool isResult = proejctController.Delete(100);
            Assert.AreEqual(true, isResult);
        }

    }
}
