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

        // Check if current location exists in maze map
        if (!_mazeMap.ContainsKey(currentLocation))
            throw new InvalidOperationException("Invalid current location in maze.");

        // Index 0 = left direction
        if (_mazeMap[currentLocation][0])
        {
            _currX--; // Move left decreases x by 1
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

        // Index 1 = right direction
        if (_mazeMap[currentLocation][1])
        {
            _currX++; // Move right increases x by 1
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

        // Index 2 = up direction
        if (_mazeMap[currentLocation][2])
        {
            _currY++; // Move up increases y by 1
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

        // Index 3 = down direction
        if (_mazeMap[currentLocation][3])
        {
            _currY--; // Move down decreases y by 1
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
