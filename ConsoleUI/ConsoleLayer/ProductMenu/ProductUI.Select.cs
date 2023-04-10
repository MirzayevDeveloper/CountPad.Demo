// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CountPad.Domain.Models.Products;
using EKundalik.ConsoleLayer;

namespace ConsoleUI.ConsoleLayer.ProductMenu
{
    public partial class ProductUI
    {
        public async Task<Product> SelectProduct()
        {
            Console.Write("enter product id: ");
            string productId = Console.ReadLine();
            Guid id;
            Guid.TryParse(productId, out id);

            return await this.productService.GetProductByIdAsync(id);
        }

        public async void SelectAllProducts()
        {
            List<Product> products =
                await this.productService.GetAllProducts();

            General.SelectAll(products);
        }
    }
}
