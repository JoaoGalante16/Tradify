using AutoMapper;
using Tradify.Data.Dtos.ClienteDtos;
using Tradify.Models;

namespace Tradify.Profiles;

public class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        CreateMap<CreateClienteDto, Cliente>();
        CreateMap<Cliente, ReadClienteDto>();
        CreateMap<UpdateClienteDto, Cliente>();
        CreateMap<Cliente, UpdateClienteDto>();
    }
}
