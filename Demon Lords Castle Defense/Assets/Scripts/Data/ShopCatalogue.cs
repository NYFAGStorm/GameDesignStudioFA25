using UnityEngine;

[System.Serializable]
public struct UniqueShopItem
{
    public string name;
    public int price;
    public Sprite image;
}

[CreateAssetMenu(fileName = "ShopCatalogue", menuName = "DemonDefense/ShopCatalogue", order = 3)]
public class ShopCatalogue : ScriptableObject
{
    public UniqueShopItem[] catalogue;
}
