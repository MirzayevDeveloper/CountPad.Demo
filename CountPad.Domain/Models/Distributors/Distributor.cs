using System;
namespace CountPad.Domain.Models.Distributors
{
    public class Distributor
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CompanyPhone { get; set; }
        public string DelivererPhone { get; set; }
    }
}