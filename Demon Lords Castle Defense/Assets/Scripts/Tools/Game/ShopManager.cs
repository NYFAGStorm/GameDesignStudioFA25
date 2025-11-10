using UnityEngine;

public class ShopManager : MonoBehaviour
{
    // Author: Gustavo Rojas Flores
    // Manages the shop

    public ShopCatalog catalog;
    public GameObject shopContainer;
    public GameObject shopClosed;
    public GameObject shopItem;
    public Transform shopList;

    private bool shopOpen = false;

    private void Awake()
    {
        shopContainer.SetActive(false);
        shopClosed.SetActive(true);

        foreach (UniqueShopItem item in catalog.items)
        {
            ShopItem newItem = Instantiate(shopItem, shopList).GetComponent<ShopItem>();
            newItem.InitializeShopItem(item);
        }
    }

    public void ToggleShop()
    {
        shopOpen = !shopOpen;

        shopContainer.SetActive(shopOpen);
        shopClosed.SetActive(!shopOpen);
    }
}
