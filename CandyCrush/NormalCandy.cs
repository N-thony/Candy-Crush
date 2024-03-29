﻿using System;
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
        public override bool IsMatch(ICandy otherTypeCandy)
        {
            if (otherTypeCandy is NormalCandy normalCandy)
            {
                return normalCandy.Type == Type;
            }

            return false;
        }

        public override void Remove(Player player)
        {
            Console.Write(" ");
            player.IncreaseScore(10); // Increase score for each removed normal candy
        }
    }
}
