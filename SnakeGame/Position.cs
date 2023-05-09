using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
	public class Position
	{
		public int Row { get; }
		public int Column { get; }

		public Position(int row, int column)
		{
			Row = row;
			Column = column;
		}

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
			{
				return false;
			}

			Position other = (Position)obj;
			return Row == other.Row && Column == other.Column;
		}

		public override int GetHashCode()
		{
			return Tuple.Create(Row, Column).GetHashCode();
		}
	}
	}
