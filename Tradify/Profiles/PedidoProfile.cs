using AutoMapper;
using Tradify.Data.Dtos.PedidoDtos;
using Tradify.Models;

namespace Tradify.Profiles;

public class PedidoProfile : Profile
{
    public PedidoProfile()
    {
        CreateMap<CreatePedidoDto, Pedido>();
        CreateMap<Pedido, ReadPedidoDto>();
        CreateMap<UpdatePedidoDto, Pedido>();
        CreateMap<Pedido, UpdatePedidoDto>();
    }
}
