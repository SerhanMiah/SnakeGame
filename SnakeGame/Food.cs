using System;
using System.Drawing;

namespace SnakeGame
{
	public class Food
	{
		public Point Location { get; private set; }

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
			int row = random.Next(0, numRows);
			int column = random.Next(0, numCols);
			Location = new Point(column, row);
		}
	}
}