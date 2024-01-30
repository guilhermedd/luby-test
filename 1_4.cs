using System;

static long CalcularVogais(string str)
{
    int count = 0;

    foreach (char c in str.ToLower())
    {   
        if ("aeiou".Contains(c))
        {
            count++;
        }
    }

    return count;
}

Console.Write("Write a sentence: ");

long result = CalcularVogais(Console.ReadLine());

Console.WriteLine($"There are {result} vowels");