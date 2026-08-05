using AutoMapper;
using Tradify.Data;
using Tradify.Data.Dtos.ProdutoDtos;
using Tradify.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Tradify.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private TradifyContext _context;
    private IMapper _mapper;

    public ProdutoController(TradifyContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CriaProduto([FromBody] CreateProdutoDto produtoDto)
    {
        Produto produto = _mapper.Map<Produto>(produtoDto);
        _context.Produtos.Add(produto);
        _context.SaveChanges();
        return CreatedAtAction(nameof(RecuperaProdutoPorId), new { id = produto.Id }, produto);
    }

    [HttpGet]
    public IEnumerable<ReadProdutoDto> RecuperaProduto([FromQuery] int skip = 0, [FromQuery] int take = 20)
    {
        return _mapper.Map<List<ReadProdutoDto>>(_context.Produtos.Skip(skip).Take(take).ToList());
    }

    [HttpGet("{id}")]
    public IActionResult RecuperaProdutoPorId(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
        if (produto is null) return NotFound();
        var produtoDto = _mapper.Map<ReadProdutoDto>(produto);
        return Ok(produtoDto);
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaProduto(int id, [FromBody] UpdateProdutoDto produtoDto)
    {
        var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
        if (produto is null) return NotFound();
        _mapper.Map(produtoDto, produto);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaProdutoParcial(int id, JsonPatchDocument<UpdateProdutoDto> patch)
    {
        var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
        if (produto is null) return NotFound();

        var produtoParaAtualizar = _mapper.Map<UpdateProdutoDto>(produto);
        patch.ApplyTo(produtoParaAtualizar, ModelState);
        if (!TryValidateModel(produtoParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(produtoParaAtualizar, produto);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaProduto(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(produto => produto.Id == id);
        if (produto is null) return NotFound();
        _context.Remove(produto);
        _context.SaveChanges();
        return NoContent();
    }
}
