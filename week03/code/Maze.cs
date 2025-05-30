using System;
using System.Collections.Generic;

/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represent locations in the maze.
/// 'left', 'right', 'up', and 'down' are booleans representing valid directions.
///
/// If a direction is false, then there is a wall in that direction.
/// If a direction is true, then movement is allowed.
///
/// If there is a wall, an InvalidOperationException with the message
/// "Can't go that way!" is thrown. Otherwise, the current position
/// (_currX, _currY) is updated.
/// </summary>
public class Maze
{
    // Maze dictionary: keys are coordinates (x, y),
    // values are bool arrays representing [left, right, up, down]
    private readonly Dictionary<(int x, int y), bool[]> _mazeMap;

    // Current player location coordinates initialized to (1,1)
    private int _currX = 1;
    private int _currY = 1;

    /// <summary>
    /// Constructor takes a maze dictionary mapping coordinates to
    /// movement options (left, right, up, down).
    /// </summary>
    /// <param name="mazeMap">Dictionary defining the maze</param>
    public Maze(Dictionary<(int x, int y), bool[]> mazeMap)
    {
        _mazeMap = mazeMap ?? throw new ArgumentNullException(nameof(mazeMap));
    }

    /// <summary>
    /// Checks if you can move left from the current location.
    /// If allowed, updates the location. Otherwise, throws an exception.
    /// </summary>
    public void MoveLeft()
    {
        var currentLocation = (_currX, _currY);

        if (!_mazeMap.ContainsKey(currentLocation))
            throw new InvalidOperationException("Invalid current location in maze.");

        // Check if movement left is allowed from current location
        if (_mazeMap[currentLocation][0])
        {
            var nextLocation = (_currX - 1, _currY);
            if (_mazeMap.ContainsKey(nextLocation))
                _currX--;
            else
                throw new InvalidOperationException("Can't go that way (no cell)!");
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Checks if you can move right from the current location.
    /// If allowed, updates the location. Otherwise, throws an exception.
    /// </summary>
    public void MoveRight()
    {
        var currentLocation = (_currX, _currY);

        if (!_mazeMap.ContainsKey(currentLocation))
            throw new InvalidOperationException("Invalid current location in maze.");

        if (_mazeMap[currentLocation][1])
        {
            var nextLocation = (_currX + 1, _currY);
            if (_mazeMap.ContainsKey(nextLocation))
                _currX++;
            else
                throw new InvalidOperationException("Can't go that way (no cell)!");
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Checks if you can move up from the current location.
    /// If allowed, updates the location. Otherwise, throws an exception.
    /// </summary>
    public void MoveUp()
    {
        var currentLocation = (_currX, _currY);

        if (!_mazeMap.ContainsKey(currentLocation))
            throw new InvalidOperationException("Invalid current location in maze.");

        if (_mazeMap[currentLocation][2])
        {
            var nextLocation = (_currX, _currY + 1);
            if (_mazeMap.ContainsKey(nextLocation))
                _currY++;
            else
                throw new InvalidOperationException("Can't go that way (no cell)!");
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Checks if you can move down from the current location.
    /// If allowed, updates the location. Otherwise, throws an exception.
    /// </summary>
    public void MoveDown()
    {
        var currentLocation = (_currX, _currY);

        if (!_mazeMap.ContainsKey(currentLocation))
            throw new InvalidOperationException("Invalid current location in maze.");

        if (_mazeMap[currentLocation][3])
        {
            var nextLocation = (_currX, _currY - 1);
            if (_mazeMap.ContainsKey(nextLocation))
                _currY--;
            else
                throw new InvalidOperationException("Can't go that way (no cell)!");
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Returns a string representing the current position in the maze.
    /// </summary>
    /// <returns>String status of current location</returns>
    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
