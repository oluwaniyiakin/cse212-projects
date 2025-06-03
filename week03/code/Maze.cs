using System;
using System.Collections.Generic;

public class Maze
{
    private readonly Dictionary<(int x, int y), bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<(int x, int y), bool[]> mazeMap)
    {
        _mazeMap = mazeMap ?? throw new ArgumentNullException(nameof(mazeMap));
    }

    public void MoveLeft()
    {
        var currentLocation = (_currX, _currY);

        if (!_mazeMap.ContainsKey(currentLocation))
            throw new InvalidOperationException("Invalid current location in maze.");

        if (_mazeMap[currentLocation][0])
        {
            var nextLocation = (_currX - 1, _currY);
            if (_mazeMap.ContainsKey(nextLocation))
                _currX--;
            else
                throw new InvalidOperationException("Can't go that way!");
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

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
                throw new InvalidOperationException("Can't go that way!");
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

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
                throw new InvalidOperationException("Can't go that way!");
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

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
                throw new InvalidOperationException("Can't go that way!");
        }
        else
        {
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}
