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

        public Task<int> AddProductAsync(Product product)
        {
            return this.productRepository.AddAsync(product);
        }

        public Task<int> AddProductRangeAsync(IEnumerable<Product> products)
        {
            return this.productRepository.AddRangeAsync(products);
        }

        public Task<Product> GetProductByIdAsync(Guid id)
        {
            return this.productRepository.GetByIdAsync(id);
        }

        public Task<List<Product>> GetAllProducts()
        {
            return this.productRepository.GetAllAsync();
        }

        public Task<int> UpdateProductAsync(Product product)
        {
            return this.productRepository.UpdateAsync(product);
        }

        public Task<int> DeleteProductAsync(Guid id)
        {
            return this.productRepository.DeleteAsync(id);
        }

    }
}

