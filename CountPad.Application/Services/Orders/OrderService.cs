﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Domain.Models.Orders;

namespace CountPad.Application.Services
{
    public class OrderService : IOrderService
    {
        public ValueTask<Order> AddOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Order> DeleteOrderAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Order> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Order> GetOrderByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Order> UpdateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}