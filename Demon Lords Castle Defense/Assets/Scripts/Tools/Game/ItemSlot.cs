using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour
{
    // Author: Eshter Li (YT)
    // this handles getting the item out of the inventory, as well as show tooltip

    public Image image;
    public InventoryScript inventoryScript;

    public InventoryItem _item;
    public InventoryItem Item
    {
        get { return _item; }
        set
        {
            _item = value;

            if (_item == null) image.enabled = false;
            else
            {
                image.sprite = _item.Icon;
                image.enabled = true;
            }
        }
    }

    private void Awake()
    {
        inventoryScript = GetComponentInParent<InventoryScript>();
    }

    public void TakeOutItem()
    {
        _item.item.SetActive(true);
        _item.item.transform.position = new Vector3 (WorldMouse.Get().x, 1, WorldMouse.Get().y);

        inventoryScript.RemoveFromInventory(_item.item);

        _item.item.GetComponent<Placeable>().ManualStartDrag();
    }
}// end of class
