using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyCrush
{
    public class NormalCandy : CandyBase
    {
        public NormalCandy(CandyType type) : base(type) { }

        public override void Print()
        {
            Console.Write(Type.ToString()[0]);
        }

        public override bool IsMatch(ICandy other)
        {
            if (other is NormalCandy normalCandy)
            {
                return normalCandy.Type == Type;
            }
            else if (other is SpecialCandy specialCandy)
            {
                // Add logic for matching with special candies
                return specialCandy.Type == Type;
            }

            return false;
        }
        public override void Remove(Player player)
        {
            Console.Write(" ");
            player.IncreaseScore(5); // Increase score for each removed normal candy
        }
    }
}
