using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SnakeGame
{
	public partial class MainWindow : Window, INotifyPropertyChanged
	{
		private GameState gameState;
		private DispatcherTimer gameTimer;
		private bool gameStarted = false;
		private int score;

		public event PropertyChangedEventHandler PropertyChanged;

		public int Score
		{
			get { return score; }
			set
			{
				if (score != value)
				{
					score = value;
					OnPropertyChanged();
				}
			}
		}

		public MainWindow()
		{
			InitializeComponent();
			DataContext = this;

			int cellSize = 20;
			int gridWidth = (int)GameCanvas.Width / cellSize;
			int gridHeight = (int)GameCanvas.Height / cellSize;

			gameState = new GameState(gridWidth, gridHeight);

			DrawSnake(gameState.Snake);
			DrawFood(gameState.Food);

			Score = 0;

			gameTimer = new DispatcherTimer();
			gameTimer.Interval = TimeSpan.FromMilliseconds(100);
			gameTimer.Tick += GameTimer_Tick;
		}

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		private void GameTimer_Tick(object sender, EventArgs e)
		{
			try
			{
				if (!gameStarted)
				{
					Debug.WriteLine("Game not started.");
					return;
				}

				gameState.MoveSnake(gameState.CurrentDirection);

				// Check if the snake collides with the food and update the score
				if (gameState.Snake.CollidesWith(gameState.Food.Location))
				{
					UpdateScore(); // Increment the score
					gameState.Food.SpawnFood(); // Spawn a new food before updating the score UI
					Debug.WriteLine($"Score updated: {Score}");
				}

				DrawSnake(gameState.Snake);
				DrawFood(gameState.Food);

				if (gameState.GameOver)
				{
					gameTimer.Stop();
					MessageBox.Show("Game Over!");
					Debug.WriteLine("Game Over triggered.");
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"Error in timer tick: {ex.Message}");
				gameTimer.Stop();  // stop the game
			}
		}


		private void UpdateScore()
		{
			Score += 10;
		}

		private void StartButton_Click(object sender, RoutedEventArgs e)
		{
			gameStarted = !gameStarted;

			if (gameStarted)
			{
				StartButton.Content = "Pause";
				gameTimer.Start();
			}
			else
			{
				StartButton.Content = "Start";
				gameTimer.Stop();
			}
		}
		private void ResetButton_Click(object sender, RoutedEventArgs e)
		{
			gameStarted = false;
			StartButton.Content = "Start";
			gameTimer.Stop();
			ResetGame();
		}

		private void ResetGame()
		{
			gameState = new GameState(20, 20);

			DrawSnake(gameState.Snake);
			DrawFood(gameState.Food);
		}


		private void DrawFood(Food food)
		{
			var rectangle = new Rectangle
			{
				Width = 20,
				Height = 20,
				Fill = Brushes.Red
			};

			Canvas.SetLeft(rectangle, food.Location.X * 20);
			Canvas.SetTop(rectangle, food.Location.Y * 20);

			GameCanvas.Children.Add(rectangle);
		}

		private void Window_KeyDown(object sender, KeyEventArgs e)
		{
			if (gameState.GameOver)
			{
				return;
			}

			Direction newDirection;

			switch (e.Key)
			{
				case Key.Up:
					newDirection = Direction.Up;
					break;
				case Key.Down:
					newDirection = Direction.Down;
					break;
				case Key.Left:
					newDirection = Direction.Left;
					break;
				case Key.Right:
					newDirection = Direction.Right;
					break;
				default:
					return;
			}

			gameState.MoveSnake(newDirection);
		}


		private void DrawSnake(Snake snake)
		{
			GameCanvas.Children.Clear();

			foreach (var segment in snake.GetBody())
			{
				var rectangle = new Rectangle
				{
					Width = 20,
					Height = 20,
					Fill = Brushes.Green
				};

				Canvas.SetLeft(rectangle, segment.X * 20);
				Canvas.SetTop(rectangle, segment.Y * 20);

				GameCanvas.Children.Add(rectangle);
			}
		}
	}
}
