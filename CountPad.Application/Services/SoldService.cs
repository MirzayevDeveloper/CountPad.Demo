using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Domain.Models.Solds;

namespace CountPad.Application.Services
{
    public class SoldService : ISoldService
    {
        private readonly ISoldRepository soldRepository;

        public SoldService(ISoldRepository soldRepository) =>
            this.soldRepository = soldRepository;

        public async Task<int> AddRangeSoldAsync(IEnumerable<Sold> solds) =>
            await this.soldRepository.AddRangeAsync(solds);

        public async Task<int> AddSoldAsync(Sold sold) =>
            await this.soldRepository.AddAsync(sold);

        public async Task<int> DeleteSoldAsync(Guid id) =>
            await this.soldRepository.DeleteAsync(id);

        public async Task<List<Sold>> GetAllSoldsAsync() =>
            await this.soldRepository.GetAllAsync();

        public async Task<Sold> GetSoldByIdAsync(Guid id) =>
            await this.soldRepository.GetByIdAsync(id);

        public async Task<int> UpdateSoldAsync(Sold sold) =>
            await this.soldRepository.UpdateAsync(sold);
    }
}
