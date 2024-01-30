using System;

static string[] BuscarPessoa(string[] vetor, string termoBusca)
{
    string[] resultado = vetor
        .Where(nome => nome.Contains(termoBusca, StringComparison.OrdinalIgnoreCase))
        .ToArray();

    return resultado;
}

string[] vetor = new string[] {
    "John Doe",
    "Jane Doe",
    "Alice Jones",
    "Bobby Louis",
    "Lisa Romero"
};

Console.Write("Enter a name to search: ");
string termoBusca = Console.ReadLine();

string[] resultado = BuscarPessoa(vetor, termoBusca);

foreach (string nome in resultado)
{
    Console.WriteLine(nome);
}
