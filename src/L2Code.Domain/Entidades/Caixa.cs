namespace L2Code.Domain.Entidades;

public class Caixa
{
    public string CaixaId { get; set; }
    public Dimensoes Dimensoes { get; set; } = new Dimensoes();
    public int Volume => Dimensoes.Volume;
}