using System;

static int[] ObterElementosFaltantes(string input1, string input2)
{
    string[] numbers1 = input1.Split(',');
    string[] numbers2 = input2.Split(',');

    if (numbers1 == numbers2)
    {
        return new int[] { };
    }

    List<int> elementosFaltantesList = new List<int>();

    for (int i = 0; i < numbers1.Length; i++)
    {
        if (!numbers2.Contains(numbers1[i]))
        {
            elementosFaltantesList.Add(int.Parse(numbers1[i]));
        }
    }

    for (int i = 0; i < numbers2.Length; i++)
    {
        if (!numbers1.Contains(numbers2[i]))
        {
            elementosFaltantesList.Add(int.Parse(numbers2[i]));
        }
    }

    return elementosFaltantesList.ToArray();
}

Console.Write("Enter the numbers to input 1(separated by ','): ");
string input1 = Console.ReadLine();

Console.Write("Enter the numbers to input 2(separated by ','): ");
string input2 = Console.ReadLine();

// Print the result
int[] result = ObterElementosFaltantes(input1, input2);

if (result.Length == 0)
{
    Console.WriteLine("Não há elementos faltantes");
    return;
}
Console.Write("Faltantes: {");
for (int i = 0; i < result.Length; i++)
{
    Console.Write(result[i]);
    if (i < result.Length - 1)
        Console.Write(", ");
}
Console.WriteLine("}");