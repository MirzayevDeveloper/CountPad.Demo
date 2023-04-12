using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CountPad.Domain.Models.Distributors;
using EKundalik.ConsoleLayer;
namespace ConsoleUI.ConsoleLayer.DistributorMenu
{
    public partial class DistributorUI
    {

        private async Task<List<Distributor>> AddDistributorRange()
        {
            Console.Write("How many distributors you want to add : ");
            string distributorNum = Console.ReadLine();

            int distributorsNumber;
            int.TryParse(distributorNum, out distributorsNumber);

            List<Distributor> distributors = new();
            for (int i = 0; i < distributorsNumber; i++)
            {
                Distributor distributor = await this.AddDistributor();
                distributors.Add(distributor);
            }

            return distributors;
        }
    }
}

