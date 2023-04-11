using System;
using System.Threading.Tasks;
using CountPad.Domain.Models.Users;

namespace ConsoleUI.ConsoleLayer.UserMenu
{
    public partial class UserUI
    {
        private async Task<User> AddUser()
        {
            Console.Write("Enter User name: ");
            string UserName = Console.ReadLine();

            Console.Write("Choose User option: ");
            string UserOption = Console.ReadLine();

            Console.Write("Enter Phone number: ");
            string UserPhone = Console.ReadLine();

            Console.Write("Enter Password : ");
            string UserPassword = Console.ReadLine();

            Console.Write("Status :\n1)Manager\n2)Saller\n3)Storekeeper");
            int status;
            while (!int.TryParse(Console.ReadLine(), out status) || status < 1 || status > 4)
            {

                Console.Clear();
                Console.Write("Status :\n1)Manager\n2)Saller\n3)Storekeeper");
            }

            int choose;
            int.TryParse(UserOption, out choose);

            var User = new User()
            {
                Id = Guid.NewGuid(),
                Name = UserName,
                Phone = UserPhone,
                Password = UserPassword,
                Status = (Status)status
            };

            return User;
        }
    }
}
