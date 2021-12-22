namespace Sokoban.Abstract;

public interface IPushable : IEntity
{
    void Update(Cell? cell);
}