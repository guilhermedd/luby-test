using System;
using System.Globalization;

static decimal CalcularValorComDescontoFormatado(decimal valor, float desconto)
{
    if (valor < 0)
    {
        Console.WriteLine("Value can't be a negative number.");
        return -1.0m;
    }

    if (desconto < 0 || desconto > 100)
    {
        Console.WriteLine("Discount can't be a negative number or greater than 100.");
        return -1.0m;
    }

    decimal result = valor - (valor * (decimal)(desconto / 100));
    return result;
}

Console.Write("Enter the value: ");
string valueToTreat = Console.ReadLine();
string valueTreated = valueToTreat
    .Replace("R$", "")
    .Replace(".", "")
    .Replace(",", ".")
    .Trim();

if (decimal.TryParse(valueTreated, NumberStyles.Float, CultureInfo.InvariantCulture, out decimal value))
{
    Console.WriteLine($"Parsed value: {value}");
}
else
{
    Console.WriteLine("Invalid input format for value.");
}

Console.Write("Enter the discount: ");
string discountToTreat = Console.ReadLine();
string discountTreated = discountToTreat
    .Replace("%", "")
    .Replace(",", ".")
    .Trim();

if (float.TryParse(discountTreated, NumberStyles.Float, CultureInfo.InvariantCulture, out float discount))
{
    Console.WriteLine($"Parsed discount: {discount}");
}
else
{
    Console.WriteLine("Invalid input format for discount.");
}

decimal result = CalcularValorComDescontoFormatado(value, discount);

Console.WriteLine($"The result after applying the discount is: R${result.ToString("#,##0.00", CultureInfo.InvariantCulture)}");