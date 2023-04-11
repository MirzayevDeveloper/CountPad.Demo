using CountPad.Domain.Models.Users;
using System.Threading.Tasks;
using System;
using CountPad.Domain.Models.Products;
using EKundalik.ConsoleLayer;
using System.Collections.Generic;

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
