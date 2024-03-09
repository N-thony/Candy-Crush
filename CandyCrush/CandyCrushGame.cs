using System;
using System.Collections.Generic;

namespace CandyCrush
{
    public class CandyCrushGame
    {
        private readonly GameBoard gameBoard;
        private readonly Player player;
        private List<Level> levels;
        private int currentLevelIndex;

        public CandyCrushGame(int rows, int cols, string playerName)
        {
            gameBoard = new GameBoard(rows, cols);
            player = new Player(playerName);
            InitializeLevels();
        }

        private void InitializeLevels()
        {
            levels = new List<Level>{
                     new Level(targetScore: 100, movesAllowed: 20),
                     new Level(targetScore: 150, movesAllowed: 25),
            };
            currentLevelIndex = 0;
        }

        public void Play()
        {
            int movesLeft = levels[currentLevelIndex].MovesAllowed;

            while (movesLeft > 0)
            {
                Console.Clear();
                gameBoard.PrintBoard();

                Console.WriteLine($"{player.Name}'s Score: {player.Score}");
                Console.WriteLine($"Level: {currentLevelIndex + 1}");
                Console.WriteLine($"Target Score: {levels[currentLevelIndex].TargetScore}");
                Console.WriteLine($"Moves Left: {movesLeft}");
                Console.WriteLine("Enter two candies positions to swap (e.g., A1B2):");
                string input = Console.ReadLine();

                if (input.Length == 4)
                {
                    
                    int row1 = int.Parse(input[1].ToString()) - 1;
                    int col1 = char.ToUpper(input[0]) - 'A';

                    int row2 = int.Parse(input[3].ToString()) - 1;
                    int col2 = char.ToUpper(input[2]) - 'A';

                    gameBoard.SwapCandies(row1, col1, row2, col2);

                    if (gameBoard.IsMatch())
                    {
                        Console.WriteLine("Match found!");

                        int matchedCandiesCount = DetectMatches();
                        if (matchedCandiesCount > 0)
                        {
                            bool isHorizontalMatch = true;
                            gameBoard.RemoveMatchedCandies(row1, col1, matchedCandiesCount, isHorizontalMatch, player);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No match found. Try again.");
                        gameBoard.SwapCandies(row1 , col1, row2 , col2);
                    }

                    movesLeft--;

                    // Check for level completion
                    if (player.Score >= levels[currentLevelIndex].TargetScore)
                    {
                        Console.WriteLine($"Level {currentLevelIndex + 1} completed!");
                        currentLevelIndex++;

                        if (currentLevelIndex < levels.Count)
                        {
                            Console.WriteLine($"Moving to Level {currentLevelIndex + 1}");
                            gameBoard.ResetBoard();
                        }
                        else
                        {
                            Console.WriteLine("Congratulations! You completed all levels.");
                            break;
                        }
                    }

                    // Check for game-over condition
                    if (levels[currentLevelIndex].MovesAllowed == 0)
                    {
                        Console.WriteLine("Game over! No moves left.");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter two candies positions.");
                }

                Console.ReadKey();
            }
        }

        private int DetectMatches()
        {
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
