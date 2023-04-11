using System;
using System.IO;
using System.Threading.Tasks;
using CountPad.Domain.Models.Users;
using EKundalik.ConsoleLayer;

namespace ConsoleUI.ConsoleLayer.UserMenu
{
    public partial class UserUI
    {
        private async Task<User> UpdateUser()
        {
            bool isActive = true;
            User User = SelectUser().Result;

            if (User != null)
            {
                await WriteToFile(User);
            }

            while (isActive && User != null)
            {
                if (ReadFromFile().Id != default)
                {
                    Console.Clear();
                    General.PrintObjectProperties(User);

                    Console.Write("1.Name\n" +
                                    "Which property do you want to change: ");

                    string choose = Console.ReadLine();
                    int choice;
                    int.TryParse(choose, out choice);

                    Console.Beep();

                    switch (choice)
                    {
                        case 1:
                            {
                                Console.Write("Enter a new Name: ");
                                string name = Console.ReadLine();

                                User.Name = name;
                            }
                            break;
                        case 2:
                            {
                                isActive = false;
                                break;
                            }
                    }
                    await WriteToFile(User);

                    if (choice != 4 && choice != 0) General.Sleep();
                }
            }
            Console.Clear();
            User updatedUser = ReadFromFile();

            File.WriteAllText(
                "../../../ConsoleLayer/data.json", "");

            return updatedUser;
        }
    }
}
