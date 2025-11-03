using UnityEngine;
using System;

public enum SlotType
{
    Tile,
    Goon,
    Decoration
}

public class Slot : MonoBehaviour
{
    // Author: Gustavo Rojas Flores
    // Can hold one Placeable within itself

    // Written rules (Esther)
    // [REPLACEMENT]
    // new item freeze in space, old item remain its status, game not paused
    // show UI asking if the player wants to replace
    //      yes: replace item, old item returns to inventory
    //      no: no replacement, new item returns to inventory
    // if the returned item is Tile, and Tile has Goons/Trohpies in Slot:
    //      all Slots should be cleared, all items returns to inventory

    private Placeable item = null;

    public SlotType slotType = 0;
    public Vector3 offset;
    public float maximumDistance = 1;
    public PopupBlueprint replacePrompt;

    private void Awake()
    {
        replacePrompt = new PopupBlueprint()
        {

        };
    }

    public Placeable GetItem()
    {
        return item;
    }

    public Type GetSlotType()
    {
        return Type.GetType(Enum.GetName(typeof(SlotType), slotType));
    }

    public bool InsertItem(Placeable newItem)
    {
        if (newItem.GetType().Name != GetSlotType().Name) return false;

        if (item)
        {
            PopupBuilder.CreatePopup();
            return false;
        }
        else
        {
            item = newItem;
            item.UpdateContainer(this);
            item.transform.position = transform.position + offset;

            return true;
        }
    }

    public void RemoveItem(bool forced)
    {
        if (forced) item.ForceRemove();
        item = null;
    }
}
