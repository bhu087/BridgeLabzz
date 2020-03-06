/////------------------------------------------------------------------------
////<copyright file="AccountUnitTesting.cs" company="BridgeLabz">
////author="Bhushan"
////</copyright>
////-------------------------------------------------------------------------
namespace UnitTesting
{
    using Manager.Account;
    using Model.Account;
    using Moq;
    using Repository.Repo;
    using Xunit;

    /// <summary>
    /// this is the Unit testing for Account
    /// </summary>
    public class AccountUnitTesting
    {
        /// <summary>
        /// Registers the test1.
        /// </summary>
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

        /// <summary>
        /// Logins the test1.
        /// </summary>
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

        /// <summary>
        /// Logins the test2.
        /// </summary>
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

        /// <summary>
        /// Updates the test.
        /// </summary>
        [Fact]
        public void UpdateTest()
        {
            var service = new Mock<IAccountRepo>();
            var manager = new AccountManager(service.Object);
            var registration = new Registration()
            {
                Name = "abc",
                Email = "M@gmail.com",
                Password = "123333"
            };
            var data = manager.Update("abcd@gmail.com", 1005, registration);
            Assert.NotNull(data);
        }
    }
}
