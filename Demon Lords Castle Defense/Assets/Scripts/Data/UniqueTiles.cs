using UnityEngine;

[System.Serializable]
public struct goonSlotPosition
{
    public Vector2 position;
    public bool free;
}

[System.Serializable]
public struct UniqueTile
{
    public TileType type;
    public TileShape shape;
    public Sprite plateImage;
    public int damagePerBeat;
    public DamageForm damageType;
    public goonSlotPosition[] goonSlotPositions;
}

[CreateAssetMenu(fileName = "TileTypes", menuName = "DemonDefense/TileTypes", order = 1)]
public class UniqueTiles : ScriptableObject
{
    public UniqueTile[] tiles;
}
