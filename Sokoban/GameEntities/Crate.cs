using Sokoban.Abstract;
using Sokoban.GameElements;

namespace Sokoban.GameEntities;

public class Crate : IPushable
{
    public bool IsDestination { get; private set; }
    public Cell? Cell { get; set; }

    public Crate(Cell? cell)
    {
        Cell = cell;
    }

    public void Draw()
    {
        if (IsDestination)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(GameElement.Crate);
            Console.ResetColor();
            return;
        }

        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write(GameElement.Crate);
        Console.ResetColor();
    }

    public void Update(Cell? cell)
    {
        Cell = cell;
        IsDestination = cell is CrateDestination;
    }
}