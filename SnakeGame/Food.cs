using System;

namespace SnakeGame
{
	public class Food
	{
		public int Row { get; private set; }
		public int Column { get; private set; }

		public Position Location => new Position(Row, Column);

		private readonly int numRows;
		private readonly int numCols;
		private readonly Random random;

		public Food(int numRows, int numCols)
		{
			this.numRows = numRows;
			this.numCols = numCols;
			random = new Random();

			SpawnFood();
		}

		public void SpawnFood()
		{
			Row = random.Next(0, numRows);
			Column = random.Next(0, numCols);
		}
	}
}