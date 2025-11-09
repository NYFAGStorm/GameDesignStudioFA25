using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    // Author: Esther Li (YT)
    // this handles the inventory

    public List<InventoryItem> items = new List<InventoryItem>();

    [SerializeField] Transform itemsParent;
    [SerializeField] ItemSlot[] itemSlots;
  
    private void OnValidate()
    {
        if (itemsParent != null) itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
        
        RefreshUI();
    }

    public void RefreshUI()
    {
        int i = 0;
        for (; i < items.Count && i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = items[i];
            itemSlots[i].image.sprite = items[i].Icon;
        }
        for (; i < itemSlots.Length; i++) itemSlots[i].Item = null;
    }

    public void AddToInventory(string name, Sprite icon)
    {
        items.Add(new InventoryItem { itemName = name, Icon = icon });

        Debug.Log(items.Count);
    }

    public void RemoveFromInventory(InventoryItem itemToRemove) 
    {
        items.Remove(itemToRemove);
        Debug.Log(items.Count);
    }
}// end of class

/*
 * [SerializeField] List<InventoryItem> items;
    [SerializeField] Transform itemsParent;
    [SerializeField] ItemSlot[] itemSlots;
 * 
 * private void OnValidate()
{
    if (itemsParent != null) itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();

    RefreshUI();
}

private void RefreshUI()
{
    int i = 0;
    for (; i < items.Count && i < itemSlots.Length; i++) itemSlots[i].Item = items[i];
    for (; i < itemSlots.Length; i++) itemSlots[i].Item = null;
}

public bool AddItem(InventoryItem item)
{
    if (IsFull()) return false;

    items.Add(item);
    RefreshUI();
    return true;
}

public bool RemoveItem(InventoryItem item)
{
    if (items.Remove(item))
    {
        RefreshUI();
        return true;
    }
    return false;
}

public bool IsFull()
{
    return items.Count >= itemSlots.Length;
}*/