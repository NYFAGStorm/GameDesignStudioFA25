using UnityEngine;

// Author: Gustavo Rojas Flores
// Manages all types and enums relating to Tiles

public enum TileShape
{
    Straight,
    Turn
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
        newTile.InitializeTile(tileData);

        return newTile;
    }

    public void DEBUGCreateTile(int t)
    {
        CreateTile((TileType)t);
    }
}
