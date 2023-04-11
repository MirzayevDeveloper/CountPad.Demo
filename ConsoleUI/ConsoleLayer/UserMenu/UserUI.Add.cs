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

            //Console.Write("Choose User option: ");
            //string UserOption = Console.ReadLine();

            Console.Write("Enter Phone number: ");
            string UserPhone = Console.ReadLine();

            Console.Write("Enter Password : ");
            string UserPassword = Console.ReadLine();

            Console.Write("Status :\n1)Saller\n2)Manager\n3)Storekeeper\nTanlang : ");
            int status;
            while (!int.TryParse(Console.ReadLine(), out status) || status < 1 || status > 4)
            {
                Console.Write("Status :\n1)Saller\n2)Manager\n3)Storekeeper\nTanlang : ");
            }


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
