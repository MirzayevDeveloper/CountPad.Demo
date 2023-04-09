// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CountPad.Domain.Models.Orders;

namespace CountPad.Application.Interfaces.ServiceInterfaces
{
    public interface IOrderService
    {
        Task<int> AddOrderAsync(Order order);
        Task<int> AddRangeOrderAsync(IEnumerable<Order> entities);
        Task<Order> GetOrderByIdAsync(Guid id);
        Task<List<Order>> GetAllOrdersAsync();
        Task<int> UpdateOrderAsync(Order entity);
        Task<int> DeleteOrderAsync(Guid id);
    }
}
