using System;

static int ContarNumerosPrimos(int n)
{
    if (n < 0)
    {
        Console.WriteLine("Prime numbers are not defined for negative numbers.");
        return -1;
    }

    int count = 0;

    for (int i = 2; i <= n; i++)
    {
        bool isPrime = true;

        for (int j = 2; j < i; j++)
        {
            if (i % j == 0)
            {
                isPrime = false;
                break;
            }
        }

        if (isPrime)
        {
            count++;
        }
    }

    return count;
}


Console.Write("Enter a number to calculate how many prime numbers are there: ");
int number = int.Parse(Console.ReadLine());

long result = ContarNumerosPrimos(number);

Console.WriteLine($"There a {result} prime numbers");