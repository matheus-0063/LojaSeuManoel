using L2Code.Domain.Entidades;

namespace L2Code.Domain.Interfaces;

public interface IProdutoRepository
{
    Task Adicionar(Produto produto);
    Task<IEnumerable<Produto>> ObterTodos();
    Task Atualizar(Produto produto);
    Task Remover(Produto produto);
}