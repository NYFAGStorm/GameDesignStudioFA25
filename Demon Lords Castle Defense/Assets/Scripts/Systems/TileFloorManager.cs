using UnityEngine;
using System.Collections.Generic;
using System;

public class TileFloorManager : MonoBehaviour
{
    // Author: Gustavo Rojas Flores
    // Manages Tile objects that are placed on it

    // Written rules (Esther)
    // 

    private Slot[] tileSlots = new Slot[0];
    private List<Vector3> compiledPath;
    private Vector3 heroEntrance;
    private Vector3 heroExit;
    private Slot entranceSlot;
    private Vector2Int currentCompilePosition;
    private Vector2Int compileStartPosition;

    public GameObject tileObject;
    public Vector2Int gridSize;
    public float unitSize;
    public float yOffset;
    public Transform floor;
    public GameObject debugEnemy;
    public AttackerData attackerData;

    private void Awake()
    {
        tileSlots = new Slot[gridSize.x * gridSize.y];
        floor.localScale = new Vector3(gridSize.x * unitSize, gridSize.y * unitSize, 1);

        for (int y = 0; y < gridSize.y; y++)
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                GameObject newSlot = Instantiate(tileObject, transform, false);

                float xCenterOffset = ((gridSize.x - 1) * unitSize) / 2;
                float yCenterOffset = ((gridSize.y - 1) * unitSize) / 2;

                Vector3 tilePosition = new Vector3(x * unitSize - xCenterOffset, yOffset, y * unitSize - yCenterOffset);
                newSlot.transform.localPosition = tilePosition;
                newSlot.transform.rotation = Quaternion.identity;

                if (x == 0 && y == 0)
                {
                    heroEntrance = tilePosition - new Vector3(0, 0, unitSize);
                    entranceSlot = newSlot.GetComponent<Slot>();
                    compileStartPosition = new Vector2Int(x, y);
                }

                if (x == gridSize.x - 1 && y == gridSize.y - 1)
                {
                    heroExit = tilePosition;
                }

                tileSlots[x + y * gridSize.x] = newSlot.GetComponent<Slot>();
            }
        }
    }

    public void DEBUGEnemy()
    {
        attackerData.SummonAttacker(AttackerType.Priest);
    }

    private Slot GetSlot(int x, int y)
    {
        return tileSlots[Mathf.RoundToInt(x + y * gridSize.x)];
    }

    public void DEBUGCompile()
    {
        Debug.Log(CompilePath());
    }

    public bool CompilePath()
    {
        Slot currentSlot = entranceSlot;
        Tile currentTile = (Tile)currentSlot.GetItem();
        int lastCompileDirection = 0;
        currentCompilePosition = compileStartPosition;

        if (!currentTile) return false;

        compiledPath = new List<Vector3>();
        compiledPath.Clear();
        compiledPath.Add(heroEntrance);

        int currentPathNode = 1;
        bool validNextTile = true;

        while (validNextTile)
        {
            validNextTile = false;

            for (int d = 0; d < 3; d++)
            {
                int relativeD = (d + lastCompileDirection + 3) % 4;
                Debug.Log(relativeD);

                // Determine if this tile's side is open
                if (!currentTile.GetSides()[relativeD]) continue;

                compiledPath.Add(currentSlot.transform.localPosition);

                Vector2Int nextPosition = currentCompilePosition;

                switch (relativeD)
                {
                    case 0:
                        nextPosition = currentCompilePosition + new Vector2Int(0, 1);
                        break;
                    case 1:
                        nextPosition = currentCompilePosition + new Vector2Int(1, 0);
                        break;
                    case 2:
                        nextPosition = currentCompilePosition + new Vector2Int(0, -1);
                        break;
                    case 3:
                        nextPosition = currentCompilePosition + new Vector2Int(-1, 0);
                        break;
                }

                Slot nextSlot = null;

                try
                {
                    nextSlot = GetSlot(nextPosition.x, nextPosition.y);
                }
                catch (Exception) { continue; }

                Tile nextTile = (Tile)nextSlot.GetItem();

                // Look for a tile in the next slot
                if (!nextTile) continue;

                // Determine if the side of the next tile facing the current tile is open
                if (!nextTile.GetSides()[(relativeD + 2) % 4]) continue;

                currentSlot = nextSlot;
                currentTile = nextTile;
                currentCompilePosition = nextPosition;
                currentPathNode++;
                lastCompileDirection = relativeD;

                validNextTile = true;
                break;
            }
        }
        return false;
    }

    public void LockFloor(bool setLocked)
    {
        foreach (Slot s in tileSlots)
        {
            s.GetItem().Lock(setLocked);
        }
    }
}
