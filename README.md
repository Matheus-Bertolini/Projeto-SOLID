# Gerenciamento de Produtos - Aplicação Console

Este é um exemplo simples de uma aplicação de console para o gerenciamento de produtos, construída com base nos princípios de SOLID em C#. A aplicação permite que os usuários cadastrem, listem e excluam produtos por meio de um menu interativo.

## Funcionalidades

- **Cadastrar Produto:** O usuário pode adicionar um novo produto especificando um ID, nome e preço.
- **Listar Produtos:** Todos os produtos cadastrados são exibidos com ID, nome e preço.
- **Excluir Produto:** O usuário pode remover um produto do sistema informando o ID do produto.
- **Sair:** Encerra o programa.

## Princípios SOLID Aplicados

Este projeto foi desenvolvido seguindo os princípios de SOLID para garantir um código limpo, extensível e fácil de manter. Abaixo estão os princípios aplicados:

### 1. SRP (Princípio da Responsabilidade Única)
A classe `Produto` é responsável por representar os dados de um produto, mantendo assim uma única responsabilidade.

### 2. OCP (Princípio Aberto/Fechado)
A interface `IRepositorioProduto` define os métodos necessários para manipular um repositório de produtos. A interface está aberta para extensão, permitindo que novos tipos de repositórios sejam adicionados sem modificar o código existente.

### 3. LSP (Princípio da Substituição de Liskov)
A classe `RepositorioProdutoEmMemoria` implementa a interface `IRepositorioProduto`, o que permite que seja substituída por qualquer outra implementação sem quebrar a funcionalidade do sistema.

### 4. ISP (Princípio da Segregação de Interface)
Interfaces específicas e focadas, como `IRepositorioProduto`, são utilizadas para evitar que as classes dependam de métodos que não utilizam.

### 5. DIP (Princípio da Inversão de Dependência)
A classe `ProdutoServicoGerenciamento` depende da abstração `IRepositorioProduto`, e não de uma implementação concreta, o que facilita a troca de repositórios no futuro sem impacto no código do serviço.

## Como Executar

1. Clone este repositório para o seu ambiente local:

    ```bash
    git clone https://github.com/Matheus-Bertolini/Projeto-SOLID.git
    ```

2. Abra o projeto em seu ambiente de desenvolvimento preferido.

3. Compile e execute o projeto.

4. Siga as instruções no console para cadastrar, listar ou excluir produtos.

## Requisitos

- .NET SDK 5.0 ou superior.

