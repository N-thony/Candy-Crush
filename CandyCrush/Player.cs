using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyCrush
{
    public class Player
    {
        public string Name { get; private set; }
        public int Score { get; private set; }

        public Player(string name)
        {
            Name = name;
            Score = 0;
        }

        public void IncreaseScore(int points)
        {
            Score += points;
        }
    }
}
