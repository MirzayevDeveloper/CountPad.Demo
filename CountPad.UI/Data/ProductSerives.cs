using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Application.Services;
using CountPad.Infrastructure.Repositories;

namespace CountPad.UI.Data
{
    public class ProductServices
    {
        private readonly IProductRepository productRepository;
        private readonly IProductService productService;

        public ProductServices()
        {
            this.productRepository = new ProductRepository();

            this.productService =
                new ProductService(productRepository);
        }

        public Task GetProductsAsync()
        {
            var products = this.productService.GetAllProducts().Result.ToArray();

            return Task.FromResult(products);
        }
    }
}