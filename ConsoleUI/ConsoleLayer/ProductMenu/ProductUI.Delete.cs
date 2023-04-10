// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using CountPad.Domain.Models.Products;

namespace ConsoleUI.ConsoleLayer.ProductMenu
{
    public partial class ProductUI
    {
        private Product DeleteProduct()
        {
            Product product = SelectProduct().Result ?? new();

            return product;
        }
    }
}
