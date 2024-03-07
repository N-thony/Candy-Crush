namespace CandyCrush
{
    public abstract class CandyBase : ICandy
    {
        public CandyType Type { get; protected set; }

        protected CandyBase(CandyType type)
        {
            Type = type;
        }

        public abstract void Print();
        public abstract bool IsMatch(ICandy other);
        public abstract void Remove(Player player);
    }
}
