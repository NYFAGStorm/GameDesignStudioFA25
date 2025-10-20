using UnityEngine;
using System.Collections.Generic;
using System;

public class TileFloorManager : MonoBehaviour
{
    // Author: Gustavo Rojas Flores
    // Manages Tile objects that are placed on it

    private Slot[] tileSlots = new Slot[0];
    private List<Vector3> compiledPath;
    private Vector3 heroEntrance;
    private Vector3 heroExit;
    private Slot entranceSlot;
    private Vector2Int currentCompilePosition;

    public GameObject tileObject;
    public Vector2Int gridSize;
    public float unitSize;
    public float yOffset;
    public Transform floor;
    public GameObject debugMarker;
    public GameObject debugEnemy;

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
                    currentCompilePosition = new Vector2Int(x, y);

                    if (debugMarker)
                    {
                        GameObject debugentrance = Instantiate(debugMarker, transform, false);
                        debugentrance.transform.localPosition = heroEntrance;
                    }
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
        Attacker newEnemy = Instantiate(debugEnemy, transform, false).GetComponent<Attacker>();
        newEnemy.InitializeAttacker(compiledPath, AttackerType.Priest, heroEntrance);
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
        int lastCompileDirection = 2;

        if (!currentTile) return false;

        compiledPath = new List<Vector3>();
        compiledPath.Clear();
        compiledPath.Add(heroEntrance);

        int currentPathNode = 1;
        bool validNextTile = true;

        while (validNextTile)
        {
            if (debugMarker) Instantiate(debugMarker, transform, false).transform.position = currentSlot.transform.position;

            //Debug.Log(currentSlot.transform.localPosition);
            validNextTile = false;

            for (int d = 0; d < 4; d++)
            {
                validNextTile = false;

                // Determine if this tile's side is open
                if (!currentTile.GetSides()[d]) continue;

                string sideName = Enum.GetName(typeof(TileDirection), (TileDirection)d);

                //Debug.Log(sideName + " side is open");

                compiledPath.Add(currentSlot.transform.localPosition);

                Vector2Int nextPosition = currentCompilePosition;

                switch (d)
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
                //Debug.Log("There is a slot at " + sideName);

                Tile nextTile = (Tile)nextSlot.GetItem();

                // Look for a tile in the next slot
                if (!nextTile) continue;
                //Debug.Log(sideName + " slot has a tile");

                // Determine if the side of the next tile facing the current tile is open
                if (!nextTile.GetSides()[(d + 2) % 4]) continue;
                //Debug.Log(sideName + " tile's side facing this tile is open");

                // Make sure not to backtrack
                if (lastCompileDirection == d) continue;
                //Debug.Log(sideName + " is not compiled yet");

                currentSlot = nextSlot;
                currentTile = nextTile;
                currentCompilePosition = nextPosition;
                currentPathNode++;
                lastCompileDirection = Mathf.RoundToInt((d + 2) % 4);

                //Debug.Log("Adding " + sideName + " tile");

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
