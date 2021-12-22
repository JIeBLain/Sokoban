using Sokoban.Enums;
using Sokoban.GameElements;
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
        GetSelectedLevel();
        while (GameLevel != null)
        {
            Clear();
            StartGame();
            WriteLine($"Level: {GameLevel.Level}");
            WriteLine("--------");
            GameLevel.DrawLevel();
            DisplayKeysInfo();
            if (GameLevel.IsFinished())
                EndGame();
            CheckInput();
        }
    }

    private void GetSelectedLevel()
    {
        const string prompt = $"{AsciiTexts.Sokoban}What game level would you like to play?\n";
        var options = new[]
        {
            "Level 0", "Level 1", "Level 2", "Level 3", "Level 4", "Level 5", "Level 6", "Level 7", "Level 8",
            "Level 9", "Back"
        };
        var levelMenu = new Menu(prompt, options);
        var selectedIndex = levelMenu.Run();

        if (selectedIndex == 10)
            new MainMenu().Run();

        GameLevel = Parser.Parse(selectedIndex);
    }

    private static void StartGame()
    {
        Write(AsciiTexts.Sokoban);
        WriteLine("------------------------------------------------------------");
        Write("Use the arrow keys to move Sokoban, who looks like: ");
        ForegroundColor = ConsoleColor.Red;
        Write(GameElement.Player);
        ResetColor();
        WriteLine(" and");
        Write("push the crates: ");
        ForegroundColor = ConsoleColor.DarkYellow;
        Write(GameElement.Crate);
        ResetColor();
        Write(" onto these positions: ");
        ForegroundColor = ConsoleColor.DarkGreen;
        Write(GameElement.CrateDestination);
        ResetColor();
        WriteLine();
        WriteLine("------------------------------------------------------------");
    }

    private static void DisplayKeysInfo()
    {
        WriteLine("------------------------------------------------------------");
        WriteLine("Press 'R'- key to reload the level or 'B'- key to get back");
        WriteLine("------------------------------------------------------------");
    }

    private void EndGame()
    {
        WriteLine(AsciiTexts.YouWin);
        WriteLine("Press any keys to select another levels...");
        ReadKey(true);
        new LevelMenu().Run();
    }

    private void CheckInput()
    {
        var keyInfo = ReadKey(true);
        var keyPressed = keyInfo.Key;

        if (GameLevel == null) return;

        switch (keyPressed)
        {
            case ConsoleKey.UpArrow:
                GameLevel.Player?.CanWalk(Directions.Up);
                break;
            case ConsoleKey.DownArrow:
                GameLevel.Player?.CanWalk(Directions.Down);
                break;
            case ConsoleKey.RightArrow:
                GameLevel.Player?.CanWalk(Directions.Right);
                break;
            case ConsoleKey.LeftArrow:
                GameLevel.Player?.CanWalk(Directions.Left);
                break;
            case ConsoleKey.R:
                GameLevel = Parser.Parse(GameLevel.Level);
                break;
            case ConsoleKey.B:
                new LevelMenu().Run();
                break;
        }
    }
}