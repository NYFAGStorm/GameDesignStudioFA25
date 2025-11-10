using UnityEngine;

public class ShopManager : MonoBehaviour
{
    // Author: Gustavo Rojas Flores
    // Manages the shop

    public GameObject shopContainer;
    public GameObject shopClosed;

    private bool shopOpen = false;

    public void ToggleShop()
    {
        shopOpen = !shopOpen;

        shopContainer.SetActive(shopOpen);
        shopClosed.SetActive(!shopOpen);
    }
}
