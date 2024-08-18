class Program
{
    static void Main(string[] args)
    {
        // Princípio da Inversão de Dependência (DIP)
        // Aqui estamos injetando a dependência RepositorioProdutoEmMemoria na classe ProdutoServicoGerenciamento.
        IRepositorioProduto repositorioProduto = new RepositorioProdutoEmMemoria();
        ProdutoServicoGerenciamento servicoGerenciamento = new ProdutoServicoGerenciamento(repositorioProduto);

        bool sair = false;

        // Laço principal para interação com o usuário.
        while (!sair)
        {
            // Exibe as opções disponíveis para o usuário.
            Console.WriteLine("\nEscolha uma opção:");
            Console.WriteLine("1. Cadastrar Produto");
            Console.WriteLine("2. Listar Produtos");
            Console.WriteLine("3. Excluir Produto");
            Console.WriteLine("4. Sair");
            Console.Write("Opção: ");
            string opcao = Console.ReadLine();

            // Processa a opção escolhida pelo usuário.
            switch (opcao)
            {
                case "1":
                    // Coleta os dados do produto a ser cadastrado.
                    Console.Write("Digite o ID do produto: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Digite o nome do produto: ");
                    string nome = Console.ReadLine();
                    Console.Write("Digite o preço do produto: ");
                    decimal preco = decimal.Parse(Console.ReadLine());

                    var produto = new Produto { Id = id, Nome = nome, Preco = preco };
                    servicoGerenciamento.CriarProduto(produto);
                    Console.WriteLine("Produto cadastrado com sucesso!");
                    break;

                case "2":
                    // Lista todos os produtos cadastrados.
                    servicoGerenciamento.ListarProdutos();
                    break;

                case "3":
                    // Coleta o ID do produto a ser excluído.
                    Console.Write("Digite o ID do produto a ser excluído: ");
                    int idExcluir = int.Parse(Console.ReadLine());
                    servicoGerenciamento.ExcluirProduto(idExcluir);
                    Console.WriteLine("Produto excluído com sucesso!");
                    break;

                case "4":
                    // Encerra o programa.
                    sair = true;
                    Console.WriteLine("Saindo do programa...");
                    break;

                default:
                    // Trata a escolha inválida.
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }
    }
}