// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System.Threading.Tasks;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Domain.Models.Orders;

namespace CountPad.Infrastructure.Repositories
{
    public class OrderRepository : BaseRepository, IOrderRepository
    {
        public Task<int> AddAsync(Order entity)
        {

        }
    }
}
