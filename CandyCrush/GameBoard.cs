using System;
namespace CandyCrush
{
    public class GameBoard
    {
        public readonly ICandy[,] candies;
        private readonly int rows;
        private readonly int cols;

        public int Rows => rows;
        public int Cols => cols; 

        public GameBoard(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            candies = new ICandy[rows, cols];
            InitializeBoard();
        }

        public void InitializeBoard()
        {
            Random random = new Random();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    ICandy candy = random.Next(10) < 2 // 20% chance to create a special candy
                        ? (ICandy)new SpecialCandy((CandyType)random.Next(Enum.GetNames(typeof(CandyType)).Length))
                        : new NormalCandy((CandyType)random.Next(Enum.GetNames(typeof(CandyType)).Length));

                    candies[row, col] = candy;
                }
            }
        }

        public void ResetBoard()
        {
            InitializeBoard();
        }

        public void PrintBoard()
        {
            Console.Write("   "); // Add spaces for better alignment before the column headers

            // Display column headers (letters) with separation
            for (int col = 0; col < Cols; col++)
            {
                Console.Write((char)('A' + col) + "  ");
            }

            Console.WriteLine(); // Move to the next line for the row numbers

            // Display separator line
            Console.Write("  +");
            for (int col = 0; col < Cols; col++)
            {
                Console.Write("---+");
            }

            Console.WriteLine(); // Move to the next line after the separator line

            // Display rows with row numbers
            for (int row = 0; row < Rows; row++)
            {
                Console.Write((row + 1) + " |"); // Display row number and separator

                for (int col = 0; col < Cols; col++)
                {
                    candies[row, col]?.Print(); // Display candy or empty space
                    Console.Write(" |");
                }

                Console.WriteLine(); // Move to the next line after each row

                // Display separator line after each row
                Console.Write("  +");
                for (int col = 0; col < Cols; col++)
                {
                    Console.Write("---+");
                }

                Console.WriteLine(); // Move to the next line after the separator line
            }
        }

        public void SwapCandies(int row1, int col1, int row2, int col2)
        {
            try {
                ICandy temp = candies[row1, col1];
                candies[row1, col1] = candies[row2, col2];
                candies[row2, col2] = temp;
            } catch(Exception ex) { Console.WriteLine(ex.Message); }
        }

        public bool IsMatch()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (CheckForMatch(row, col))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CheckForMatch(int row, int col)
        {
            ICandy currentCandy = candies[row, col];
            if (currentCandy != null)
            {
                // Check horizontally
                if (col < cols - 2 && currentCandy.IsMatch(candies[row, col + 1]) && currentCandy.IsMatch(candies[row, col + 2]))
                {
                    return true;
                }
                // Check vertically
                if (row < rows - 2 && currentCandy.IsMatch(candies[row + 1, col]) && currentCandy.IsMatch(candies[row + 2, col]))
                {
                    return true;
                }
            }
            return false;
        }

        public void RemoveMatchedCandies(int startRow, int startCol, int length, bool isHorizontal, Player player)
        {
            try {
                for (int i = 0; i < length; i++)
                {
                    ICandy candy = isHorizontal ? candies[startRow, startCol + i] : candies[startRow + i, startCol];
                    candy.Remove(player);
                    candies[startRow + i, startCol] = null;
                    // Shift candies down after removal
                    ShiftCandiesDown();

                    // Add new candies to fill the empty spaces
                    FillEmptySpaces();
                }
            } catch(Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        private void ShiftCandiesDown()
        {
            for (int col = 0; col < cols; col++)
            {
                int destinationRow = rows - 1;
                for (int row = rows - 1; row >= 0; row--)
                {
                    if (candies[row, col] != null)
                    {
                        candies[destinationRow, col] = candies[row, col];
                        destinationRow--;
                    }
                }
                // Fill empty spaces at the top with null
                for (int row = destinationRow; row >= 0; row--)
                {
                    candies[row, col] = null;
                }
            }
        }

        private void FillEmptySpaces()
        {
            Random random = new Random();

            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < rows; row++)
                {
                    if (candies[row, col] == null)
                    {
                        ICandy candy = random.Next(10) < 2
                            ? (ICandy)new SpecialCandy((CandyType)random.Next(Enum.GetNames(typeof(CandyType)).Length))
                            : new NormalCandy((CandyType)random.Next(Enum.GetNames(typeof(CandyType)).Length));

                        candies[row, col] = candy;
                    }
                }
            }
        }

    }
}