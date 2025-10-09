using UnityEngine;

public enum Shape
{
    Straight,
    RightTurn,
    LeftTurn
}

public enum Direction
{
    Up,
    Right,
    Down,
    Left
}

public class Tile : Placeable
{
    private Shape shape;
    private Direction dir;
    private Tile[] neighbors = new Tile[4];
}
