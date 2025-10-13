using UnityEngine;

[System.Serializable]
public struct UniqueTile
{
    public TileType type;
    public TileShape shape;
    public Sprite plateImage;
    public int baseSlots;
    public int damagePerBeat;
    public int damageType;
}

[CreateAssetMenu(fileName = "TileTypes", menuName = "DemonDefense/TileTypes", order = 1)]
public class UniqueTiles : ScriptableObject
{
    [SerializeField]
    public UniqueTile[] tiles;
}
