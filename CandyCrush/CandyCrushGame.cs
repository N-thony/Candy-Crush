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
            int movesLeft = 20;  // Set the desired number of moves

            while (movesLeft > 0)
            {
                Console.Clear();
                gameBoard.PrintBoard();

                Console.WriteLine($"{player.Name}'s Score: {player.Score}");
                Console.WriteLine($"Moves Left: {movesLeft}");
                Console.WriteLine("Enter two candies positions to swap (e.g., A1B2):");
                string input = Console.ReadLine();

                if (input.Length == 4)
                {
                    char row1 = input[0];
                    int col1 = int.Parse(input[1].ToString()) - 1;

                    char row2 = input[2];
                    int col2 = int.Parse(input[3].ToString()) - 1;

                    gameBoard.SwapCandies(row1 - 'A', col1, row2 - 'A', col2);

                    if (gameBoard.IsMatch())
                    {
                        Console.WriteLine("Match found!");

                        int matchedCandiesCount = DetectMatches();
                        if (matchedCandiesCount > 0)
                        {
                            bool isHorizontalMatch = true;  // Adjust this based on your matching logic
                            gameBoard.RemoveMatchedCandies(row1 - 'A', col1, matchedCandiesCount, isHorizontalMatch, player);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No match found. Try again.");
                        gameBoard.SwapCandies(row1 - 'A', col1, row2 - 'A', col2);
                    }

                    movesLeft--;

                    // Check for game-over condition
                    if (movesLeft == 0)
                    {
                        Console.WriteLine("Game over! No moves left.");
                        // Add any additional game-over logic here
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter two candies positions.");
                }

                // Add any other game logic here

                // Uncomment the following line to pause for better readability during testing
                Console.ReadKey();
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
