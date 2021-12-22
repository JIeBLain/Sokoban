using Sokoban.Abstract;
using Sokoban.GameEntities;

namespace Sokoban;

public class GameLevel
{
    public int Level { get; set; }
    public Cell? InitialCell { get; set; }
    public Player? Player { get; set; }
    public List<Crate?> Crates { get; } = new();
    public int DestinationsAmount { get; set; }

    public void DrawLevel()
    {
        var current = InitialCell;
        var firstCell = current;

        while (current != null)
        {
            if (current.Entity != null)
                current.Entity.Draw();
            else
                current.Draw();

            if (current.Right == null)
            {
                Console.WriteLine("");
                current = firstCell?.Down;
                firstCell = current;
            }
            else
                current = current.Right;
        }
    }

    public bool IsFinished()
    {
        var finishedCount = 0;
        foreach (var crate in Crates)
            if (crate is {IsDestination: true})
                finishedCount++;
        return finishedCount == Crates.Count;
    }
}