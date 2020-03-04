using Manager.Account;
using Model.Account;
using Moq;
using Repository.Context;
using Repository.Repo;
using System;
using Xunit;

namespace UnitTesting
{
    public class AccountUnitTesting
    {
        [Fact]
        public void RegisterTest1()
        {
            var service = new Mock<IAccountRepo>();
            var manager = new AccountManager(service.Object);
            var registration = new Registration()
            {
                Name = "abc",
                Email = "M@gmail.com",
                Password = "123333"
            };
            var data = manager.Register(registration);
            Assert.NotNull(data);
        }
        [Fact]
        public void LoginTest1()
        {
            var service = new Mock<IAccountRepo>();
            var manager = new AccountManager(service.Object);
            var login = new Login()
            {
                Email = "M@gmail.com",
                Password = "123333"
            };
            var data = manager.Login(login);
            Assert.Null(data.Result);
        }
        [Fact]
        public void LoginTest2()
        {
            var service = new Mock<IAccountRepo>();
            var manager = new AccountManager(service.Object);
            var login = new Login()
            {
                Email = "Bhu@gmail.com",
                Password = "123456"
            };
            var data = manager.Login(login);
            Assert.NotNull(data);
        }
    }
}
