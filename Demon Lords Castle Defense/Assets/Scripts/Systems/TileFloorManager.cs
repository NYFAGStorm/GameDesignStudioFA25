using UnityEngine;
using System.Collections.Generic;

public class TileFloorManager : MonoBehaviour
{
    // Author: Gustavo Rojas Flores
    // Manages Tile objects that are placed on it

    private Slot[] tileSlots = new Slot[0];
    private List<Vector2> compiledPath;

    public GameObject tileObject;
    public Vector2Int gridSize;
    public float unitSize;
    public float yOffset;

    private void Awake()
    {
        tileSlots = new Slot[gridSize.x * gridSize.y];

        for (int y = 0; y < gridSize.y; y++)
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                GameObject newTile = Instantiate(tileObject, transform, false);

                float xCenterOffset = ((gridSize.x - 1) * unitSize) / 2;
                float yCenterOffset = ((gridSize.y - 1) * unitSize) / 2;
                newTile.transform.localPosition = new Vector3(x * unitSize - xCenterOffset, yOffset, y * unitSize - yCenterOffset);
                newTile.transform.rotation = Quaternion.identity;

                tileSlots[x + y * gridSize.y] = newTile.GetComponent<Slot>();
            }
        }
    }

    public void CompilePath()
    {

    }
}
