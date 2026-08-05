using AutoMapper;
using Tradify.Data.Dtos.ItemPedidoDtos;
using Tradify.Models;

namespace Tradify.Profiles
{
    public class ItemPedidoProfile : Profile
    {
        public ItemPedidoProfile()
        {
            CreateMap<CreateItemPedidoDto, ItemPedido>();
            CreateMap<ItemPedido, ReadItemPedidoDto>();
        }
    }
}
