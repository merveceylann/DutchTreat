using AutoMapper;
using DutchTreat.Data.Entities;
using DutchTreat.ViewModels;

namespace DutchTreat.Data
{
    public class DutchMappingProfile : Profile
    {
        public DutchMappingProfile()
        {
            CreateMap<Order, OrderViewModel>()
                .ForMember(o => o.OrderId, ex => ex.MapFrom(o => o.Id))  //bunu yazmadigimizde id ile orderId nin ayni oldugunu anlayamiyor ve id 0 geliyor
                .ReverseMap(); //zit eslesme

            CreateMap<OrderItem, OrderItemViewModel>()
                .ReverseMap();
        }
    }
}
