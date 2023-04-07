using System;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Application.Services;
using CountPad.Domain.Models.Distributors;
using CountPad.Domain.Models.Products;
using CountPad.Infrastructure.Repositories;
using Tynamix.ObjectFiller;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Domain.Models.Packages;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.ServiceInterfaces;

namespace ConsoleUI
{
    public class Program
    {
        public static Filler<T> CreateObjectFiller<T>() where T : class
        {
            var filler = new Filler<T>();

            filler.Setup().OnType<DateTime>()
                .Use(new DateTimeRange(DateTime.UnixEpoch).GetValue);

            DistributorRepository distributorRepository = new();
            DistributorService distributorService = new(distributorRepository);

            Distributor distributor = CreateObjectFiller<Distributor>().Create();
            distributorService.AddDistributorAsync(distributor);
            Console.WriteLine(distributor.Name);

        }

        static async Task Main(string[] args)
        {
            ProductRepository productRepository = new ProductRepository();
            IProductService productService = new ProductService(productRepository);
            var fillers = CreateObjectFiller<Product>();
            var myprod = fillers.Create();

            await productService.AddProductAsync(myprod);


            var filler = CreateObjectFiller<Package>();
            var mypac = filler.Create();
            mypac.Product = myprod;

            PackageRepository packageRepository = new PackageRepository();
            PackageService packageService = new PackageService(packageRepository);

            int a = await packageService.AddPackageAsync(mypac);
            Console.WriteLine();
            Console.ReadKey();

        }
    }
}