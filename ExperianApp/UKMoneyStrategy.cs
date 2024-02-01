public class UKMoneyStrategy : IMoneyStrategy
{
    private Dictionary<decimal, string> money = new Dictionary<decimal, string>() {
    { 0.01m, "1p" },
    { 0.02m, "2p" },
    { 0.05m, "5p" },
    { 0.10m, "10p" },
    { 0.20m, "20p" },
    { 0.50m, "50p" },
    { 1m, "1£" },
    { 2m, "2£" },
    { 5m, "5£" },
    { 10m, "10£" },
    { 20m, "20£" },
    { 50m, "50£" },
    };

    private decimal[] moneyArray;

    public UKMoneyStrategy()
    {
        moneyArray = money.Select(x => x.Key).OrderDescending().ToArray();
    }



    public Dictionary<decimal, string> GetMoneyDictionary()
    {
        return money;
    }

    public decimal[] GetMoneyOrderDesc()
    {
        return moneyArray;
    }
}
