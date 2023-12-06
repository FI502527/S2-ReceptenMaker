using Business;
using Interfaces;

namespace Test
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


            // Act
            TestUserRepository testRepo = new TestUserRepository();
            UserService userService = new UserService(testRepo);
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


            // Act
            TestUserRepository testRepo = new TestUserRepository();
            UserService userService = new UserService(testRepo);
            bool check = userService.LoginCheck(username, password);

            // Assert
            Assert.IsFalse(check);
        }
        [TestMethod]
        public void GetUserByNameTest()
        {
            // Arrange
            string name = "tim";

            // Act
            TestUserRepository testRepo = new TestUserRepository();
            UserService userService = new UserService(testRepo);
            User user = userService.GetUserByName(name);
            User desiredUser = new User(1, name, 1, "abc");

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

            // Act
            TestUserRepository testRepo = new TestUserRepository();
            UserService userService = new UserService(testRepo);
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

            // Act
            TestUserRepository testRepo = new TestUserRepository();
            UserService userService = new UserService(testRepo);
            bool addTest = userService.AddUser(user);

            // Assert
            Assert.IsTrue(addTest);
        }
    }
}