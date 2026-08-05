using AutoMapper;
using Tradify.Data.Dtos.ProdutoDtos;
using Tradify.Models;

namespace Tradify.Profiles;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<CreateProdutoDto, Produto>();
        CreateMap<Produto, ReadProdutoDto>()
            .ForMember(produtoDto => produtoDto.Itens, opt => opt.MapFrom(produto => produto.Itens));
        CreateMap<UpdateProdutoDto, Produto>();
        CreateMap<Produto, UpdateProdutoDto>();
    }
}
