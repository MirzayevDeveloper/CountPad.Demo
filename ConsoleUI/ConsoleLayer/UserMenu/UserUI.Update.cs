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

                    Console.Write("1.Name\n2.Phone Number\n3.User Status\n4.Passeord\n5.Exit" +
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
                                Console.Write("Enter Phone number: ");
                                string UserPhone = Console.ReadLine();
                                User.Phone = UserPhone;
                            }
                            break;
                            case 3:
                            {
                                Console.Write("Status :\n1)Saller\n2)Manager\n3)Storekeeper\nTanlang : ");
                                int status;
                                while (!int.TryParse(Console.ReadLine(), out status) || status < 1 || status > 4)
                                {
                                    Console.Write("Status :\n1)Saller\n2)Manager\n3)Storekeeper\nTanlang : ");
                                }
                                User.Status = (Status)status;
                            }
                            break;
                            case 4:
                            {
                                Console.Write("Enter Password : ");
                                string UserPassword = Console.ReadLine();
                                User.Password = UserPassword;
                            }
                            break;
                            case 5:
                            {
                                isActive = false;
                            }
                            break;

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
