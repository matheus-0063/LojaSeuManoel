using L2Code.Domain.Entidades;
using L2Code.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace L2CodeAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PedidosController(IEmpacotadorService empacotadorService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult PostPedidos([FromBody] PedidoRequest request)
    {
        var resultado = new
        {
            pedidos = request.Pedidos.Select(p => new
            {
                pedido_id = p.PedidoId,
                caixas = empacotadorService.Empacotar(p).Select(c => new
                {
                    caixa_id = c.CaixaId,
                    produtos = c.Produtos
                })
            })
        };
        return Ok(resultado);
    }
}


public class PedidoRequest
{
    public List<Pedido> Pedidos { get; set; } = new();
}