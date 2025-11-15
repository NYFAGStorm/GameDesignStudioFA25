using UnityEngine;

public class DEBUG : MonoBehaviour
{
    public InventoryScript inventoryScript;
    public ItemType itemType;
    public Tile tileScript;
    public Goon goonScript;

    private void Start()
    {
        if (itemType == ItemType.Tile) tileScript = GetComponent<Tile>();
        if (itemType == ItemType.Goon) goonScript = GetComponent<Goon>();
    }

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.K))
        {
            inventoryScript.AddToInventory(this.gameObject.GetComponentInChildren<SpriteRenderer>().sprite, tileScript.type, tileScript.shape, tileScript.attackRate);
            inventoryScript.RefreshUI();
            //Destroy(gameObject);
        }

        /*if (Input.GetKeyDown(KeyCode.P))
        {
            inventoryScript.RemoveFromInventory(this.gameObject.name);
            inventoryScript.RefreshUI();
        }*/
    }
}
