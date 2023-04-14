// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.IO;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Application.Services;
using CountPad.Domain.Models.Products;
using EKundalik.ConsoleLayer;
using Newtonsoft.Json;

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

                switch (choice)
                {
                    case 1:
                        {
                            Product product = 
                                await this.AddProduct();

                            await this.productService
                                .AddProductAsync(product);
                        }
                        break;
                    case 2:
                        {
                            await this.AddRangeProductAsync();
                        }
                        break;
                    case 3:
                        {
                            Product maybeProduct = 
                                await this.SelectProduct();

                            General.PrintObjectProperties(maybeProduct);
                        }
                        break;
                    case 4:
                        {
                            this.SelectAllProducts();
                        }
                        break;
                    case 5:
                        {
                            Product updatedProduct =
                                await this.UpdateProduct();

                            await this.productService
                                .UpdateProductAsync(updatedProduct);
                        }
                        break;
                    case 6:
                        {
                            await this.productService
                                .DeleteProductAsync(
                                    this.DeleteProduct().Id);
                        }
                        break;
                    case 7:
                        {
                            await this.AddRangeProductAsync();
                        }
                        break;
                    case 8:
                        isActive = false;
                        break;
                }
                General.Pause();
            }
        }

        private async Task WriteToFile(Product product)
        {
            File.WriteAllText("../../../ConsoleLayer/data.json",
                JsonConvert.SerializeObject(product, Formatting.Indented));
        }

        private Product ReadFromFile()
        {
            return JsonConvert.DeserializeObject<Product>(
                File.ReadAllText("../../../ConsoleLayer/data.json"));
        }
    }
}
