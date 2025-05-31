using System.Text.Json.Serialization;

namespace L2Code.Domain.Entidades;

public class Produto
{
    [JsonPropertyName("produto_id")]
    public string ProdutoId { get; set; } = string.Empty;
    public Dimensoes Dimensoes { get; set; }
}