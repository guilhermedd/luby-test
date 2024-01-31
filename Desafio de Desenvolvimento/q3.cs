using System;

class Produto
{
    public string Nome { get; set; }
    public double Preco { get; set; }
    public int Quantidade { get; set; }
    public int QuantidadeInicial { get; set; }
}

class VendingMachine
{
    public List<Produto> Estoque { get; set; }
    public double Vendas = 0;

    public VendingMachine()
    {
        Estoque = new List<Produto>
        {
            new Produto { Nome = "Coca-Cola", Preco = 5.00, Quantidade = 10, QuantidadeInicial = 10},
            new Produto { Nome = "Pepsi", Preco = 4.50, Quantidade = 10, QuantidadeInicial = 10  },
            new Produto { Nome = "Fanta", Preco = 4.00, Quantidade = 10, QuantidadeInicial = 10  },
            new Produto { Nome = "Guaraná", Preco = 3.50, Quantidade = 10, QuantidadeInicial = 10  },
            new Produto { Nome = "Sprite", Preco = 3.00, Quantidade = 10, QuantidadeInicial = 10  }
        };
    }

    public void MostrarEstoque()
    {
        foreach (var produto in Estoque)
        {
            Console.WriteLine($"{produto.Nome} - R$ {produto.Preco:F2} | {produto.Quantidade} item(s)");
        }
    }

    public void ComprarProduto()
    {
        MostrarEstoque();

        Console.Write("Digite o nome do produto: ");
        string nome = Console.ReadLine();

        string[] partesNome = nome.Split('-');
        string nome_produto = "";

        // Colocar a primeira letra de cada nome como Maiúscula
        if (partesNome.Length > 1)
        {
            string primeiraPalavra = partesNome[0];
            string segundaPalavra = partesNome[1];

            char primeiraLetraNome1 = char.ToUpper(primeiraPalavra[0]);
            char primeiraLetraNome2 = char.ToUpper(segundaPalavra[0]);

            nome_produto = $"{primeiraLetraNome1}{primeiraPalavra.Substring(1)}-{primeiraLetraNome2}{segundaPalavra.Substring(1)}";
        }
        else
        {
            char primeiraLetra = char.ToUpper(nome[0]);
            nome_produto = $"{primeiraLetra}{nome.Substring(1)}";
        }

        var produto = Estoque.FirstOrDefault(x => x.Nome == nome_produto); // Busca o produto pelo nome

        if (produto == null)
        {
            Console.WriteLine("Produto não encontrado");
            return;
        }

        if (produto.Quantidade == 0)
        {
            Console.WriteLine("Não temos mais desse produto em estoque");
            return;
        }

        Console.Write("Digite quanto voce vai pagar: ");
        double valorPago = float.Parse(Console.ReadLine());

        // Compra do produto
        while (valorPago < produto.Preco)
        {
            Console.WriteLine($"Valor insuficiente...\nAdicione mais R${produto.Preco - valorPago:F2} Ou digite 0 para cancelar");

            double pago = double.Parse(Console.ReadLine());

            while (pago < 0)
            {
                Console.WriteLine("Valor inválido, tente novamente");
                pago = double.Parse(Console.ReadLine());
            }

            if (pago == 0)
            {
                Console.WriteLine("Compra cancelada");
                return;
            }

            valorPago += pago;
        }

        double troco = valorPago - produto.Preco;

        Console.WriteLine($"Troco: R$ {troco:F2}");

        produto.Quantidade--;

        Vendas += produto.Preco;

        Console.WriteLine($"Produto {produto.Nome} comprado com sucesso");
    }

    public void MostrarVendas()
    {
        foreach (var produto in Estoque)
        {
            Console.WriteLine($"{produto.Nome} - {produto.QuantidadeInicial - produto.Quantidade} unidade(s) vendida(s) | Total em reais vendidos: R${(produto.QuantidadeInicial - produto.Quantidade) * produto.Preco:F2}");
        }
        Console.WriteLine($"Preço total de vendas: R$ {Vendas:F2}");
    }
}

/////////////////// Program.cs //////////////////////  

VendingMachine vendingMachine = new VendingMachine();

bool loop = true;
while (loop)
{

    Console.Clear();
    Console.WriteLine("Bem vindo ao sistema de Vending Machine");
    Console.WriteLine("1. Mostrar estoque de produtos");
    Console.WriteLine("2. Comprar um produto");
    Console.WriteLine("3. Mostrar total de vendas");
    Console.WriteLine("4. Sair");

    Console.Write("Escolha uma opção: ");
    string escolha = Console.ReadLine();
    Console.Clear();

    switch (escolha)
    {
        case "1":
            vendingMachine.MostrarEstoque();
            break;
        case "2":
            vendingMachine.ComprarProduto();
            break;
        case "3":
            vendingMachine.MostrarVendas();
            break;
        case "4":
            Console.WriteLine("Obrigado por usar o sistema de Vending Machine!");
            loop = false;
            return;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
    Console.WriteLine("Clique em qualquer tecla para continuar...");
    Console.ReadKey();
}