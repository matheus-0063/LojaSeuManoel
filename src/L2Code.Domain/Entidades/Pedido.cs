using System.Text.Json.Serialization;

namespace L2Code.Domain.Entidades;

public class Pedido
{
    [JsonPropertyName("pedido_id")]
    public int PedidoId { get; set; }
    public ICollection<Produto> Produtos { get; set; } = [];
}