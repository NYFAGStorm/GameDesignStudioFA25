using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Tile,
    Goon,
    Trophy
}

[System.Serializable]
public class InventoryItem
{
    public ItemType type;
    public GameObject item;
    public Sprite Icon;
}

/*public class TileItem : InventoryItem
{
    public TileType tileType;
    public TileShape tileShape;
    [Space]
    public int damagePerBeat;
    public DamageForm damageType;
    public goonSlotPosition[] goonSlotPositions;
    [Space] // need to consider adding these for tile info
    public int currentLevel;
    public int currentSlotCount;
    public int currentDamage;
    public OnBeat currentAttackRate;
    public string attribute;
}

public class GoonItem : InventoryItem
{
    public GoonType goonType;
    [Space]
    public int currentHealth;
    public int currentDamage;
    public AttackForm attackType;
    public DamageForm damageType;
    public float attackRange;
    [Space] // need to consider adding these for goon info
    public int currentLevel;
    public int currentTargetCount;
    public OnBeat currentAttackRate;
}*/