using Sokoban.Enums;

namespace Sokoban.Abstract;

public interface IWalkable : IEntity
{
    bool CanWalk(Directions direction);
}