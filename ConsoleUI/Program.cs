// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using ConsoleUI.ConsoleLayer.ProductMenu;
using ConsoleUI.ConsoleLayer.UserMenu;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Infrastructure.Repositories;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool isActive = true;

            while (isActive)
            {
                Console.Clear();

                Console.Write("1.Users\n" +
                              "2.Products\n" +
                              "3.Packages\n" +
                              "4.Orders\n" +
                              "5.Solds\n" +
                              "6.Distributors\n" +
                              "7.Exit\n" +
                              "choose option: ");

                string choose = Console.ReadLine();
                int choice;
                int.TryParse(choose, out choice);
                Console.Beep();

                switch (choice)
                {
                    case 1:
                        {
                            IUserRepository userRepository =
                                new UserRepository();

                            var userUI = 
                                new UserUI(userRepository);

                            userUI.UserCase().Wait();
                        }
                        break;
                    case 2:
                        {
                            IProductRepository productRepository =
                                new ProductRepository();

                            var productUI =
                                new ProductUI(productRepository);

                            productUI.ProductCase().Wait();
                        }
                        break;
                    case 3:
                        {
                            IPackageRepository packageRepository =
                                new PackageRepository();
                        }
                        break;
                    case 4:
                        {
                            IOrderRepository orderRepository =
                                new OrderRepository();
                        }
                        break;
                    case 5:
                        {
                            ISoldRepository soldRepository =
                                new SoldRepository();
                        }
                        break;
                    case 6:
                        {
                            IDistributorRepository distributorRepository =
                                new DistributorRepository();
                        }
                        break;
                    case 7:
                        isActive = false;
                        break;
                }
            }
        }
    }
}
