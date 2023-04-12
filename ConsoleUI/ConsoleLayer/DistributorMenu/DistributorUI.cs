using System;
using System.IO;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Application.Services;
using CountPad.Domain.Models.Distributors;
using CountPad.Domain.Models.Products;
using EKundalik.ConsoleLayer;
using Newtonsoft.Json;
//($"1.     Create {name}" +
//$"\n2.    Create Many {name}" +
//$"\n3.    Select {name}" +
//$"\n4.    Select All {name}s" +
//$"\n5.    Update {name}" +
//$"\n6.    Delete {name}" +
//$"\n7.    Add random {name}s" +
//$"\n8.    Back\n\n" +
//$"        choose option: ");

namespace ConsoleUI.ConsoleLayer.DistributorMenu
{
    public partial class DistributorUI
    {
        private readonly IDistributorService distributorService;

        public DistributorUI(IDistributorRepository distributorRepository) =>
            this.distributorService = new DistributorService(distributorRepository);

        public async Task DistributorCase()
        {
            bool isActive = true;

            while (isActive)
            {
                Console.Clear();
                int choice = General.PrintCrudOptions(nameof(Product));
                Console.Beep();

                switch (choice)
                {
                    case 1:
                        {
                            Distributor distributor = await this.AddDistributor();

                            await this.distributorService.AddDistributorAsync(distributor);
                        }
                        break;
                    case 2:
                        {
                            this.AddDistributorRange();
                        }
                        break;
                    case 3:
                        {
                            //Distributor maybeDistributor = await this.SelectDistributor();

                            //General.PrintObjectProperties(maybeDistributor);
                        }
                        break;
                    case 4:
                        {
                            //this.SelectAllDistributors();
                        }
                        break;
                    case 5:
                        {
                            //await this.UpdateDistributor();
                        }
                        break;
                    case 6:
                        {
                            /*await this.distributorService
                                .DeleteDistributorAsync(
                                    this.DeleteDistributor().Id);*/
                        }
                        break;
                    case 7:
                        {
                            Console.WriteLine("WIP...");
                        }
                        break;
                    case 8:
                        isActive = false;
                        break;
                }
                General.Pause();
            }
        }

        private async Task WriteToFile(Distributor distributor)
        {
            File.WriteAllText("../../../ConsoleLayer/data.json",
                JsonConvert.SerializeObject(distributor, Formatting.Indented));
        }

        private Distributor ReadFromFile()
        {
            return JsonConvert.DeserializeObject<Distributor>(
                File.ReadAllText("../../../ConsoleLayer/data.json"));
        }
    }
}


