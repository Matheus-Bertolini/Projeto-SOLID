using System;
using System.Collections.Generic;
using System.Linq;

// Princípio da Responsabilidade Única (SRP)
// A classe Produto tem a única responsabilidade de representar os dados de um produto.
public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
}

// Princípio da Aberto/Fechado (OCP)
// A interface IRepositorioProduto define os métodos necessários para um repositório de produtos.
// Está aberta para extensão (novas implementações podem ser criadas) mas fechada para modificação.
public interface IRepositorioProduto
{
    void AdicionarProduto(Produto produto);
    void RemoverProduto(int produtoId);
    Produto ObterProdutoPorId(int produtoId);
    List<Produto> ObterTodosProdutos();
}

// Princípio da Substituição de Liskov (LSP)
// A classe RepositorioProdutoEmMemoria implementa a interface IRepositorioProduto,
// garantindo que qualquer classe que a substitua não quebre o comportamento esperado.
public class RepositorioProdutoEmMemoria : IRepositorioProduto
{
    private readonly List<Produto> _produtos = new List<Produto>();

    // Adiciona um novo produto ao repositório.
    public void AdicionarProduto(Produto produto)
    {
        _produtos.Add(produto);
    }

    // Remove um produto do repositório pelo ID.
    public void RemoverProduto(int produtoId)
    {
        var produto = _produtos.FirstOrDefault(p => p.Id == produtoId);
        if (produto != null)
        {
            _produtos.Remove(produto);
        }
    }

    // Retorna um produto específico pelo ID.
    public Produto ObterProdutoPorId(int produtoId)
    {
        return _produtos.FirstOrDefault(p => p.Id == produtoId);
    }

    // Retorna todos os produtos do repositório.
    public List<Produto> ObterTodosProdutos()
    {
        return _produtos;
    }
}

// Princípio da Inversão de Dependência (DIP)
// A classe ProdutoServicoGerenciamento depende de abstrações (interfaces), não de implementações concretas.
// Isso permite que diferentes repositórios possam ser usados sem modificar esta classe.
public class ProdutoServicoGerenciamento
{
    private readonly IRepositorioProduto _repositorioProduto;

    public ProdutoServicoGerenciamento(IRepositorioProduto repositorioProduto)
    {
        _repositorioProduto = repositorioProduto;
    }

    // Cadastra um novo produto através do repositório.
    public void CriarProduto(Produto produto)
    {
        _repositorioProduto.AdicionarProduto(produto);
    }

    // Exclui um produto do repositório pelo ID.
    public void ExcluirProduto(int produtoId)
    {
        _repositorioProduto.RemoverProduto(produtoId);
    }

    // Lista todos os produtos cadastrados.
    public void ListarProdutos()
    {
        var produtos = _repositorioProduto.ObterTodosProdutos();
        if (produtos.Count == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
        }
        else
        {
            Console.WriteLine("Produtos cadastrados:");
            foreach (var produto in produtos)
            {
                Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}, Preço: {produto.Preco:C}");
            }
        }
    }
}

