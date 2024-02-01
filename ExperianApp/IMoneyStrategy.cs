public interface IMoneyStrategy
{
    Dictionary<decimal, string> GetMoneyDictionary();

    decimal[] GetMoneyOrderDesc();
}
