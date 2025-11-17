using UnityEngine;

public class DEBUG : MonoBehaviour
{
    public InventoryScript inventoryScript;
    public ItemType type;

    private void Awake()
    {
        if (this.gameObject.name == "Goon(Clone)") type = ItemType.Goon;
        if (this.gameObject.name == "Tile(Clone)") type = ItemType.Tile;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            inventoryScript.AddToInventory(type, this.gameObject, this.gameObject.GetComponentInChildren<SpriteRenderer>().sprite);

            //gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            //inventoryScript.SortInventory();
        }
    }
}
