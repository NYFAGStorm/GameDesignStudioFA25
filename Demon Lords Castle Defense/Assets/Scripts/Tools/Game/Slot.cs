using UnityEngine;
using System;

public enum SlotType
{
    Tile,
    Minion,
    Decoration
}

public class Slot : MonoBehaviour
{
    // Author: Gustavo Rojas Flores
    // Can hold one Placeable within itself

    private Placeable item = null;

    public SlotType slotType = 0;
    public Vector3 offset;

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
            // prompt replacement
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
