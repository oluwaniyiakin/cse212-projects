// DO NOT MODIFY THIS FILE

public class Maze
{
    public int Width { get; }
    public int Height { get; }

    public readonly int[] Data;

    public Maze(int width, int height, int[] data)
    {
        this.Width = width;
        this.Height = height;
        this.Data = data;
    }

    /// <summary>
    /// Check if a given (x, y) coordinate is the end point of the maze.
    /// A square with value 2 indicates the end.
    /// </summary>
    public bool IsEnd(int x, int y)
    {
        return Data[y * Width + x] == 2;
    }

    /// <summary>
    /// Check if moving to (x, y) is valid:
    /// - must be within bounds
    /// - must not be a wall (value 0)
    /// - must not already be in the current path (no loops)
    /// </summary>
    public bool IsValidMove(List<(int, int)> currPath, int x, int y)
    {
        // Check boundaries
        if (x < 0 || x >= Width || y < 0 || y >= Height)
            return false;

        // Check wall
        if (Data[y * Width + x] == 0)
            return false;

        // Check for revisiting same square
        if (currPath.Contains((x, y)))
            return false;

        return true;
    }

    /// <summary>
    /// Get the value of a cell at (x, y) in the maze grid.
    /// </summary>
    public int Get(int x, int y)
    {
        return Data[y * Width + x];
    }

    /// <summary>
    /// Check if (x, y) is within bounds of the maze.
    /// </summary>
    public bool InBounds(int x, int y)
    {
        return x >= 0 && x < Width && y >= 0 && y < Height;
    }
}
