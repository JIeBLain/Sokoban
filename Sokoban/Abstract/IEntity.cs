namespace Sokoban.Abstract;

public interface IEntity
{
    Cell? Cell { get; set; }
    void Draw();
}