using Business;
using Interfaces;
using Test.DummyRepos;

namespace Test.UnitTests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void CorrectLoginTest()
        {
            // Arrange
            string username = "tim";
            string password = "abc";
            TestUserRepository testRepo = new TestUserRepository();
            UserService userService = new UserService(testRepo);

            // Act
            bool check = userService.LoginCheck(username, password);

            // Assert
            Assert.IsTrue(check);
        }
        [TestMethod]
        public void FalseLoginTest()
        {
            // Arrange
            string username = "tim";
            string password = "abc1";
            TestUserRepository testRepo = new TestUserRepository();
            UserService userService = new UserService(testRepo);

            // Act
            bool check = userService.LoginCheck(username, password);

            // Assert
            Assert.IsFalse(check);
        }
        [TestMethod]
        public void GetUserByNameTest()
        {
            // Arrange
            string name = "tim";
            TestUserRepository testRepo = new TestUserRepository();
            UserService userService = new UserService(testRepo);
            User desiredUser = new User(1, name, 1, "abc");

            // Act
            User user = userService.GetUserByName(name);

            // Assert
            Assert.AreEqual(desiredUser.Id, user.Id);
            Assert.AreEqual(desiredUser.Password, user.Password);
            Assert.AreEqual(desiredUser.RoleId, user.RoleId);
            Assert.AreEqual(desiredUser.Username, user.Username);
        }
        [TestMethod]
        public void GetAllUsersCount()
        {
            // Arrange
            int amountOfUsers = 3;
            TestUserRepository testRepo = new TestUserRepository();
            UserService userService = new UserService(testRepo);

            // Act
            List<User> users = userService.GetAllUsers();
            int listUsers = users.Count();

            // Assert
            Assert.AreEqual(amountOfUsers, listUsers);
        }
        [TestMethod]
        public void AddUserTest()
        {
            // Arrange
            User user = new User(1, "tim", 1, "abc");
            TestUserRepository testRepo = new TestUserRepository();
            UserService userService = new UserService(testRepo);

            // Act
            bool addTest = userService.AddUser(user);

            // Assert
            Assert.IsTrue(addTest);
        }
    }
}