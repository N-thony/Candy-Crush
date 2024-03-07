using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyCrush
{
    public class SpecialCandy : CandyBase
    {
        public SpecialCandy(CandyType type) : base(type) { }

        public override void Print()
        {
            Console.Write("S"); // Special candies can be represented differently
        }

        public override bool IsMatch(ICandy other)
        {
            if (other is NormalCandy normalCandy)
            {
                // Add logic for matching with normal candies
                return normalCandy.Type == Type;
            }
            else if (other is SpecialCandy specialCandy)
            {
                // Add logic for matching with other special candies
                return specialCandy.Type == Type;
            }

            return false;
        }

        public override void Remove(Player player)
        {
            Console.Write(" ");
            player.IncreaseScore(10); // Increase score for each removed special candy
        }
    }
}
