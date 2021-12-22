using static System.Console;

namespace Sokoban.MenuViews;

public class MainMenu
{
    public void Run()
    {
        const string prompt = $@"{AsciiTexts.Sokoban}Welcome to Sokoban. What would you like to do?
(Use the arrow keys to cycle through options and press enter to select an option.)
";
        var options = new[] {"Play", "About", "Exit"};
        var mainMenu = new Menu(prompt, options);
        var selectedIndex = mainMenu.Run();

        switch (selectedIndex)
        {
            case 0:
                StartPlaying();
                break;
            case 1:
                DisplayAboutInfo();
                break;
            case 2:
                ExitGame();
                break;
        }
    }

    private void StartPlaying()
    {
        var levelMenu = new LevelMenu();
        levelMenu.Run();
    }

    private void DisplayAboutInfo()
    {
        Clear();
        WriteLine($@"{AsciiTexts.Sokoban}    Sokoban is a puzzle video game genre in which the player pushes crates
or boxes around in a warehouse, trying to get them to storage locations.

    The game is played on a board of squares, where each square is a floor or a wall. Some
floor squares contain boxes, and some floor squares are marked as storage locations.

    The player is confined to the board and may move horizontally or vertically onto empty
squares (never through walls or boxes). The player can move a box by walking up to it and
push it to the square beyond. Boxes cannot be pulled, and they cannot be pushed to squares
with walls or other boxes. The number of boxes equals the number of storage locations. The
puzzle is solved when all boxes are placed at storage locations.");
        WriteLine("\nPress any key to return to the menu");
        ReadKey(true);
        Run();
    }

    private void ExitGame()
    {
        WriteLine("\nPress any key to exit...");
        ReadKey(true);
        Environment.Exit(0);
    }
}