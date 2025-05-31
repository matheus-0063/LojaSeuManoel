using L2Code.Domain.Entidades;
using L2Code.Domain.Utils;

namespace L2Code.Domain.Interfaces;

public interface IEmpacotadorService
{
    List<CaixaEmpacotada> Empacotar(Pedido pedido);
}

