using UnityEngine;
using System.Collections.Generic;
using System;
using Random = UnityEngine.Random;

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
    private Vector3 exitSlotPosition;
    private Slot entranceSlot;
    private Vector2Int currentCompilePosition;
    private Vector2Int compileStartPosition;

    [HideInInspector]
    public bool validPath;
    public GameObject tileObject;
    public Vector2Int gridSize;
    public float unitSize;
    public float yOffset;
    public Transform floor;
    public GameObject debugEnemy;
    public AttackerData attackerData;
    public bool horizontalEntrance = true;
    public GameObject startMarker;
    public GameObject endMarker;

    private void Awake()
    {
        tileSlots = new Slot[gridSize.x * gridSize.y];
        floor.GetComponent<SpriteRenderer>().size = new Vector2((gridSize.x * unitSize) / 1.55f + 3.1f, (gridSize.y * unitSize) / 1.55f + 2.93f);

        int entrance = Random.Range(0, horizontalEntrance ? gridSize.y : gridSize.x);
        int exit = entrance;

        do
        {
            exit = Random.Range(0, horizontalEntrance ? gridSize.y : gridSize.x);
        } 
        while (entrance - 1 == exit);

        for (int y = 0; y < gridSize.y; y++)
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                Slot newSlot = Instantiate(tileObject, transform, false).GetComponent<Slot>();

                float xCenterOffset = ((gridSize.x - 1) * unitSize) / 2;
                float yCenterOffset = ((gridSize.y - 1) * unitSize) / 2;

                Vector3 tilePosition = new Vector3(x * unitSize - xCenterOffset, yOffset, y * unitSize - yCenterOffset);
                newSlot.transform.localPosition = tilePosition;
                newSlot.transform.rotation = Quaternion.identity;

                if (horizontalEntrance ? (x == 0) : (y == 0))
                {
                    if (horizontalEntrance ? (y == entrance) : (x == entrance))
                    {
                        heroEntrance = tilePosition + (horizontalEntrance ? new Vector3(-unitSize, 0, 0) : new Vector3(0, 0, -unitSize));

                        GameObject marker = Instantiate(startMarker, transform, false);
                        marker.transform.localPosition = heroEntrance;
                        marker.transform.localRotation = horizontalEntrance ? Quaternion.Euler(0, 90, 0) : Quaternion.Euler(0, 180, 0);

                        compileStartPosition = new Vector2Int(x, y);
                        entranceSlot = newSlot;
                    }
                }

                if (horizontalEntrance ? (x == gridSize.x - 1) : (y == gridSize.y - 1))
                {
                    if (horizontalEntrance ? (y == exit) : (x == exit))
                    {
                        exitSlotPosition = tilePosition;
                        heroExit = tilePosition + (horizontalEntrance ? new Vector3(unitSize, 0, 0) : new Vector3(0, 0, unitSize));

                        GameObject marker = Instantiate(endMarker, transform, false);
                        marker.transform.localPosition = heroExit;
                        marker.transform.localRotation = horizontalEntrance ? Quaternion.Euler(0, 90, 0) : Quaternion.Euler(0, 180, 0);
                    }
                }

                tileSlots[x + y * gridSize.x] = newSlot;
                newSlot.SlotUpdated.AddListener(AttemptCompile);
            }
        }
    }

    private Slot GetSlot(int x, int y)
    {
        return tileSlots[Mathf.RoundToInt(x + y * gridSize.x)];
    }

    private void AttemptCompile()
    {
        validPath = CompilePath();
    }

    public bool CompilePath()
    {
        Slot currentSlot = entranceSlot;
        Tile currentTile = (Tile)currentSlot.GetItem();
        Tile lastTile = null;
        int lastCompileDirection = 0;
        currentCompilePosition = compileStartPosition;

        if (!currentTile) return false;

        compiledPath = new List<Vector3>();
        compiledPath.Clear();
        compiledPath.Add(heroEntrance);

        int currentPathNode = 1;
        bool validNextTile = true;
        bool[] lastSides = { false, false, false, false };

        while (validNextTile)
        {
            validNextTile = false;

            for (int d = 0; d < 3; d++)
            {
                int relativeD = (d + lastCompileDirection + 3) % 4;

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

                // Make sure the next tile is not equal to the last tile extended from
                if (nextTile == lastTile) continue;

                lastCompileDirection = relativeD;
                lastSides = nextTile.GetSides();
                lastTile = currentTile;

                currentSlot = nextSlot;
                currentTile = nextTile;
                currentCompilePosition = nextPosition;
                currentPathNode++;

                validNextTile = true;
                break;
            }
        }

        if ((horizontalEntrance ? lastSides[1] : lastSides[2]) && compiledPath[compiledPath.Count - 1] == exitSlotPosition)
        {
            compiledPath.Add(heroExit);
            compiledPath.RemoveAt(1);
            compiledPath.RemoveAt(compiledPath.Count - 2);

            attackerData.UpdatePath(compiledPath);

            return true;
        }
        else
        {
            return false;
        }
    }

    public void LockFloor(bool setLocked)
    {
        foreach (Slot s in tileSlots)
        {
            Placeable slotItem = s.GetItem();
            if (slotItem) slotItem.Lock(setLocked);
        }
    }
}
