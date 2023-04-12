using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CountPad.Domain.Models.Users;
using EKundalik.ConsoleLayer;

namespace ConsoleUI.ConsoleLayer.UserMenu
{
    public partial class UserUI
    {
        public async Task<User> SelectUser()
        {
            Console.Write("enter User id: ");
            string userId = Console.ReadLine();
            Guid id;
            Guid.TryParse(userId, out id);

            return await this.userService.GetUserByIdAsync(id);
        }

        public async void SelectAllUser()
        {
            List<User> users =
                await this.userService.GetAllUsersAsync();

            General.SelectAll(users);
        }

    }
}
