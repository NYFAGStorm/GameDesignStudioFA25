using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    private int price;
    private string itemName;
    private Sprite image;
    private ItemType type;
    private string enumName;

    public TMP_Text costDisplay;
    public TMP_Text nameDisplay;
    public Image icon;

    public void InitializeShopItem(UniqueShopItem itemData)
    {
        price = itemData.price;
        itemName = itemData.name;
        image = itemData.image;
        type = itemData.itemType;
        enumName = itemData.itemEnumName;

        costDisplay.text = "$" + price;
        nameDisplay.text = itemName;
        icon.sprite = image;

        GetComponent<Button>().onClick.AddListener(BuyItem);
    }

    private void BuyItem()
    {
        if (!CurrencyManager.SpendSouls(price)) return;

        GameObject newInvItem = null;

        switch (type)
        {
            case ItemType.Tile:
                newInvItem = FindFirstObjectByType<TileData>().CreateTile(Enum.Parse<TileType>(enumName)).gameObject;

                break;

            case ItemType.Goon:
                newInvItem = FindFirstObjectByType<GoonData>().CreateGoon(Enum.Parse<GoonType>(enumName)).gameObject;

                break;

            case ItemType.Trophy:
                //newInvItem = FindFirstObjectByType<TrophyData>().CreateTrophy(Enum.Parse<TrophyType>(enumName)).gameObject;

                break;
        }

        if (newInvItem)
        {
            newInvItem.SetActive(false);
            FindFirstObjectByType<InventoryScript>().AddToInventory(type, newInvItem, image);

            FindFirstObjectByType<AudioManager>().StartSound("PurchaseItem");
        }
        else
        {
            Debug.LogWarning("Invalid shop item data");
        }
    }
}
