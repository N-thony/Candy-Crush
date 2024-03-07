using System;

namespace CandyCrush
{
    public class CandyCrushGame
    {
        private readonly GameBoard gameBoard;
        private readonly Player player;

        public CandyCrushGame(int rows, int cols, string playerName)
        {
            gameBoard = new GameBoard(rows, cols);
            player = new Player(playerName);
        }

        public void Play()
        {
            while (true)
            {
                Console.Clear();
                gameBoard.PrintBoard();

                Console.WriteLine($"{player.Name}'s Score: {player.Score}");
                Console.WriteLine("Enter row and column for the first candy (e.g., 1 2):");
                string[] input1 = Console.ReadLine().Split();
                int row1 = int.Parse(input1[0]) - 1;
                int col1 = int.Parse(input1[1]) - 1;

                Console.WriteLine("Enter row and column for the second candy (e.g., 2 2):");
                string[] input2 = Console.ReadLine().Split();
                int row2 = int.Parse(input2[0]) - 1;
                int col2 = int.Parse(input2[1]) - 1;

                gameBoard.SwapCandies(row1, col1, row2, col2);

                if (gameBoard.IsMatch())
                {
                    Console.WriteLine("Match found!");

                    // Detect and remove matches
                    int matchedCandiesCount = DetectMatches();
                    if (matchedCandiesCount > 0)
                    {
                        bool isHorizontalMatch = true;  // Adjust this based on your matching logic
                        gameBoard.RemoveMatchedCandies(row1, col1, matchedCandiesCount, isHorizontalMatch, player);
                    }
                }
                else
                {
                    Console.WriteLine("No match found. Try again.");
                    // Implement logic to swap candies back if there is no match
                    gameBoard.SwapCandies(row1, col1, row2, col2);
                }

                // Add game-over conditions or other game logic here
            }
        }

        private int DetectMatches()
        {
            // Implement your matching logic here
            // For simplicity, consider three consecutive candies of the same type as a match
            // You may want to add more sophisticated matching logic in a real game
            // Return the count of matched candies

            int matchedCandiesCount = 0;

            for (int row = 0; row < gameBoard.Rows; row++)
            {
                for (int col = 0; col < gameBoard.Cols; col++)
                {
                    if (gameBoard.CheckForMatch(row, col))
                    {
                        matchedCandiesCount++;
                    }
                }
            }

            return matchedCandiesCount;
        }
    }
}
