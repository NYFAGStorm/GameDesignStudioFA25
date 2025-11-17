using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    // Author: Esther Li (YT)
    // this handles the inventory

    public List<InventoryItem> items = new List<InventoryItem>();
    public int outOfWorldX = -30;
    public int outOfWorldZ = -5;

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

    public void AddToInventory(GameObject gameObject, Sprite sprite)
    {
        items.Add (new InventoryItem { item = gameObject, Icon = sprite });
        RefreshUI ();

        gameObject.transform.position = new Vector3(outOfWorldX, 1, outOfWorldZ);
        gameObject.SetActive(false);

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
        RefreshUI ();

        Debug.Log(items.Count);
    }
}// end of class