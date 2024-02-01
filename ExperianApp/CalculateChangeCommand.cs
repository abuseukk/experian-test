public class CalculateChangeCommand : ICalculateCommand
{
    public List<(decimal, int)> Calculate(decimal amount, IMoneyStrategy strategy)
    {
        var result = new List<(decimal , int)>();
        var newValue = amount;

        var moneyArray = strategy.GetMoneyOrderDesc();
        for (int i = 0; i < moneyArray.Length; i++)
        {
            var divisor = moneyArray[i];
            if (newValue < divisor) continue;

            int count = (int)(newValue / divisor);

            result.Add((divisor, count));

            newValue = newValue % divisor;
        }

        return result;
    }
}
