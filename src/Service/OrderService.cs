using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.DTOs;
using Persistence.Database;
using Service.Commons;
using Service.Extensions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public interface IOrderService
    {
        Task<DataCollection<OrderDto>> GetAll(int page, int take);
        Task<OrderDto> GetById(int id);
        Task<OrderDto> Create(OrderCreateDto model);
    }

    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private const decimal IvaRate = 0.18m;

        public OrderService(
            ApplicationDbContext context,
            IMapper mapper
        )
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DataCollection<OrderDto>> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<OrderDto>>(
                await _context.Orders.OrderByDescending(x => x.OrderId)
                                    .Include(x => x.Client)
                                    .Include(x => x.Items)
                                        .ThenInclude(x => x.Product)
                                    .AsQueryable()
                                    .PagedAsync(page, take)
            );
        }

        public async Task<OrderDto> GetById(int id)
        {
            return _mapper.Map<OrderDto>(
                await _context.Orders
                    .Include(x => x.Client)
                    .Include(x => x.Items)
                        .ThenInclude(x => x.Product)
                    .SingleAsync(x => x.OrderId == id)
            );
        }

        public async Task<OrderDto> Create(OrderCreateDto model)
        {
            var entry = _mapper.Map<Order>(model);

            // Prepare order detail
            PrepareDetail(entry.Items);

            // Prepare order header
            PrepareHeader(entry);

            await _context.AddAsync(entry);
            await _context.SaveChangesAsync();

            return _mapper.Map<OrderDto>(
                await GetById(entry.OrderId)
            );
        }

        private void PrepareDetail(IEnumerable<OrderDetail> items)
        {
            foreach (var item in items)
            {
                item.Total = item.UnitPrice * item.Quantity;
                item.SubTotal = item.Total / (1 + IvaRate);
                item.Iva = item.Total - item.SubTotal;
            }
        }

        private void PrepareHeader(Order order) 
        {
            order.SubTotal = order.Items.Sum(x => x.SubTotal);
            order.Iva = order.Items.Sum(x => x.Iva);
            order.Total = order.Items.Sum(x => x.Total);
        }
    }
}
