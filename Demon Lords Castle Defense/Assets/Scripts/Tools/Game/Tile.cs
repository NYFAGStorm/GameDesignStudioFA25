using UnityEngine;

public class Tile : Placeable
{
    // Author: Gustavo Rojas Flores
    // Controls an individual tile

    // Written rules (Esther)
    // each Tile will have to have 2 sides that are Open, up to 4 sides of the Tile can be Open
    // connection rule:
    //      open + open = open
    //      open + close = close
    //      close + close = close
    //      open + null = close
    //      close + null = close
    // can be upgraded: to have more slots (up to 6), more powerful attacks, faster attack
    // clicking on any Tile will show [popup, click away will close said popup]:
    //      Tile info
    //              Tile name, attack attribute, current available slots, amount of damage, damage rate
    //      Upgrade
    //              showing the cost

    protected TileShape shape;
    protected TileDirection dir;
    protected TileType type;
    protected Tile[] neighbors = new Tile[4];
    protected const int maxSlots = 6;
    protected bool[] openSides = new bool[4];
    protected Slot[] goonSlots;

    public GameObject goonSlot;
    public SpriteRenderer plate;

    protected override void Update()
    {
        base.Update();

        if (isBeingDragged && Input.GetKeyDown(KeyCode.R))
        {
            dir = (TileDirection)((int)(dir + 1) % 4);
            plate.transform.localRotation = Quaternion.Euler(90, 0, (int)dir * -90);

            UpdateSides((int)dir);
        }
    }

    private void UpdateSides(int currentDir)
    {
        if (shape == 0)
        {
            openSides[0] = currentDir == 0 || currentDir == 2;
            openSides[1] = currentDir == 1 || currentDir == 3;
            openSides[2] = openSides[0];
            openSides[3] = openSides[1];
        }
        else
        {
            openSides[0] = currentDir == 2 || currentDir == 3;
            openSides[1] = currentDir == 3 || currentDir == 0;
            openSides[2] = currentDir == 0 || currentDir == 1;
            openSides[3] = currentDir == 1 || currentDir == 2;
        }
    }

    public void InitializeTile(UniqueTile data)
    {
        shape = data.shape;
        type = data.type;
        plate.sprite = data.plateImage;

        foreach (Vector2 goonSlotPosition in data.goonSlotPositions)
        {
            GameObject newGoonSlot = Instantiate(goonSlot, transform);
        }

        UpdateSides(0);
    }

    public bool[] GetSides()
    {
        return openSides;
    }

    public TileShape GetShape()
    {
        return shape;
    }
}
