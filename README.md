# Project - Snake Game in C#




## Project Overview

A solo project where I used C#, WPF, System.Windows, System.Drawing, and DispatcherTimer to create a classic Snake game. This project demonstrates how to build a simple yet engaging game using C# and Windows Presentation Foundation (WPF) for the user interface. The game includes essential features like snake movement, food spawning, collision detection, and score tracking.

The Snake game is built using the following key components:

Snake Class: This class represents the snake itself, including its body segments, movement, and collision detection. It is responsible for managing the snake's growth, movement, and checking for collisions with the boundaries or itself.

Food Class: This class represents the food that the snake consumes to grow. It is responsible for generating random food locations on the game board while ensuring that it does not spawn on the snake's body.

GameState Class: This class is responsible for managing the game's overall state, including the snake and food objects, the game's current direction, and the game over status.

MainWindow Class: This class represents the main user interface of the game. It handles user input, updates the game state, and redraws the snake and food on the game board. It also manages the game loop using a DispatcherTimer, which ensures that the game runs smoothly and updates at a consistent rate.

Direction Enum: This enumeration is used to represent the four possible movement directions for the snake: Up, Down, Left, and Right.

By combining these components, the project provides a complete and functional Snake game that can be played on a Windows computer using the arrow keys to control the snake's movement. The game tracks the player's score, which increases as the snake consumes more food, and displays a "Game Over" message when the snake collides with the boundaries or itself.

## Technologies used:

### Front end:
* WPF (Windows Presentation Foundation)
* XAML (Extensible Application Markup Language)
* System.Windows.Shapes
* System.Windows.Media
 ### Back end:
* C#
* System.Drawing
* System.Windows.Threading
### Dev Tools:
* Visual Studio
* .NET Framework
* Git
* GitHub
* Windows OS
* Microsoft Developer documentation
* Stack Overflow (for troubleshooting and support)

Note: In the case of the Snake game in C# using WPF, the front end and back end are closely tied together since it's a standalone desktop application. Thus, the front end and back end technologies are mostly integrated.


## Phase

This project consisted of three phases

### Phase 1 - (Planning):

During the initial phase, I focused on setting up the development environment and defining the basic structure of the project. Here's how I approached it:

1. Environment Setup:
The first step was to set up the development environment. I installed the latest version of Visual Studio and the .NET Framework to have access to all the necessary libraries and tools for building the game.

2. Project Creation:
Next, I created a new WPF App (.NET Framework) project in Visual Studio, giving it the name "SnakeGame". This automatically generated a solution containing the main project files, including App.xaml and MainWindow.xaml, along with their respective code-behind files App.xaml.cs and MainWindow.xaml.cs.

3. MainWindow Design:
I opened MainWindow.xaml and defined the basic structure of the main game window. I set up the height and width, background color, window title, and disabled resizing to maintain the aspect ratio of the game.

In the MainWindow, I also added a Canvas element named "GameBoard" which would be used to draw the snake and the food.

4. Class Definitions:
Next, I defined the basic structure of the game's classes: Snake, Food, GameState, and Position.

Snake Class: The Snake class was set up with basic fields to represent the snake's body (a collection of points), the current direction of the snake, and methods for movement and collision detection.

Food Class: The Food class was defined with properties to represent the position of the food on the game board and a method to randomly generate a new food position.

GameState Class: The GameState class was created to manage the overall state of the game, including instances of the Snake and Food classes, the current game score, and a flag to represent if the game is over.

Direction Enum: Lastly, I defined a Direction enum to represent the four possible movement directions of the snake: Up, Down, Left, Right.

At the end of this phase, the project structure was in place, the main game window was set up, and the necessary classes and enum were defined and ready to be fleshed out in the following phases. This initial setup was critical to ensure smooth development in the subsequent stages of the project.


### Phase 2 Making the Front end with Xaml:

The second phase of the project involved creating the visual interface or the front end of the game. For this purpose, XAML (Extensible Application Markup Language) was used. XAML, which comes with WPF, is a declarative language used for designing UI elements in .NET and is known for its ability to create sophisticated UIs with less code.

During this phase, I started by designing the game's primary window, including the game board (where the snake moves and food appears), score display, and other necessary elements. The game board was created as a Canvas element in XAML and was designed to be square, which is a typical shape for the Snake game.

Additionally, I implemented basic game controls like Start and Reset buttons and created a label for displaying the current score. Each of these elements was carefully positioned and styled to provide a seamless and visually appealing gaming experience.

The goal of this phase was to create a user interface that was not only functional but also visually engaging and easy to use, providing players with a clear view of the game state at any given moment. Using XAML and WPF made it possible to achieve this with clean and maintainable code, setting a solid foundation for the next phases of the project.

### Phase 3 Combining the classes to make the Snake Game with the GameState:
In the final phase of the project, I integrated the different components to form the complete Snake game. This was achieved with the implementation of the GameState class, which played a pivotal role in controlling the flow and rules of the game.

Below is a description of the key elements of the GameState class:

Enum Direction
This enumeration defines the four possible directions that the snake can move in - Up, Down, Left, and Right.

Properties
The class contains several important properties:

Snake: an instance of the Snake class representing the snake in the game.
Food: an instance of the Food class representing the food in the game.
GameOver: a boolean flag to indicate if the game is over.
CurrentDirection: keeps track of the current direction of the snake.
GameState Constructor
The constructor initializes the Snake object at the center of the game board, sets up the random number generator, generates the first food item, sets GameOver to false, and sets the initial direction of the snake to Right.

Method - MoveSnake(Direction direction)
This method is responsible for moving the snake in the specified direction. It first checks if the new direction is opposite to the current direction. If so, it ignores the new direction and continues moving in the current direction. It then moves the snake and checks for collisions with the game boundaries or with the snake itself. If any of these collisions occur, it sets GameOver to true. If the snake collides with the food, it makes the snake grow and generates a new food item.

Method - GenerateNewFood()
This private method is used to generate a new food item at a random location on the game board. It ensures that the food does not spawn on the snake's body by repeatedly generating random positions until it finds one that does not collide with the snake.

The GameState class encapsulates all the rules and mechanics of the game, making it the central hub for game management. It communicates and coordinates between the Snake and Food classes, processes user inputs, and checks the game's status. Thus, with the creation of the GameState class, the different components of the Snake game are successfully integrated to produce a fully functional game.


## Final Product:

Game Page





## Wins & Challenges

### Win




### Challenges


### Bugs




## Future Content and Improvements:





## Key learnings
