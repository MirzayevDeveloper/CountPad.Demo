// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using CountPad.Domain.Models.Orders;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using CountPad.Domain.Models.Solds;

namespace CountPad.Application.Interfaces.ServiceInterfaces
{
    public interface ISoldService
    {
        Task<int> AddSoldAsync(Sold sold);
        Task<int> AddRangeSoldAsync(IEnumerable<Sold> solds);
        Task<Sold> GetSoldByIdAsync(Guid id);
        Task<List<Sold>> GetAllSoldsAsync();
        Task<int> UpdateSoldAsync(Sold sold);
        Task<int> DeleteSoldAsync(Guid id);
    }
}
