using System;
using CountPad.Application.Services;
using CountPad.Domain.Models.Users;
using CountPad.Domain.Models.Distributors;
using CountPad.Domain.Models.Products;
using CountPad.Infrastructure.Repositories;
using Tynamix.ObjectFiller;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //ProductRepository productRepository = new();
            //ProductService productService = new(productRepository);

            //Product product = CreateObjectFiller<Product>().Create();
            //productService.AddProductAsync(product);
            //Console.WriteLine(product.Name);

            UserRepository userRepository = new();
            UserService userService = new(userRepository);

            User user = CreateObjectFiller<User>().Create();
            userService.AddUserAsync(user);
            Console.WriteLine(user.Name);


            //DistributorRepository distributorRepository = new();
            //DistributorService distributorService = new(distributorRepository);

            //Distributor distributor = CreateObjectFiller<Distributor>().Create();
            //distributorService.AddDistributorAsync(distributor);
            //Console.WriteLine(distributor.Name);

        }

        public static Filler<T> CreateObjectFiller<T>() where T : class
        {
            var filler = new Filler<T>();

            filler.Setup().OnType<DateTime>()
                .Use(new DateTimeRange(DateTime.UnixEpoch).GetValue);

            return filler;
        }
    }
}