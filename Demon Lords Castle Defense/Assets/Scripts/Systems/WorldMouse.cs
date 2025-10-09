using UnityEngine;

public class WorldMouse
{
    static Vector2 worldCorner = new Vector2(17.779f, 10);

    public static Vector2 Get()
    {
        float worldMouseX = Mathf.Lerp(-worldCorner.x, worldCorner.x, Input.mousePosition.x / Screen.width);
        float worldMouseY = Mathf.Lerp(-worldCorner.y, worldCorner.y, Input.mousePosition.y / Screen.height);
        return new Vector2(worldMouseX, worldMouseY);
    }
}
