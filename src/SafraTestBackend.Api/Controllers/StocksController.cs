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
    public class StocksController : MainController
    {
        private readonly IStocksService _stocksService;
        private readonly IStocksRepository _stocksRepository;
        private readonly IMapper _mapper;

        public StocksController(IStocksService stocksService,
            IStocksRepository stocksRepository,
            IMapper mapper,
            INotificator notificator) : base(notificator)
        {
            _stocksRepository = stocksRepository;
            _stocksService = stocksService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<StocksDto>> ListAllStocks()
        {
            return _mapper.Map<IEnumerable<StocksDto>>(await _stocksRepository.GetAllAsync());
        }

        [HttpPost]
        public async Task<ActionResult<StocksDto>> Add(StocksDto stocksDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
            await _stocksService.AddAsync(_mapper.Map<Stocks>(stocksDto));
            return CustomResponse(_mapper.Map<StocksDto>(await _stocksRepository.GetBySymbolAsync(stocksDto.Symbol)));
        }
    }
}
