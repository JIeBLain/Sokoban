using Sokoban.Enums;
using static System.Console;

namespace Sokoban.MenuViews;

public class LevelMenu
{
    private GameLevel? GameLevel { get; set; }
    private GameLevelParser Parser { get; }

    public LevelMenu()
    {
        Parser = new GameLevelParser();
    }

    public void Run()
    {
        Clear();
        var prompt = $"{ASCIITexts.Sokoban}What game level would you like to play?\n";
        var options = new[]
        {
            "Level 0", "Level 1", "Level 2", "Level 3", "Level 4", "Level 5", "Level 6", "Level 7", "Level 8",
            "Level 9"
        };
        var levelMenu = new Menu(prompt, options);
        var selectedIndex = levelMenu.Run();

        GameLevel = Parser.Parse(selectedIndex);

        while (GameLevel != null && !GameLevel.IsFinished())
        {
            Clear();
            GameLevel.DrawLevel();

            var keyInfo = ReadKey(true);
            var keyPressed = keyInfo.Key;

            switch (keyPressed)
            {
                case ConsoleKey.RightArrow:
                    GameLevel.Player?.CanWalk(Directions.Right);
                    break;
                case ConsoleKey.LeftArrow:
                    GameLevel.Player?.CanWalk(Directions.Left);
                    break;
                case ConsoleKey.DownArrow:
                    GameLevel.Player?.CanWalk(Directions.Down);
                    break;
                case ConsoleKey.UpArrow:
                    GameLevel.Player?.CanWalk(Directions.Up);
                    break;
            }

            if (GameLevel.IsFinished())
                break;
        }
    }
}