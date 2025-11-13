using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : Placeable
{
    // Author: Eshter Li (YT)
    // this handles 

    public Image image;
    
    private InventoryItem _item;
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


    public new void Update()
    {
        if (isBeingDragged)
        {
            Debug.Log("CONNECTED");
        }
    }

}// end of class
