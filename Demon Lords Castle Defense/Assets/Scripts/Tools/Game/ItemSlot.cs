using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ItemSlot : MonoBehaviour
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

    public Placeable placeableScript;

    private void Awake()
    {
        placeableScript = gameObject.GetComponent<Placeable>();
    }

    private void Update()
    {
        //if (placeableScript.)
    }

}// end of class
