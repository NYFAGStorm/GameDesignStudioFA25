using UnityEngine;

public enum TileShape
{
    Straight,
    RightTurn,
    LeftTurn
}

public enum TileDirection
{
    Up,
    Right,
    Down,
    Left
}

public enum TileType
{
    ShadowHall,
    DarkPrisons,
    Dancefloor,
    EnchantedLibrary,
    Teahouse,
    JudgementHall
}

public class TileData : MonoBehaviour
{
    public GameObject TileBase;
    public UniqueTiles types;

    public Tile CreateTile(TileType type)
    {
        GameObject newTileObject = Instantiate(TileBase);
        UniqueTile tileData = new UniqueTile();

        foreach (UniqueTile t in types.tiles)
        {
            if (t.type == type)
            {
                tileData = t;
                break;
            }
        }
        
        Tile newTile = newTileObject.GetComponent<Tile>();
        newTile.InitializeTile(tileData.shape, tileData.type, tileData.plateImage);

        return newTile;
    }

    public void DEBUGCreateTile()
    {
        CreateTile(TileType.ShadowHall);
    }
}
