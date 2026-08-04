using AutoMapper;
using Tradify.Data;
using Tradify.Data.Dtos.ClienteDtos;
using Tradify.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Tradify.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private TradifyContext _context;
    private IMapper _mapper;

    public ClienteController(TradifyContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CriaCliente([FromBody] CreateClienteDto clienteDto)
    {
        Cliente cliente = _mapper.Map<Cliente>(clienteDto);
        _context.Clientes.Add(cliente);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaClientePorId), new { id = cliente.Id }, cliente);
    }

    [HttpGet]
    public IEnumerable<ReadClienteDto> RecuperaCliente([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        return _mapper.Map<List<ReadClienteDto>>(_context.Clientes.Skip(skip).Take(take));
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaClientePorId(int id)
    {
        var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
        if (cliente is null) return NotFound();
        var clienteDto = _mapper.Map<ReadClienteDto>(cliente);
        return Ok(clienteDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaCliente(int id, [FromBody] UpdateClienteDto clienteDto)
    {
        var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
        if (cliente is null) return NotFound();
        _mapper.Map(clienteDto, cliente);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaClienteParcial(int id, JsonPatchDocument<UpdateClienteDto> patch)
    {
        var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
        if (cliente is null) return NotFound();

        var clienteParaAtualizar = _mapper.Map<UpdateClienteDto>(cliente);
        patch.ApplyTo(clienteParaAtualizar, ModelState);
        if (!TryValidateModel(clienteParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(clienteParaAtualizar, cliente);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaCliente(int id)
    {
        var cliente = _context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
        if (cliente is null) return NotFound();
        _context.Remove(cliente);
        _context.SaveChanges();
        return NoContent();
    }
}
