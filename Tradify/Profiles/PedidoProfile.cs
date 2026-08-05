using AutoMapper;
using Tradify.Data.Dtos.PedidoDtos;
using Tradify.Models;

namespace Tradify.Profiles;

public class PedidoProfile : Profile
{
    public PedidoProfile()
    {
        CreateMap<CreatePedidoDto, Pedido>();
        CreateMap<Pedido, ReadPedidoDto>()
            .ForMember(pedidoDto => pedidoDto.Itens, opt => opt.MapFrom(pedido => pedido.Itens));
        CreateMap<UpdatePedidoDto, Pedido>();
        CreateMap<Pedido, UpdatePedidoDto>();
    }
}
