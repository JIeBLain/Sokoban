using Sokoban.Abstract;
using Sokoban.GameElements;

namespace Sokoban.GameEntities;

public class Wall : Cell
{
    public Wall()
    {
        Marker = GameElement.Wall;
        Color = ConsoleColor.White;
    }
}