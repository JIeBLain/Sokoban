using Sokoban.MenuViews;

namespace Sokoban;

public class Game
{
    public void Start()
    {
        Console.Title = "Sokoban";
        Console.CursorVisible = false;
        new MainMenu().Run();
    }
}