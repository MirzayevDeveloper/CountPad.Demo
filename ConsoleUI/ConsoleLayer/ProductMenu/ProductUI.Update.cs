// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.IO;
using System.Threading.Tasks;
using CountPad.Domain.Models.Products;
using EKundalik.ConsoleLayer;

namespace ConsoleUI.ConsoleLayer.ProductMenu
{
    public partial class ProductUI
    {
        private async Task<Product> UpdateProduct()
        {
            bool isActive = true;
            Product product = SelectProduct().Result;

            if (product != null)
            {
                await WriteToFile(product);
            }

            while (isActive && product != null)
            {
                if (ReadFromFile().Id != default)
                {
                    Console.Clear();
                    General.PrintObjectProperties(product);

                    Console.Write("1.Name\n" +
                                  "2.Description\n" +
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

                                product.Name = name;
                            }
                            break;
                        case 2:
                            {
                                Console.Write("Enter new Description: ");
                                string desc = Console.ReadLine();

                                product.Description = desc;
                            }
                            break;
                        case 3:
                            isActive = false;
                            break;
                    }
                    await WriteToFile(product);

                    if (choice != 4 && choice != 0) General.Sleep();
                }
            }
            Console.Clear();
            Product updatedProduct = ReadFromFile();

            File.WriteAllText(
                "../../../ConsoleLayer/data.json", "");

            return updatedProduct;
        }
    }
}
