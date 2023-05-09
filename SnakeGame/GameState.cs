using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		private int score;
		private bool gameOver;
		private List<Position> snake;
		private Food food;
		private int numRows;
		private int numCols;
		public Direction Direction { get; set; }
		public Food Food { get => food; }
		public int Score { get => score; }
		public bool GameOver { get => gameOver; }

		// Constructor
		public GameState(int numRows, int numCols)
		{
			this.numRows = numRows;
			this.numCols = numCols;

			// Initialize the score and game over state
			score = 0;
			gameOver = false;

			// Initialize the positions of the snake and food
			snake = new List<Position> { new Position(numRows / 2, numCols / 2) };
			SpawnFood();
		}

		// Update the game state when the snake moves
		public void MoveSnake(Direction direction)
		{
			// Get the current head position of the snake
			Position head = snake[0];

			// Calculate the new head position based on the direction
			int row = head.Row;
			int col = head.Column;

			switch (direction)
			{
				case Direction.Up:
					row--;
					break;
				case Direction.Down:
					row++;
					break;
				case Direction.Left:
					col--;
					break;
				case Direction.Right:
					col++;
					break;
				default:
					break;
			}

			Position newHead = new Position(row, col);

			// Check if the new head position is valid (not out of bounds)
			if (row < 0 || row >= numRows || col < 0 || col >= numCols)
			{
				// Snake collided with the walls
				gameOver = true;
				return;
			}

			// Check if the new head position collides with the snake's body
			if (snake.Contains(newHead))
			{
				// Snake collided with itself
				gameOver = true;
				return;
			}

			// Add the new head to the snake's body
			snake.Insert(0, newHead);

			// Check if the new head position contains food
			if (newHead.Equals(food))
			{
				// Snake ate the food
				score++;
				SpawnFood();
			}
			else
			{
				// Remove the tail of the snake
				snake.RemoveAt(snake.Count - 1);
			}
		}

		private void SpawnFood()
		{
			Random random = new Random();
			Position newFoodPosition;

			do
			{
				newFoodPosition = new Position(random.Next(0, numRows), random.Next(0, numCols));
			} while (snake.Contains(newFoodPosition));

			food = new Food(newFoodPosition.Row, newFoodPosition.Column);
		}
	}
}
