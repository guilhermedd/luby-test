using System;

static long CalculateFactorial(int n)
{
    if (n < 0)
    {
        Console.WriteLine("Factorial is not defined for negative numbers.");
        return -1;
    }

    if (n == 0)
    {
        return 1;
    }

    long factorial = 1;

    for (int i = 1; i <= n; i++)
    {
        factorial *= i;
    }

    return factorial;
}


Console.Write("Enter a number to calculate the factorial: ");
int number = int.Parse(Console.ReadLine());

long result = CalculateFactorial(number);

Console.WriteLine($"The factorial of {number} is {result}");