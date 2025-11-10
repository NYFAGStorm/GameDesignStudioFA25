using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    private int cost;
    private string name;
    private Sprite image;

    public void InitializeShopItem()
    {
        GetComponent<Button>().onClick.AddListener(BuyItem);
    }

    private void BuyItem()
    {
        if (CurrencyManager.SpendSouls(cost))
        {
            FindFirstObjectByType<InventoryScript>().AddToInventory(name, image);
        }
    }
}
