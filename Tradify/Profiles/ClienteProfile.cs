using AutoMapper;
using Tradify.Data.Dtos.ClienteDtos;
using Tradify.Models;

namespace Tradify.Profiles;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<CreateClienteDto, Cliente>();
        CreateMap<Cliente, ReadClienteDto>()
        .ForMember(clienteDto => clienteDto.Pedidos, opt => opt.MapFrom(cliente => cliente.Pedidos));
        CreateMap<UpdateClienteDto, Cliente>();
        CreateMap<Cliente, UpdateClienteDto>();
    }
}
