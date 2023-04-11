using System;
using System.IO;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Application.Services;
using CountPad.Domain.Models.Users;
using EKundalik.ConsoleLayer;
using Newtonsoft.Json;

namespace ConsoleUI.ConsoleLayer.UserMenu
{
    public partial class UserUI
    {
        private readonly IUserService userService;

        public UserUI(IUserRepository userRepository) =>
            this.userService = new UserService(userRepository);

        public async Task UserCase()
        {
            bool isActive = true;

            while (isActive)
            {
                Console.Clear();
                int choice = General.PrintCrudOptions(nameof(User));
                Console.Beep();

                switch (choice)
                {
                    case 1:
                        {
                            User User = await this.AddUser();

                            await this.userService.AddUserAsync(User);
                        }
                        break;
                    case 2:
                        {
                            this.AddRangeUser();
                        }
                        break;
                    case 3:
                        {
                            User maybeUser = await this.SelectUser();

                            General.PrintObjectProperties(maybeUser);
                        }
                        break;
                    case 4:
                        {
                            this.SelectAllUser();
                        }
                        break;
                    case 5:
                        {
                            await this.UpdateUser();
                        }
                        break;
                    case 6:
                        {
                            await this.userService
                                .DeleteUserAsync(
                                    this.DeleteUser().Id);
                        }
                        break;
                    case 7:
                        {
                            Console.WriteLine("WIP...");
                        }
                        break;
                    case 8:
                        isActive = false;
                        break;
                }
                General.Pause();
            }
        }

        private async Task WriteToFile(User User)
        {
            File.WriteAllText("../../../ConsoleLayer/data.json",
                JsonConvert.SerializeObject(User, Formatting.Indented));
        }

        private User ReadFromFile()
        {
            return JsonConvert.DeserializeObject<User>(
                File.ReadAllText("../../../ConsoleLayer/data.json"));
        }

    }
}
