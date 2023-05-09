using System;
using System.Collections.Generic;
using System.Drawing;

namespace SnakeGame
{
	public class Snake
	{
		private const int InitialLength = 3;
		private List<Point> body;

		public Snake(Point head)
		{
			body = new List<Point>();

			for (int i = 0; i < InitialLength; i++)
			{
				body.Add(new Point(head.X - i, head.Y));
			}
		}

		public Snake(int x, int y) : this(new Point(x, y)) { }


		
		public void Move(Direction direction)
		{
			Point head = body[0];
			Point newHead = new Point(head.X, head.Y);

			switch (direction)
			{
				case Direction.Right:
					newHead.X++;
					break;
				case Direction.Down:
					newHead.Y++;
					break;
				case Direction.Left:
					newHead.X--;
					break;
				case Direction.Up:
					newHead.Y--;
					break;
			}

			body.Insert(0, newHead);
			body.RemoveAt(body.Count - 1);
		}

		public void Grow()
		{
			body.Add(body[body.Count - 1]);
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
