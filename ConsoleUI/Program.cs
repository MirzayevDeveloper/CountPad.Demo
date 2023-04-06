using System;
using CountPad.Application.Services;
using CountPad.Domain.Models.Packages;
using CountPad.Infrastructure.Repositories;
using Tynamix.ObjectFiller;

namespace ConsoleUI
{
    public class Program
    {
        public static Filler<T> CreateObjectFiller<T>() where T : class
        {
            var filler = new Filler<T>();

            filler.Setup().OnType<DateTime>()
                .Use(new DateTimeRange(DateTime.UnixEpoch).GetValue);

            return filler;
        }

        static void Main(string[] args)
        {

            PackageRepository packageRepository = new PackageRepository();

            PackageService my = new PackageService(packageRepository);
            Package myPack = CreateObjectFiller<Package>().Create();

            my.AddPackageAsync(myPack);

            Console.ReadKey();

        }
    }
}