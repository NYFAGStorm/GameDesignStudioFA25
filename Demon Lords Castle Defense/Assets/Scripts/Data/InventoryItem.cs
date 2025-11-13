using UnityEngine;

public enum ItemType
{
    Tile,
    Goon,
    Trophy
}

[System.Serializable]
public class InventoryItem
{
    public string itemName;
    public Sprite Icon;
}

public class TileItem : InventoryItem
{
    public TileType tileType;
    public TileShape tileShape;
    [Space]
    public int damagePerBeat;
    public DamageForm damageType;
    public goonSlotPosition[] goonSlotPositions;
    [Space]
    public int currentLevel;
    public int currentSlotCount;
    public int currentDamage;
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
    public OnBeat attackRate;
    public float attackRange;
    [Space]
    public int currentLevel;
    public int currentTargetCount;
}