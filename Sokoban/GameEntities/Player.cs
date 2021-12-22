using Sokoban.Abstract;
using Sokoban.Enums;
using Sokoban.GameElements;

namespace Sokoban.GameEntities;

public class Player : IWalkable
{
    public Cell? Cell { get; set; }

    public Player(Cell? cell)
    {
        Cell = cell;
    }

    public bool CanWalk(Directions direction)
    {
        var cell = Cell?.PushGameEntity(direction);
        if (cell == null)
            return false;
        Cell = cell;
        return true;
    }

    public void Draw()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(GameElement.Player);
        Console.ResetColor();
    }
}