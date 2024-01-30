using System;

static int[] ObterElementosPares(string elementos)
{
    string[] elementosArray = elementos.Split(',');
    List<int> elementosParesList = new List<int>();

    for(int i = 0; i < elementosArray.Length; i++)
    {
        if (int.TryParse(elementosArray[i], out int parsedNumber) && parsedNumber % 2 == 0)
        {
            elementosParesList.Add(parsedNumber);
        }
    }
    return elementosParesList.ToArray();
}


Console.Write("Enter the start date (separado por ','): ");
string elementos = Console.ReadLine();

int[] result = ObterElementosPares(elementos);
Console.Write("{");
for(int i = 0; i < result.Length; i++)
{
    if (i == result.Length - 1)
    {
        Console.Write($"{result[i]}");
        break;
    }
    Console.Write($"{result[i]}, ");
}
Console.Write("}");
