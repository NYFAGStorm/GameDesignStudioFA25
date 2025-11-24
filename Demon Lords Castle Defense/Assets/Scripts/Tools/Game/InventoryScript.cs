using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    // Author: Esther Li (YT)
    // this handles the inventory
    
    // Contributors: Gustavo Rojas Flores

    public List<InventoryItem> items = new List<InventoryItem>();
    public int outOfWorldX = -30;
    public int outOfWorldZ = -5;
    public GameObject inventoryItemBase;

    [SerializeField] Transform itemsParent;
    [SerializeField] ItemSlot[] itemSlots;
  
    private void OnValidate()
    {
        if (itemsParent != null) itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
        
        RefreshUI();
    }

    public void SortInventory()
    {
        List<InventoryItem> tmp = new List<InventoryItem>();
        int safety = 0;
        ItemType currentType = ItemType.Tile;
        while (safety < 1000 && tmp.Count < items.Count)
        {
            safety++;
            if ((int)currentType > 2)
                Debug.LogWarning("--- reached beyond type length");
            foreach (InventoryItem i in items)
            {
                if (i.type == currentType)
                    tmp.Add(i);
            }
            currentType++;
        }
        items = tmp;
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

    public void AddToInventory(ItemType type, GameObject gameObject, Sprite sprite)
    {
        InventoryItem newItem = new InventoryItem { type = type, item = gameObject, Icon = sprite };
        items.Add(newItem);

        gameObject.transform.position = new Vector3(outOfWorldX, 1, outOfWorldZ);

        ItemSlot newItemSlot = Instantiate(inventoryItemBase, itemsParent).GetComponent<ItemSlot>();
        newItemSlot.InitializeInvSlot(newItem);

        SortInventory();
        RefreshUI();

        Debug.Log(items.Count);
    }

    public InventoryItem FindTHEItem (GameObject gameObject)
    {
        InventoryItem itemToFind = null;

        for (int i = 0; i < items.Count; i ++) 
        {
            if (items[i].item == gameObject)
            {
                itemToFind = items[i];
                break;
            }            
        }

        return itemToFind;
    }

    public void RemoveFromInventory(GameObject gameObject) 
    {
        items.Remove(FindTHEItem(gameObject));
        SortInventory();
        RefreshUI ();

        Debug.Log(items.Count);
    }
}// end of class