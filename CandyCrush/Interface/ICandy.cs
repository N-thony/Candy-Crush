namespace CandyCrush
{
    public interface ICandy
    {
        void Print();
        bool IsMatch(ICandy otherTypeCandy);
        void Remove(Player player);
    }
}
