using System;

static int CalcularDiferencaData(string dataInicio, string dataFim)
{
    DateTime inicio = DateTime.ParseExact(dataInicio, "ddMMyyyy", null);
    DateTime fim = DateTime.ParseExact(dataFim, "ddMMyyyy", null);

    int diferencaDias = (int)(fim - inicio).TotalDays;

    return diferencaDias;
}

Console.Write("Enter the start date: ");
string dataInicio = Console.ReadLine();
Console.Write("Enter the end date: ");
string dataFim = Console.ReadLine();
int result = CalcularDiferencaData(dataInicio, dataFim);
Console.WriteLine(result);