using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyCrush
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter player name: ");
            string playerName = Console.ReadLine();

            CandyCrushGame candyCrushGame = new CandyCrushGame(rows: 5, cols: 5, playerName);
            candyCrushGame.Play();
        }
    }
}
