using Manager.Account;
using Model.Account;
using Moq;
using Repository.Repo;
using System;
using Xunit;

namespace FundooXUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void RegistrationTest1()
        {
            var service = new Mock<IAccountRepo>();
            var manager = new AccountManager(service.Object);
            Registration registration = new Registration
            {
                Id = 5,
                Name = "m",
                Email = "m@g",
                Password = "m"
            };
            var result = manager.Register(registration);
            Assert.True(result != null);
        }
    }
}
