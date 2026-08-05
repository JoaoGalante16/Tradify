using AutoMapper;
using Tradify.Data;
using Tradify.Data.Dtos.PedidoDtos;
using Tradify.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Tradify.Controllers;

[ApiController]
[Route("[controller]")]
public class PedidoController : ControllerBase
{
    private TradifyContext _context;
    private IMapper _mapper;

    public PedidoController(TradifyContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CriaPedido([FromBody] CreatePedidoDto pedidoDto)
    {
        Pedido pedido = _mapper.Map<Pedido>(pedidoDto);
        _context.Pedidos.Add(pedido);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaPedidoPorId), new { id = pedido.Id }, pedido);
    }

    [HttpGet]
    public IEnumerable<ReadPedidoDto> RecuperaPedido([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        return _mapper.Map<List<ReadPedidoDto>>(_context.Pedidos.Skip(skip).Take(take).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaPedidoPorId(int id)
    {
        var pedido = _context.Pedidos.FirstOrDefault(pedido => pedido.Id == id);
        if (pedido is null) return NotFound();
        var pedidoDto = _mapper.Map<ReadPedidoDto>(pedido);
        return Ok(pedidoDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaPedido(int id, [FromBody] UpdatePedidoDto pedidoDto)
    {
        var pedido = _context.Pedidos.FirstOrDefault(pedido => pedido.Id == id);
        if (pedido is null) return NotFound();
        _mapper.Map(pedidoDto, pedido);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaPedidoParcial(int id, JsonPatchDocument<UpdatePedidoDto> patch)
    {
        var pedido = _context.Pedidos.FirstOrDefault(pedido => pedido.Id == id);
        if (pedido is null) return NotFound();

        var pedidoParaAtualizar = _mapper.Map<UpdatePedidoDto>(pedido);
        patch.ApplyTo(pedidoParaAtualizar, ModelState);
        if (!TryValidateModel(pedidoParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(pedidoParaAtualizar, pedido);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaPedido(int id)
    {
        var pedido = _context.Pedidos.FirstOrDefault(pedido => pedido.Id == id);
        if (pedido is null) return NotFound();
        _context.Remove(pedido);
        _context.SaveChanges();
        return NoContent();
    }
}
