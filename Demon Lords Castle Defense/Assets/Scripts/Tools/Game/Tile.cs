using UnityEngine;

public class Tile : Placeable
{
    // Author: Gustavo Rojas Flores
    // Controls an individual tile

    // Written rules (Esther)
    // 

    protected TileShape shape;
    protected TileDirection dir;
    protected TileType type;
    protected Tile[] neighbors = new Tile[4];
    protected const int maxSlots = 6;
    protected bool[] openSides = new bool[4];

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

    public void InitializeTile(TileShape inShape, TileType inType, Sprite plateImage)
    {
        shape = inShape;
        type = inType;
        plate.sprite = plateImage;

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
