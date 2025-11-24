using UnityEngine;

[System.Serializable]
public struct UniqueShopItem
{
    public string name;
    public int price;
    public Sprite image;
    public ItemType itemType;
    public string itemEnumName;
}

[CreateAssetMenu(fileName = "ShopCatalog", menuName = "DemonDefense/ShopCatalog", order = 3)]
public class ShopCatalog : ScriptableObject
{
    public UniqueShopItem[] items;
}
