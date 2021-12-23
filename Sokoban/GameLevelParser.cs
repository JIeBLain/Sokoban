using Sokoban.Abstract;
using Sokoban.GameEntities;

namespace Sokoban;

public class GameLevelParser
{
    public GameLevel Parse(int level)
    {
        var levels = GetGameLevelsElements();
        var currentLevel = levels[level];
        return InitGameLevel(level, currentLevel);
    }

    private GameLevel InitGameLevel(int level, string currentLevel)
    {
        var gameLevel = new GameLevel {Level = level};
        var lines = currentLevel.Split("\r\n");
        var rows = lines.Length;
        var cols = lines[0].Length;
        var cells = new Cell?[rows, cols];

        for (var y = 0; y < rows; y++)
        {
            for (var x = 0; x < cols; x++)
            {
                var character = lines[y][x];
                Cell? cell = null;
                switch (character)
                {
                    case '▓':
                        cell = new Wall();
                        break;
                    case '·':
                        cell = new Floor();
                        break;
                    case '×':
                        cell = new CrateDestination();
                        gameLevel.DestinationsCount++;
                        break;
                    case '≡':
                        cell = new Floor();
                        var crate = new Crate(cell);
                        cell.Entity = crate;
                        gameLevel.Crates.Add(crate);
                        break;
                    case '♀':
                        cell = new Floor();
                        var player = new Player(cell);
                        cell.Entity = player;
                        gameLevel.Player = player;
                        break;
                }

                cells[y, x] = cell;
            }
        }

        for (var y = 0; y < rows; y++)
        {
            for (var x = 0; x < cols; x++)
            {
                var cell = cells[y, x];

                if (cell == null) continue;

                cell.Up = GetCell(cells, x, y - 1);
                cell.Down = GetCell(cells, x, y + 1);
                cell.Right = GetCell(cells, x + 1, y);
                cell.Left = GetCell(cells, x - 1, y);

                if (x == 0 && y == 0)
                    gameLevel.InitialCell = cell;
            }
        }

        return gameLevel;
    }

    private Cell? GetCell(Cell?[,] cells, int x, int y)
    {
        if (x >= cells.GetLength(1)
            || x < 0
            || y >= cells.GetLength(0)
            || y < 0)
            return null;
        return cells[y, x];
    }

    private Dictionary<int, string> GetGameLevelsElements()
    {
        var levelToText = new Dictionary<int, string>();
        var directoryInfo = new DirectoryInfo("Levels");
        var files = directoryInfo.GetFiles("*.txt");
        foreach (var file in files)
        {
            var parts = file.Name.Split('_', '.');
            var level = int.Parse(parts[1]);
            var fileGameElements = File.ReadAllText(file.FullName);
            levelToText[level] = fileGameElements;
        }

        return levelToText;
    }
}