using System;

namespace CandyCrush
{
    public class SpecialCandy : CandyBase
    {
        public SpecialCandy(CandyType type) : base(type) { }

        public override void Print()
        {
            Console.Write("S"); // Represents special candy
        }

        public override bool IsMatch(ICandy otherTypeCandy)
        {
            if (otherTypeCandy is NormalCandy normalCandy)
            {
                return normalCandy.Type == Type;
            }
            else if (otherTypeCandy is SpecialCandy specialCandy)
            {
                return specialCandy.Type == Type;
            }

            return false;
        }

        public override void Remove(Player player)
        {
            Console.Write(" ");
            player.IncreaseScore(30); // Increase score for each removed special candy
        }
    }
}
