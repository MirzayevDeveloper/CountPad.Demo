// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Threading.Tasks;
using CountPad.Domain.Models.Products;

namespace ConsoleUI.ConsoleLayer.ProductMenu
{
    public partial class ProductUI
    {
        private async Task<Product> AddProduct()
        {
            Console.Write("enter product name: ");
            string productName = Console.ReadLine();

            int i = 0;
            foreach (ProductTypes day in Enum.GetValues(typeof(ProductTypes)))
            {
                i++;
                Console.WriteLine($"{i}.{day}");
            }

            Console.Write("Choose product option: ");
            string productOption = Console.ReadLine();
            int choose;
            int.TryParse(productOption, out choose);

            Console.Write("enter a description for product: ");
            string description = Console.ReadLine();

            var product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = productName,
                ProductType = (ProductTypes)choose,
                Description = description
            };

            return product;
        }
    }
}
