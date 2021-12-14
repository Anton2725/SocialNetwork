using NUnit.Framework;
using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;

namespace Socialnetwork.Tests
{
    [TestFixture]
    public class UserServiceTest
    {

        [Test]
        public void AddFriend_MustReturnUserNotFoundExceptionIfDidNotFindByEmail()
        {
            UserAddFriendData userAddFriendData = new UserAddFriendData()
            {
                UserId = 999,
                FriendEmail = "anton999@gmail.com"
            };

            UserService userService = new UserService();
            
            try
            {
                userService.AddFriend(userAddFriendData);
            }
            catch(UserNotFoundException)
            {
                Assert.IsTrue(true);
                return;
            };

            Assert.IsTrue(false);
        }
    }
}