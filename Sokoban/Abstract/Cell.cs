using Sokoban.Enums;
using Sokoban.GameEntities;

namespace Sokoban.Abstract;

public abstract class Cell
{
    public Cell? Up { get; set; }
    public Cell? Down { get; set; }
    public Cell? Right { get; set; }
    public Cell? Left { get; set; }
    protected char Marker { get; init; }
    protected ConsoleColor Color { get; init; }
    public IEntity? Entity { get; set; }

    public Cell? PushGameEntity(Directions direction)
    {
        var cell = GetCellByDirection(direction);

        if (cell == null) return null;

        if (!cell.IsWalkable()) return null;

        if (!cell.IsOccupied())
        {
            cell.Entity = Entity;
            Entity = null;
            return cell;
        }

        if (cell.IsPlayer())
        {
            var player = cell.Entity as Player;
            var newCell = cell.PushGameEntity(direction);

            if (newCell == null) return null;
            if (player != null)
                player.Cell = newCell;

            cell.Entity = Entity;
            Entity = null;
            return cell;
        }

        if (!cell.IsPushable()) return null;

        var entity = cell.Entity as IPushable;

        if (IsPushable()) return null;
        if (cell.PushGameEntity(direction) == null) return null;

        entity?.Update(cell.GetCellByDirection(direction));
        cell.Entity = Entity;
        Entity = null;
        return cell;
    }

    private bool IsWalkable() => this is not Wall;
    private bool IsPlayer() => Entity is Player;
    private bool IsPushable() => Entity is IPushable;
    private bool IsOccupied() => Entity is not null;

    private Cell? GetCellByDirection(Directions direction)
    {
        return direction switch
        {
            Directions.Up => Up,
            Directions.Down => Down,
            Directions.Right => Right,
            Directions.Left => Left,
            _ => null
        };
    }

    public void Draw()
    {
        Console.ForegroundColor = Color;
        Console.Write(Marker);
        Console.ResetColor();
    }
}