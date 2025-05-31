namespace L2Code.Domain.Utils;

public class CaixaEmpacotada
{
    public string? CaixaId { get; set; }
    public List<string> Produtos { get; set; } = new();
    public string? Observacao { get; set; }
}