// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Application.Services;
using CountPad.Domain.Models.Products;
using EKundalik.ConsoleLayer;

namespace ConsoleUI.ConsoleLayer.ProductMenu
{
    public partial class ProductUI
    {
        private readonly IProductService productService;

        public ProductUI(IProductRepository productRepository) =>
            this.productService = new ProductService(productRepository);

        public async Task ProductCase()
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
                            Product product = await this.AddProduct();

                            await this.productService.AddProductAsync(product);
                        }
                        break;
                    case 2:
                        {
                            this.AddRangeProduct();
                        }
                        break;
                    case 3:
                        {
                            this.SelectProduct();
                        }
                        break;
                    case 4:
                        {
                            // WIP
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
