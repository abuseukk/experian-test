using System.Globalization;

decimal productPrice = 0;
decimal customerAmount = 0;

Console.WriteLine("Hello, Customer!");

Console.Write("Enter your product price: ");
productPrice = GetConsoleDecimalInput();
Console.Write("Enter your amount: ");
customerAmount = GetConsoleDecimalInput();
Console.WriteLine("Your change is:");

var newValue = customerAmount - productPrice;

var strategy = new UKMoneyStrategy();
var changeCommand = new CalculateChangeCommand();

var money = strategy.GetMoneyDictionary();

var changeResult =changeCommand.Calculate(newValue, strategy);

foreach (var change in changeResult)
{
    Console.WriteLine($"{change.Item2} x {money[change.Item1]}");
}

decimal GetConsoleDecimalInput()
{
    double value = 0;
    bool valueValid = false;
    while (!valueValid)
    {
        try
        {
            string? input = Console.ReadLine();
            Console.WriteLine($"You entered: {input}");
            if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out value))
            {
                if(value > 0.01)
                {
                    value = Math.Round(value, 2); //we can check for the input but better to round
                    valueValid = true;
                } else
                {
                    Console.WriteLine("Value should be above 0.");
                }
            }
            else
            {
                Console.WriteLine("Invalid format. Expect 0,00");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    return Convert.ToDecimal(value);
}