using Sokoban.Abstract;
using Sokoban.GameElements;

namespace Sokoban.GameEntities;

public class CrateDestination : Cell
{
    public CrateDestination()
    {
        Marker = GameElement.CrateDestination;
        Color = ConsoleColor.DarkGreen;
    }
}