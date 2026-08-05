using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tradify.Data;
using Tradify.Data.Dtos.ClienteDtos;
using Tradify.Data.Dtos.ItemPedidoDtos;
using Tradify.Models;

namespace Tradify.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemPedidoController : ControllerBase
{

    private TradifyContext _context;
    private IMapper _mapper;

    public ItemPedidoController(TradifyContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CriaItemPedido([FromBody] CreateItemPedidoDto itemPedidoDto)
    {
        ItemPedido itemPedido = _mapper.Map<ItemPedido>(itemPedidoDto);
        _context.ItensPedidos.Add(itemPedido);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaItemPedidoPorId), new { pedidoId = itemPedido.PedidoId, produtoId = itemPedido.ProdutoId }, itemPedido);
    }

    [HttpGet]
    public IEnumerable<ReadItemPedidoDto> RecuperaItemPedido([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        return _mapper.Map<List<ReadItemPedidoDto>>(_context.ItensPedidos.Skip(skip).Take(take).ToList());
    }

    [HttpGet("{pedidoid}/{produtoid}")]
    public IActionResult RecuperaItemPedidoPorId(int pedidoId, int produtoId)
    {
        var itemPedido = _context.ItensPedidos.FirstOrDefault(itemPedido => itemPedido.ProdutoId == produtoId && itemPedido.PedidoId == pedidoId);
        if (itemPedido is null) return NotFound();
        var itemPedidoDto = _mapper.Map<ReadItemPedidoDto>(itemPedido);
        return Ok(itemPedidoDto);
    }
}
