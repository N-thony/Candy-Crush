public enum CandyType
{
    Red,
    Green,
    Blue,
    Yellow,
    Purple
}

public class Candy
{
    public CandyType Type { get; }

    public Candy(CandyType type)
    {
        Type = type;
    }

    public override string ToString()
    {
        return Type.ToString()[0].ToString();
    }
}