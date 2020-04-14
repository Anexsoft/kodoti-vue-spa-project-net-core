using Core.Api.Commons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;
using Service;
using Service.Commons;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService OrderService) 
        {
            _orderService = OrderService;
        }

        [HttpGet]
        public async Task<ActionResult<DataCollection<OrderDto>>> GetAll(int page, int take = 20)
        {
            return await _orderService.GetAll(page, take);
        }

        // Ex: Orders/1
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDto>> GetById(int id)
        {
            return await _orderService.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult> Create(OrderCreateDto model) 
        {
            var result = await _orderService.Create(model);

            return CreatedAtAction(
                "GetById",
                new { id = result.OrderId },
                result
            );
        }
    }
}
