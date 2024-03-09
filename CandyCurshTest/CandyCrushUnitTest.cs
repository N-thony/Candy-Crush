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
            Assert.All(gameBoard.candies.Cast<ICandy>(), candy => Assert.NotNull(candy));
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

        [Fact]
        public void CheckForMatch_ShouldReturnTrue_HorizontalMatch()
        {
            // Arrange
            const int rows = 5;
            const int cols = 5;
            GameBoard gameBoard = new GameBoard(rows, cols);
            gameBoard.candies[0, 0] = new NormalCandy(CandyType.Red);
            gameBoard.candies[0, 1] = new NormalCandy(CandyType.Red);
            gameBoard.candies[0, 2] = new NormalCandy(CandyType.Red);

            // Act
            bool result = gameBoard.CheckForMatch(0, 0);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckForMatch_ShouldReturnTrue_VerticalMatch()
        {
            // Arrange
            const int rows = 5;
            const int cols = 5;
            GameBoard gameBoard = new GameBoard(rows, cols);
            gameBoard.candies[0, 0] = new NormalCandy(CandyType.Blue);
            gameBoard.candies[1, 0] = new NormalCandy(CandyType.Blue);
            gameBoard.candies[2, 0] = new NormalCandy(CandyType.Blue);

            // Act
            bool result = gameBoard.CheckForMatch(0, 0);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckForMatch_ShouldReturnFalse_NoMatch()
        {
            // Arrange
            const int rows = 5;
            const int cols = 5;
            GameBoard gameBoard = new GameBoard(rows, cols);
            gameBoard.candies[0, 0] = new NormalCandy(CandyType.Green);
            gameBoard.candies[0, 1] = new NormalCandy(CandyType.Blue);
            gameBoard.candies[0, 2] = new NormalCandy(CandyType.Red);

            // Act
            bool result = gameBoard.CheckForMatch(0, 0);

            // Assert
            Assert.False(result);
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
