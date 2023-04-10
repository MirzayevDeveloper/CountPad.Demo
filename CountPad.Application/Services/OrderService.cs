// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CountPad.Application.Interfaces.RepositoryInterfaces;
using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Domain.Models.Orders;

namespace CountPad.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;

        public OrderService(IOrderRepository orderRepository) =>
            this.orderRepository = orderRepository;

        public async Task<int> AddOrderAsync(Order order) =>
            await this.orderRepository.AddAsync(order);

        public async Task<int> AddRangeOrderAsync(IEnumerable<Order> orders) =>
            await this.orderRepository.AddRangeAsync(orders);

        public async Task<int> DeleteOrderAsync(Guid id) =>
            await this.orderRepository.DeleteAsync(id);

        public async Task<List<Order>> GetAllOrdersAsync() =>
            await this.orderRepository.GetAllAsync();

        public async Task<Order> GetOrderByIdAsync(Guid id) =>
            await this.orderRepository.GetByIdAsync(id);

        public async Task<int> UpdateOrderAsync(Order order) =>
            await this.orderRepository.UpdateAsync(order);
    }
}
