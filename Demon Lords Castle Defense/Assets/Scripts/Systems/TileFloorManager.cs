using UnityEngine;
using System.Collections.Generic;

public class TileFloorManager : MonoBehaviour
{
    // Author: Gustavo Rojas Flores
    // Manages Tile objects that are placed on it

    private Slot[] tileSlots = new Slot[16];
    private List<Vector2> compiledPath;

    public GameObject tileObject;
    public int gridSize;
    public float unitSize;
    public float yOffset;

    private void Awake()
    {
        for (int y = 0; y < gridSize; y++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                GameObject newTile = Instantiate(tileObject, transform, false);

                float centerOffset = ((gridSize - 1) * unitSize) / 2;
                newTile.transform.localPosition = new Vector3(x * unitSize - centerOffset, yOffset, y * unitSize - centerOffset);
                newTile.transform.rotation = Quaternion.identity;

                tileSlots[x + y * gridSize] = newTile.GetComponent<Slot>();
            }
        }
    }

    public void CompilePath()
    {

    }
}
