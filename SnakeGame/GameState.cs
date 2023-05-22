using System;
using System.Drawing;

namespace SnakeGame
{
	public enum Direction
	{
		Up,
		Down,
		Left,
		Right
	}

	public class GameState
	{
		public Snake Snake { get; private set; }
		public Food Food { get; private set; }
		public bool GameOver { get; private set; }
		public Direction CurrentDirection { get; set; }
		private int numRows;
		private int numCols;
		private Random random;

		public GameState(int numRows, int numCols)
		{
			this.numRows = numRows;
			this.numCols = numCols;

			Snake = new Snake(numRows / 2, numCols / 2);
			random = new Random(); // Initialize the random object
			Food = GenerateNewFood();
			GameOver = false;
			CurrentDirection = Direction.Right;
		}


		public void MoveSnake(Direction direction)
		{
			// Check if the new direction is opposite to the current one
			if ((CurrentDirection == Direction.Up && direction == Direction.Down) ||
				(CurrentDirection == Direction.Down && direction == Direction.Up) ||
				(CurrentDirection == Direction.Left && direction == Direction.Right) ||
				(CurrentDirection == Direction.Right && direction == Direction.Left))
			{
				// If it is, don't change the direction
				direction = CurrentDirection;
			}

			CurrentDirection = direction;
			Snake.Move(direction);

			if (Snake.GetHead().X < 0 || Snake.GetHead().X >= numCols ||
				Snake.GetHead().Y < 0 || Snake.GetHead().Y >= numRows ||
				Snake.CollidesWithSelf())
			{
				GameOver = true;
				return;
			}

			if (Snake.CollidesWith(Food.Location))
			{
				Snake.Grow();
				Food = GenerateNewFood();
			}
		}


		private Food GenerateNewFood()
		{
			int row, column;

			do
			{
				row = random.Next(numRows);
				column = random.Next(numCols);
			} while (Snake.CollidesWith(new Point(column, row)));

			return new Food(numRows, numCols);
		}
	}
}