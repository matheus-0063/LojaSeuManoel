using L2Code.Domain.Entidades;
using L2Code.Domain.Interfaces;
using L2Code.Domain.Utils;

namespace L2Code.Application.Services;

public class EmpacotadorService(IProdutoRepository produtoRepository) : IEmpacotadorService
{
    private readonly List<Caixa> _caixasDisponiveis = new()
    {
        new Caixa { CaixaId = "Caixa 1", Dimensoes = new Dimensoes { Altura = 30, Largura = 40, Comprimento = 80 } },
        new Caixa { CaixaId = "Caixa 2", Dimensoes = new Dimensoes { Altura = 80, Largura = 50, Comprimento = 40 } },
        new Caixa { CaixaId = "Caixa 3", Dimensoes = new Dimensoes { Altura = 50, Largura = 80, Comprimento = 60 } },
    };

    public List<CaixaEmpacotada> Empacotar(Pedido pedido)
    {
        var caixasEmpacotadas = new List<CaixaEmpacotada>();
        var produtosRestantes = new List<Produto>(pedido.Produtos);
        var observacao = "Produto não cabe em nenhuma caixa disponível.";

        foreach (var caixa in _caixasDisponiveis.OrderBy(c => c.Volume))
        {
            var produtosParaCaixa = new List<Produto>();

            foreach (var produto in produtosRestantes.ToList()
                         .Where(produto => produto.Dimensoes.Altura <= caixa.Dimensoes.Altura &&
                                           produto.Dimensoes.Largura <= caixa.Dimensoes.Largura &&
                                           produto.Dimensoes.Comprimento <= caixa.Dimensoes.Comprimento))
            {
                produtoRepository.Adicionar(produto);
                
                produtosParaCaixa.Add(produto);
                produtosRestantes.Remove(produto);
            }

            if (produtosParaCaixa.Count != 0)
            {
                caixasEmpacotadas.Add(new CaixaEmpacotada
                {
                    CaixaId = caixa.CaixaId,
                    Produtos = produtosParaCaixa.Select(p => p.ProdutoId).ToList(),
                });
            }

            if (produtosRestantes.Count == 0) break;
        }

        if (caixasEmpacotadas.Count == 0)
        {
            caixasEmpacotadas.Add(new CaixaEmpacotada
            {
                CaixaId = null,
                Produtos = produtosRestantes.Select(p => p.ProdutoId).ToList(),
                Observacao = observacao
            });
        }
        return caixasEmpacotadas;
    }
}