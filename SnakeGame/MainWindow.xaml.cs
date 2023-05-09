using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SnakeGame
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private GameState gameState;

		public MainWindow()
		{
			InitializeComponent();
			gameState = new GameState(20, 20); // Set numRows and numCols according to your grid size

			Snake snake = new Snake(10, 10); // Initialize the snake with a starting position
			DrawSnake(snake);

			Food food = gameState.Food; // Get the food object from the gameState
			DrawFood(food); // Draw the food on the canvas
		}

		// Draw the food on the canvas
		private void DrawFood(Food food)
		{
			var rectangle = new Rectangle
			{
				Width = 20, // Set the width of the food
				Height = 20, // Set the height of the food
				Fill = Brushes.Red // Set the color of the food
			};

			Canvas.SetLeft(rectangle, food.Location.Column * 20); // Set the X position of the food
			Canvas.SetTop(rectangle, food.Location.Row * 20); // Set the Y position of the food

			GameCanvas.Children.Add(rectangle);
		}

		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			if (gameState.GameOver)
			{
				return;
			}

			Direction newDirection = gameState.Direction;

			switch (e.Key)
			{
				case Key.Up:
					if (newDirection != Direction.Down)
					{
						newDirection = Direction.Up;
					}
					break;
				case Key.Down:
					if (newDirection != Direction.Up)
					{
						newDirection = Direction.Down;
					}
					break;
				case Key.Left:
					if (newDirection != Direction.Right)
					{
						newDirection = Direction.Left;
					}
					break;
				case Key.Right:
					if (newDirection != Direction.Left)
					{
						newDirection = Direction.Right;
					}
					break;
				default:
					break;
			}

			gameState.Direction = newDirection;
		}

		private void DrawSnake(Snake snake)
		{
			GameCanvas.Children.Clear(); // Clear previous snake

			foreach (var segment in snake.GetBody())
			{
				var rectangle = new Rectangle
				{
					Width = 20, // Set the width of the snake segment
					Height = 20, // Set the height of the snake segment
					Fill = Brushes.Green // Set the color of the snake segment
				};

				Canvas.SetLeft(rectangle, segment.X * 20); // Set the X position of the segment
				Canvas.SetTop(rectangle, segment.Y * 20); // Set the Y position of the segment

				GameCanvas.Children.Add(rectangle);
			}
		}
	}
}
