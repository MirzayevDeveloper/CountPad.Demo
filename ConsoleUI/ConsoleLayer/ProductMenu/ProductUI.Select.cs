// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CountPad.Domain.Models.Products;

namespace ConsoleUI.ConsoleLayer.ProductMenu
{
    public partial class ProductUI
    {
        public string SelectProduct()
        {
            Console.Write("enter product id: ");
            string productId = Console.ReadLine();

            return productId;
        }
    }
}
