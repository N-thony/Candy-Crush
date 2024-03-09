using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace CandyCrush
{
    public class Level
    {
        public int TargetScore { get; }
        public int MovesAllowed { get; }

        public Level(int targetScore, int movesAllowed)
        {
            TargetScore = targetScore;
            MovesAllowed = movesAllowed;
        }
    }
}
