// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Domain.Models.Products;

namespace CountPad.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository) =>
            this.productRepository = productRepository;

        public Task<int> AddProductAsync(Product product) =>
            this.productRepository.AddAsync(product);

        public Task<int> AddProductRangeAsync(IEnumerable<Product> products) =>
            this.productRepository.AddRangeAsync(products);

        public Task<Product> GetProductByIdAsync(Guid id) =>
            this.productRepository.GetByIdAsync(id);
      
        public Task<List<Product>> GetAllProducts() =>
            this.productRepository.GetAllAsync();
        public Task<int> UpdateProductAsync(Product product) => 
            this.productRepository.UpdateAsync(product);

        public Task<int> DeleteProductAsync(Guid id) => 
            this.productRepository.DeleteAsync(id);

    }
}

