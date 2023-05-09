// --------------------------------------------------------
// Copyright (c) Coalition of Good-Hearted Engineers
// Developed by CountPad Team
// --------------------------------------------------------

using System;
using System.Linq;
using System.Threading.Tasks;
using CountPad.Application.Abstactions;
using CountPad.Application.Interfaces.ServiceInterfaces;
using CountPad.Domain.Models.Distributors;
using CountPad.Domain.Models.Orders;

namespace CountPad.Application.Services
{
	public class OrderService : IOrderService
	{
        private readonly IApplicationDbContext _context;
        public OrderService(IApplicationDbContext context)
        {
            _context= context;
        }
        public async ValueTask<Order> AddOrderAsync(Order order)
		{
			return await _context.AddAsync(order);
		}

		public async ValueTask<Order> DeleteOrderAsync(Guid id)
		{
            Order maybeOrder = await _context.GetAsync<Order>(id);

            if (maybeOrder == null)
            {
                throw new ArgumentNullException(nameof(maybeOrder));
            }

            return await _context.DeleteAsync(maybeOrder);
        }

		public IQueryable<Order> GetAllOrdersAsync()
		{
			return _context.GetAll<Order>();
		}

		public async ValueTask<Order> GetOrderByIdAsync(Guid id)
		{
            return await _context.GetAsync<Order>(id);
        }

		public async ValueTask<Order> UpdateOrderAsync(Order order)
		{
            return await _context.UpdateAsync<Order>(order);
        }
	}
}
