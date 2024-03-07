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
            return other.IsMatch(this);
        }

        public override void Remove(Player player)
        {
            Console.Write(" "); // You can customize this based on your game logic for special candies
            player.IncreaseScore(20); // Increase score for each removed special candy
        }
    }
}
