public interface ICalculateCommand
{
    List<(decimal, int)> Calculate(decimal amount, IMoneyStrategy strategy);
}
