// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountPad.Domain.Models.Orders;

namespace CountPad.Application.Interfaces.ServiceInterfaces
{
    public interface IOrderService
    {
        ValueTask<Order> AddOrderAsync(Order order);
        ValueTask<Order> GetOrderByIdAsync(Guid id);
        IQueryable<Order> GetAllOrdersAsync();
        ValueTask<Order> UpdateOrderAsync(Order order);
        ValueTask<Order> DeleteOrderAsync(Guid id);
    }
}
