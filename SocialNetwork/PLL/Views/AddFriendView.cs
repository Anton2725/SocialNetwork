using SocialNetwork.BLL.Exceptions;
using SocialNetwork.BLL.Models;
using SocialNetwork.BLL.Services;
using SocialNetwork.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.PLL.Views
{
    public class AddFriendView
    {
        UserService userService;
        public AddFriendView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show(User user)
        {
            var userAddFriendData = new UserAddFriendData() { UserId = user.Id };

            Console.Write("Введите email пользователя, которого хотите добавить в друзья: ");
            userAddFriendData.FriendEmail = Console.ReadLine();

            try
            {
                this.userService.AddFriend(userAddFriendData);

                SuccessMessage.Show("Пользователь успешно добавлен в друзья.");
            }

            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь с указанным email не найден.");
            }

            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при добавлении пользователя в друзья.");
            }
        }
    }
}
