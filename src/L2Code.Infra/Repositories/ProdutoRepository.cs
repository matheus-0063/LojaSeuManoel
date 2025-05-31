using L2Code.Domain.Entidades;
using L2Code.Domain.Interfaces;
using L2Code.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace L2Code.Infra.Repositories;

public class ProdutoRepository(CodeContext context) : IProdutoRepository
{
    public async Task Adicionar(Produto produto)
    {
        await context.Produtos.AddAsync(produto);
    }

    public async Task<IEnumerable<Produto>> ObterTodos()
    {
        return await context.Produtos
            .ToListAsync();
    }

    public async Task Atualizar(Produto produto)
    {
        context.Produtos.Update(produto);
        await Task.CompletedTask;
    }

    public async Task Remover(Produto produto)
    {
        context.Produtos.Remove(produto);
        await Task.CompletedTask;
    }
}