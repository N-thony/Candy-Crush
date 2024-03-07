namespace CandyCrush
{
    public interface ICandy
    {
        void Print();
        bool IsMatch(ICandy other);
        void Remove(Player player);
    }
}
