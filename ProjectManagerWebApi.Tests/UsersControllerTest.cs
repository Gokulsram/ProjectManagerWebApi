using Moq;
using NUnit.Framework;
using ProjectManagerBusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectManagerWebApi.Tests
{
    public class UsersControllerTest
    {

        Mock<IUsersBusiness> mock = new Mock<IUsersBusiness>();

        [SetUp]
        public void Setup()
        {

        }

        [Test, Order(1)]
        public void GetAllProject_Test()
        {
            mock.Setup(setup => setup.GetAllUsers()).Returns(new List<UsersModel>
            { new UsersModel { UserId = 100, FirstName= "First Name Test",LastName="Last Name Test",EmployeeId=123456} });
            UsersController usersController = new UsersController(mock.Object);

            IEnumerable<UsersModel> resultSet = usersController.Get();

            Assert.IsNotNull(resultSet);
            Assert.AreEqual(1, resultSet.Count());
            Assert.AreEqual("First Name Test", resultSet.ElementAt(0).FirstName);
        }

        [Test, Order(4)]
        public void GetProjectById_Test()
        {
            mock.Setup(setup => setup.GetUserById(100)).Returns(new UsersModel { UserId = 100, FirstName = "First Name Test",  LastName= "Last Name Test", EmployeeId=123456 });
            UsersController usersController = new UsersController(mock.Object);

            UsersModel resultSet = usersController.Get(100);

            Assert.AreEqual("Last Name Test", resultSet.LastName);
        }

        [Test, Order(2)]
        public void AddProject_Test()
        {
            mock.Setup(setup => setup.InsertUser(It.IsAny<UsersModel>())).Returns(true);
            UsersController usersController = new UsersController(mock.Object);

            bool isResult = usersController.Post(new UsersModel());

            Assert.AreEqual(true, isResult);
        }

        [Test, Order(3)]
        public void EditProject_Test()
        {
            mock.Setup(setup => setup.UpdateUser(new UsersModel { UserId = 100, FirstName = "Update FirstName Edit",  LastName="LastName",EmployeeId=123456})).Returns(true);
            UsersController usersController = new UsersController(mock.Object);

            bool isResult = usersController.Post(new UsersModel { UserId = 100, FirstName = "Update FirstName  -Edit", LastName = "LastName -Edit", EmployeeId = 1234567});
            Assert.AreEqual(true, isResult);

        }

        [Test, Order(5)]
        public void DeleteProject_Test()
        {
            mock.Setup(setup => setup.DeleteUser(100)).Returns(true);
            UsersController usersController = new UsersController(mock.Object);
            bool isResult = usersController.Delete(100);
            Assert.AreEqual(true, isResult);
        }

    }
}
