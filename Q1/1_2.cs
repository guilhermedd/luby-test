using System;

static float? CalcularPremio(int value, string type, float? mult)
{
    if (mult.HasValue) {
        if (mult < 0) {
            Console.WriteLine("Multiplier can't be a negative number.");
            return -1.0f;
        }
        return value * mult;
    }

    if (value < 0) {
        Console.WriteLine("Prize can't be a negative number.");
        return -1.0f;
    }

    switch(type) {
        case "basic":
            return value;
        case "vip":
            return value * 1.2f;
        case "premium":
            return value * 1.5f;
        case "deluxe":
            return value * 1.8f;
        case "special":
            return value * 2.0f;
        default:
            Console.WriteLine("Invalid prize type.");
            return -1.0f;
    }
}


Console.Write("Enter a number to calculate the total value: ");
int number = int.Parse(Console.ReadLine());

Console.Write("Enter a type to calculate the prize: ");
string type = Console.ReadLine();

Console.Write("Enter a multiplication value: ");
string arg = Console.ReadLine();
float? mult = (arg == "null")? null : int.Parse(arg);

float? result = CalcularPremio(number, type, mult);

if (result != -1) {
    Console.WriteLine($"The total value is {result:0.00}");
} 