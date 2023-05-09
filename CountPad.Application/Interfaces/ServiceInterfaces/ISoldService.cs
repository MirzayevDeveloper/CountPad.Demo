// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountPad.Domain.Models.Solds;

namespace CountPad.Application.Interfaces.ServiceInterfaces
{
    public interface ISoldService
    {
        ValueTask<Sold> AddSoldAsync(Sold sold);
        ValueTask<Sold> GetSoldByIdAsync(Guid id);
        IQueryable<Sold> GetAllSoldsAsync();
        ValueTask<Sold> UpdateSoldAsync(Sold sold);
        ValueTask<Sold> DeleteSoldAsync(Guid id);
    }
}
