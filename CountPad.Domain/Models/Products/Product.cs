﻿using System;
namespace CountPad.Domain.Models.Products
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ProductTypes ProductType { get; set; }
        public string Description { get; set; }
    }
}