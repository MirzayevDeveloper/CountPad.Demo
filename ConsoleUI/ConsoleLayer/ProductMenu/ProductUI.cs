// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System.Threading.Tasks;
using System;
using CountPad.Application.Interfaces.ServiceInterfaces;
using EKundalik.ConsoleLayer;
using CountPad.Domain.Models.Products;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Application.Services;

namespace ConsoleUI.ConsoleLayer.ProductMenu
{
    public partial class ProductUI
    {
        private readonly IProductService productService;

        public ProductUI(IProductRepository productRepository) =>
            this.productService = new ProductService(productRepository);

        public async Task StudentCase()
        {
            bool isActive = true;

            while (isActive)
            {
                Console.Clear();
                int choice = General.PrintCrudOptions(nameof(Product));
                Console.Beep();
                /*$"1.Create {name}" +
                          $"\n2.Create Many {name}" +
                          $"\n3.Select {name}" +
                          $"\n4.Select All {name}s" +
                          $"\n5.Update {name}" +
                          $"\n5.Delete {name}" +
                          $"\n7.Add random {name}s" +
                          $"\n8.Back\n\n" +
                          $"choose option: ");*/
                switch (choice)
                {
                    case 1:
                        {

                        }
                        break;
                    case 2:
                        {

                        }
                        break;
                    case 3:
                        {

                        }
                        break;
                    case 4:
                        {

                        }
                        break;
                    case 5:
                        {

                        }
                        break;
                    case 6:
                        {

                        }
                        break;
                    case 7:
                        {

                        }
                        break;
                    case 8:
                        isActive = false;
                        break;
                }
                General.Pause();
            }
        }
    }
}
