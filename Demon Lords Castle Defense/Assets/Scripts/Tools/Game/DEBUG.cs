using UnityEngine;

public class DEBUG : MonoBehaviour
{
    public InventoryScript inventoryScript;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            inventoryScript.AddToInventory(this.gameObject, this.gameObject.GetComponentInChildren<SpriteRenderer>().sprite);

            //gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            inventoryScript.RemoveFromInventory(this.gameObject);
        }
    }
}
