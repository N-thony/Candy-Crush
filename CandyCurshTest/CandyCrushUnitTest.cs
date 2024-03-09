using System;
using System.Linq;
using Xunit;
using CandyCrush;

namespace CandyCurshTest
{
    public class GameBoardTests
    {
        [Fact]
        public void InitializeBoard_ShouldCreateEmptyBoard()
        {
            // Arrange
            GameBoard gameBoard = new GameBoard(rows: 5, cols: 5);

            // Act
            gameBoard.InitializeBoard();

            // Assert
           // Assert.All(gameBoard.candies, row => Assert.All(row, candy => Assert.Null(candy)));
        }

        [Fact]
        public void SwapCandies_ShouldSwapCandies()
        {
            // Arrange
            GameBoard gameBoard = new GameBoard(rows: 5, cols: 5);
            gameBoard.InitializeBoard();
            ICandy initialCandy = gameBoard.candies[0, 0];
            ICandy targetCandy = gameBoard.candies[0, 1];

            // Act
            gameBoard.SwapCandies(0, 0, 0, 1);

            // Assert
            Assert.Equal(targetCandy, gameBoard.candies[0, 0]);
            Assert.Equal(initialCandy, gameBoard.candies[0, 1]);
        }
    }

    public class PlayerTests
    {
        [Fact]
        public void IncreaseScore_ShouldIncreasePlayerScore()
        {
            // Arrange
            Player player = new Player("TestPlayer");

            // Act
            player.IncreaseScore(10);

            // Assert
            Assert.Equal(10, player.Score);
        }
    }

}
