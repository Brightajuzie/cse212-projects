/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // Indices for the boolean array: [left, right, up, down]
    private const int LeftIndex = 0;
    private const int RightIndex = 1;
    private const int UpIndex = 2;
    private const int DownIndex = 3;

    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveLeft()
    {
        // Retrieve the directional array for the current (x, y) position.
        bool[] directions = _mazeMap[(_currX, _currY)];

        // Check the 'left' index (0).
        if (directions[LeftIndex])
        {
            // Allowed: move left (decrement X).
            _currX--;
        }
        else
        {
            // Wall: throw exception.
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveRight()
    {
        // Retrieve the directional array for the current (x, y) position.
        bool[] directions = _mazeMap[(_currX, _currY)];

        // Check the 'right' index (1).
        if (directions[RightIndex])
        {
            // Allowed: move right (increment X).
            _currX++;
        }
        else
        {
            // Wall: throw exception.
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveUp()
    {
        // Retrieve the directional array for the current (x, y) position.
        bool[] directions = _mazeMap[(_currX, _currY)];

        // Check the 'up' index (2).
        if (directions[UpIndex])
        {
            // Allowed: move up (increment Y).
            _currY++;
        }
        else
        {
            // Wall: throw exception.
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>
    public void MoveDown()
    {
        // Retrieve the directional array for the current (x, y) position.
        bool[] directions = _mazeMap[(_currX, _currY)];

        // Check the 'down' index (3).
        if (directions[DownIndex])
        {
            // Allowed: move down (decrement Y).
            _currY--;
        }
        else
        {
            // Wall: throw exception.
            throw new InvalidOperationException("Can't go that way!");
        }
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}