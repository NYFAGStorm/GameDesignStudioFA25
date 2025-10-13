using UnityEngine;

public class Tile : Placeable
{
    private TileShape shape;
    private TileDirection dir;
    private TileType type;
    private Tile[] neighbors = new Tile[4];
    private const int maxSlots = 6;

    public SpriteRenderer plate;

    public void InitializeTile(TileShape inShape, TileType inType, Sprite plateImage)
    {
        shape = inShape;
        type = inType;
        plate.sprite = plateImage;
    }
}
