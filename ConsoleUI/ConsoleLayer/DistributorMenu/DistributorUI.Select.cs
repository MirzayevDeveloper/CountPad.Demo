using System;
using CountPad.Domain.Models.Distributors;
using System.Threading.Tasks;

namespace ConsoleUI.ConsoleLayer.DistributorMenu
{
    public partial class DistributorUI
    {
        private async Task<Distributor> SelectDistributor(Guid id)
        {
            Console.Write("Enter Distributor ID : ");
            string distributorId = Console.ReadLine();

            Guid.TryParse(distributorId, out Guid guid);

            return await this.distributorService.GetDistributorByIdAsync(guid);

        }
    }
}

