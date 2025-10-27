using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Placeable : MonoBehaviour
{
    // Author: Gustavo Rojas Flores
    // Is the base for all placeable items like tiles, goons and decorations

    // Written rules (Esther)
    // click and hold for 1.5 secs to remove item from slot
    // if Tile has Goons/Trophies in Slot when moved, items stay in Slot

    protected Slot container = null;
    protected bool isPlaced = false;
    protected bool isBeingDragged = false;
    protected bool locked;
    protected List<Slot> validSlots;
    protected Vector3 flat = new Vector3(1, 0, 1);
    protected List<Slot> childSlots;
    protected float removeHoldTime = 0.5f;
    protected bool clicked = false;

    public void Lock(bool setLock)
    {
        locked = setLock;
    }

    private void OnMouseDown()
    {
        clicked = true;

        if (locked) return;

        Invoke("StartDrag", removeHoldTime);
    }

    private void StartDrag()
    {
        if (!clicked) return;

        isPlaced = false;

        if (container) container.RemoveItem(false);
        container = null;

        isBeingDragged = true;
        validSlots = new List<Slot>(FindObjectsByType<Slot>(FindObjectsSortMode.InstanceID));
        childSlots = new List<Slot>();
        childSlots.Clear();

        foreach (Slot s in validSlots)
        {
            Debug.Log(s);
            Placeable p = s.transform.root.GetComponent<Placeable>();
            if (p == this)
            {
                validSlots.Remove(s);
                childSlots.Add(s);
                continue;
            }

            if (GetType().Name != s.GetSlotType().Name)
            {
                validSlots.Remove(s);
            }
        }
    }

    virtual protected void Update()
    {
        if (!isBeingDragged) return;
        transform.position = new Vector3(WorldMouse.Get().x, 1, WorldMouse.Get().y);
    }

    private Slot GetClosestSlot()
    {
        float closestSlotDistance = Mathf.Infinity;
        Slot closestSlot = null;

        foreach (Slot slot in validSlots)
        {
            Vector3 flatTargetPos = Vector3.Scale(slot.transform.position, flat);
            Vector3 flatPos = Vector3.Scale(transform.position, flat);
            float flatDistance = Vector3.Distance(flatTargetPos, flatPos);

            if (flatDistance < closestSlotDistance && slot.maximumDistance > flatDistance)
            {
                closestSlot = slot;
                closestSlotDistance = flatDistance;
            }
        }

        return closestSlot;
    }

    public void ForceRemove()
    {
        foreach (Slot s in childSlots)
        {
            s.GetItem().ForceRemove();
        }

        container = null;
        Destroy(gameObject);
        // Tell inventory manager to add this item back to player's inventory
    }

    public void UpdateContainer(Slot newContainer)
    {
        container = newContainer;
    }

    private void OnMouseUp()
    {
        clicked = false;
        CancelInvoke("StartDrag");

        if (!isBeingDragged) return;

        isBeingDragged = false;

        Slot s = GetClosestSlot();

        if (!s) return;

        isPlaced = s.InsertItem(this);
    }
}
