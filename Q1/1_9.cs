using System;

static int[][] TransformarEmMatriz(string input)
{
    string[] numbers = input.Split(',');
    int[][] matriz = new int[numbers.Length / 2][];

    for (int i = 0, j = 0; i < numbers.Length; i += 2, j++)
    {
        int num1 = int.Parse(numbers[i]);
        int num2 = (i + 1 < numbers.Length) ? int.Parse(numbers[i + 1]) : 0;

        matriz[j] = new int[] { num1, num2 };
    }

    return matriz;
}

Console.Write("Enter the numbers (separated by ','): ");
string input = Console.ReadLine();
int[][] result = TransformarEmMatriz(input);

// Print the result
Console.Write("Matriz: {");
for (int i = 0; i < result.Length; i++)
{
    Console.Write("{" + string.Join(", ", result[i]) + "}");
    if (i < result.Length - 1)
        Console.Write(", ");
}
Console.WriteLine("}");