using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SafraTestBackend.Api.Dto;
using SafraTestBackend.Business.Interfaces;
using SafraTestBackend.Domain.Entities;
using SafraTestBackend.Domain.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SafraTestBackend.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : MainController
    {
        private readonly IOrderService _orderService;
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService,
            IOrderRepository orderRepository,
            IMapper mapper,
            INotificator notificator) : base(notificator)
        {
            _orderService = orderService;
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<OrdersDto>> ListOrdersBySymbolStocks(string symbol)
        {
            return _mapper.Map<IEnumerable<OrdersDto>>(await _orderRepository.ListOrdersBySymbolStocksAsync(symbol));
        }

        [HttpPost]
        public async Task<ActionResult<OrdersDto>> RegistryOrder(OrdersDto ordersDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _orderService.RegistryOrderAsync(_mapper.Map<Order>(ordersDto));
            return CustomResponse(_mapper.Map<OrdersDto>(await _orderRepository.GetByIdAsync(ordersDto.Id)));
        }
    }
}
