using AutoMapper;
using SafraTestBackend.Api.Dto;
using SafraTestBackend.Domain.Entities;

namespace SafraTestBackend.Api.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<Stocks, StocksDto>().ReverseMap();
            CreateMap<OrdersDto, Order>();
            CreateMap<Order, OrdersDto>()
                .ForMember(d => d.StocksName, opt => opt.MapFrom(src => src.Stocks.Name));

        }
    }
}
