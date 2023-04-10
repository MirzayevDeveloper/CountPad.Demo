using System;
using System.Collections.Generic;
using CountPad.Domain.Models.Distributors;
using EKundalik.ConsoleLayer;
namespace ConsoleUI.ConsoleLayer.DistributorMenu
{
    public partial class DistributorUI
    {
        public DistributorUI()
        {
            Console.Write("How many distributors you want to add : ");
            string distributorNum = Console.ReadLine();

            int distributorsNumber;
            int.TryParse(distributorNum, out distributorsNumber);

            List<Distributor> distributors = new();
            for (int i = 0; i < distributorsNumber; i++)
            {
                distributors.Add(CreateObjectFiller)
            }
        }
    }
}

