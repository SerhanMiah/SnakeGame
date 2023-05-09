using System;
using System.Collections.Generic;
using System.Drawing;

namespace SnakeGame
{
	public class Snake
	{
		private const int InitialLength = 3;
		private const int DefaultDirection = 0; // right

		private List<Point> body;
		private int direction;

		public Snake(Point head)
		{
			body = new List<Point>();

			for (int i = 0; i < InitialLength; i++)
			{
				body.Add(new Point(head.X - i, head.Y));
			}

			direction = DefaultDirection;
		}

		public Snake(int x, int y) : this(new Point(x, y)) { }

		public void Move()
		{
			// Move the snake in the current direction
			Point head = body[0];
			Point newHead = new Point(head.X, head.Y);

			switch (direction)
			{
				case 0: // right
					newHead.X++;
					break;
				case 1: // down
					newHead.Y++;
					break;
				case 2: // left
					newHead.X--;
					break;
				case 3: // up
					newHead.Y--;
					break;
			}

			body.Insert(0, newHead);
			body.RemoveAt(body.Count - 1);
		}

		public void SetDirection(int newDirection)
		{
			if (Math.Abs(direction - newDirection) != 2) // don't allow opposite direction
			{
				direction = newDirection;
			}
		}

		public List<Point> GetBody()
		{
			return body;
		}

		public Point GetHead()
		{
			return body[0];
		}

		public bool CollidesWith(Point p)
		{
			foreach (Point segment in body)
			{
				if (segment == p)
				{
					return true;
				}
			}

			return false;
		}

		public bool CollidesWithSelf()
		{
			Point head = GetHead();

			for (int i = 1; i < body.Count; i++)
			{
				if (head == body[i])
				{
					return true;
				}
			}

			return false;
		}
	}
}
