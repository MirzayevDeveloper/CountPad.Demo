using System;
using CountPad.Domain.Models.Products;
using System.Threading.Tasks;
using CountPad.Domain.Models.Distributors;
using System.Xml.Linq;

namespace ConsoleUI.ConsoleLayer.DistributorMenu
{
    public partial class DistributorUI
    {
        //Id
        //Name
        // CompanyPhone
        //DelivererPhone

        private async Task<Distributor> AddDistributor()
        {
            Console.Write("enter distributor name: ");
            string productName = Console.ReadLine();

            Console.Write("enter company phone: ");
            string companyPhone = Console.ReadLine();

            Console.Write("enter deliverer phone: ");
            string delivererPhone = Console.ReadLine();

            // (id, name, company_Phone, deliverer_Phone) 
            //VALUES(@Id, @Name, @CompanyPhone, @DelivererPhone)";
            var distributor = new Distributor()
            {
                Id = Guid.NewGuid(),
                Name = productName,
                CompanyPhone = companyPhone,
                DelivererPhone = delivererPhone
            };

            return distributor;
        }
    }
}

