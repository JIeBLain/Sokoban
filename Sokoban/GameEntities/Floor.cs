using Sokoban.Abstract;
using Sokoban.GameElements;

namespace Sokoban.GameEntities;

public class Floor : Cell
{
    public Floor()
    {
        Marker = GameElement.Floor;
        Color = ConsoleColor.Gray;
    }
}