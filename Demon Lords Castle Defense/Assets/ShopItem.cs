using TMPro;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    private int price;
    private string itemName;
    private Sprite image;

    public TMP_Text costDisplay;
    public TMP_Text nameDisplay;
    public Image icon;

    public void InitializeShopItem(UniqueShopItem itemData)
    {
        price = itemData.price;
        itemName = itemData.name;
        image = itemData.image;

        costDisplay.text = "$" + price;
        nameDisplay.text = itemName;
        icon.sprite = image;

        GetComponent<Button>().onClick.AddListener(BuyItem);
    }

    private void BuyItem()
    {
        if (CurrencyManager.SpendSouls(price))
        {
            FindFirstObjectByType<InventoryScript>().AddToInventory(name, image);
        }
    }
}
