// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Threading.Tasks;
using CountPad.Domain.Models.Products;
using EKundalik.ConsoleLayer;

namespace ConsoleUI.ConsoleLayer.ProductMenu
{
    public partial class ProductUI
    {
        public async Task AddRangeProductAsync()
        {
            bool isActive = true;
            while (isActive)
            {
                Console.Write("How many products ");
                string stringNumber = Console.ReadLine();
                int number;
                int.TryParse(stringNumber, out number);

                for (int i = 0; i < number; i++)
                {
                    await this.productService.AddProductAsync(
                        General.CreateObjectFiller<Product>().Create());
                }
            }
        }
    }
}
